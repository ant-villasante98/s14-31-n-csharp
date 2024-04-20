using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using S14.Base.Controllers.Hubs;
using S14.Base.Infrastructure;
using S14.Base.Infrastructure.Data;
using S14.UserManagment.Infraestructure;

var hubPath = "/order-pos-hub";
var builder = WebApplication.CreateBuilder(args);

var cs = builder.Configuration.GetConnectionString("CS");
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(cs));

// Add services to the container.
builder.Services.AuthenticationForSignalR(hubPath);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<AppUser>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<Context>()
    .AddApiEndpoints();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.User = new UserOptions { RequireUniqueEmail = true };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwaggerGen();

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()));

// inyectar servicios desde un archivo externo a Program.cs
builder.Services.AddDomainServices(builder.Configuration);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSignalR();

var app = builder.Build();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI(options =>
    options.EnableTryItOutByDefault());

app.MapGroup("api/auth")
    .MapIdentityApi<AppUser>()
    .WithTags("Auth api");

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// create all schemas
//app.CreateSchemas();
app.MapHub<NotificationsHub>(hubPath);

app.Run();