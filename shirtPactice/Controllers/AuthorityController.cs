using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using shirtPactice.Modal;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shirtPactice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorityController : ControllerBase
    {

        // POST api/<AuthorityController>
        [HttpPost]
        public  IActionResult Authenticate([FromBody] Authenticate value)
        {
           
                return Ok(new
                {
                    accessToken = Authentication.GenerateJwtToken(value.userName  )

                });
            
           
        }
        
      

    
    }
    
}
