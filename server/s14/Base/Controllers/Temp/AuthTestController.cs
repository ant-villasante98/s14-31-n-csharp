using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S14.Base.Infrastructure.Data;

namespace S14.Base.Controllers.Temp
{
    [Route("api/test")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {
        /// <summary>
        /// Obtiene  los emails de  usuarios registrados en la bd.
        /// </summary>
        /// <returns>lista de emails.</returns>
        /// <exception cref="ArgumentNullException">Context is null.</exception>
        /// <remarks>
        /// Para los usuarios iniciales las contraseñas son:
        /// 
        ///     admin@gmail.com => Admin123!
        ///     user@gmail.com  => User123!
        ///     agent@gmail.com => Agent123!
        /// </remarks>
        [HttpGet("GetAllRegisteredUsers")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<string>> GetAllUsersAsync([FromServices] Context context)
        {
            context = context ?? throw new ArgumentNullException(nameof(context));
            return await context!.Users.Select(x => x.Email ?? string.Empty).ToListAsync();
        }

        [HttpGet("GetActualUserClaims")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public IEnumerable<string> GetActualUserClaims()
        {
            return this.User!.Claims.Select(x => $"{x.Type} - {x.Value}").ToList();
        }
    }
}
