using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using S14.Base.Controllers.Hubs;
using S14.Base.Infrastructure;
using S14.Base.Infrastructure.Data;
using S14.UserManagment.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Si se va a usar postgres aca va una variable de entorno
#pragma warning disable S125 // Sections of code should not be commented out
/*
        if (Environment.GetEnvironmentVariable("DATABase") == "postgres")
        {
var cs = builder.Configuration.GetConnectionString("CSPostgress");
builder.Services.AddDbContext<Context>(x => x.UseNpgsql(cs));
            options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
        }
 */
#pragma warning restore S125 // Sections of code should not be commented out
var hubPath = "/order-pos-hub";

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

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "NoWait" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Scheme = "Bearer",
        Description = "Ingresa  solo el {token}, pero cuando estes llamando desde postman o la app, debes agregar => Bearer {token}",
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

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

// Add Me endpoint to get custom values from AppUser
app.MapGroup("api/auth")
    .MapIdentityApi<AppUser>()
    .WithTags("Auth api");

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// create all schemas
//app.CreateSchemas();
app.MapHub<OrderPosHub>(hubPath);

app.Run();