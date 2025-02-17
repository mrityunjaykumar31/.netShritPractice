using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using shirtPactice.Authority;
using shirtPactice.Modal;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shirtPactice.Controllers
{
    [ApiController]
    public class AuthorityController : ControllerBase
    {
        public readonly IConfiguration configuration;
        public AuthorityController(IConfiguration configuration) {
            this.configuration = configuration;
        }


        // POST api/<AuthorityController>
        [Route("auth")]
        [HttpPost]
        public  IActionResult Authenticate([FromBody] Authenticate value)
        {
            if (AppRepositry.Authenticate(value.clientId,value.secret))
            {
                var expireAt = DateTime.UtcNow.AddMinutes(10);

                return Ok(new
                {
                    accessToken = Authenticator.CreateToken(value.clientId,expireAt,configuration.GetValue<string>("SecretKey")),
                    expires_at =  expireAt

                });
            }
            else
            {
                ModelState.AddModelError("Unauthorized", "You are not authorize");

                var validationProblem = new ValidationProblemDetails(ModelState) { Status = StatusCodes.Status401Unauthorized };
                return new UnauthorizedObjectResult(validationProblem);
            }
        }
    }
    
}
