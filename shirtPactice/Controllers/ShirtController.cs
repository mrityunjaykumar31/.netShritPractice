using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shirtPactice.Data;
using shirtPactice.Filter.Action;
using shirtPactice.Filter.Auth;
using shirtPactice.Filter.Exception;
using shirtPactice.Modal;
using shirtPactice.Repository;

namespace shirtPactice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [JwtTokenAuthFilter]
    public class ShirtController : ControllerBase

    {

        private readonly ShirtDbContext dbContext;

        public ShirtController(ShirtDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult getAllShirts()
        {
            return Ok(this.dbContext.Shirts.ToList());
        }
        [HttpGet("{id}")]
        [TypeFilter(typeof(Shirt_ValidateIdFilterAttribute))   ]
        public IActionResult getShrittById(int id)
        {

            return Ok(HttpContext.Items["shirt"]);
  
        }
        [HttpPut("{id}")]
        [TypeFilter(typeof(Shirt_ValidateIdFilterAttribute))]
        [Shirt_UpdateFilter]
        [TypeFilter(typeof(Shirt_Update_ExceptionFilter))]
        public IActionResult UpdateShrit(int id , [FromBody] Shirt shirt)
        {
           var updateShirt = HttpContext.Items["shirt"]as Shirt;

            updateShirt.size = shirt.size;
            updateShirt.shirtName = shirt.shirtName;
            updateShirt.shirtDescription = shirt.shirtDescription;
            updateShirt.shirtModel = shirt.shirtModel;

            this.dbContext.SaveChanges();
                return NoContent();
               

          //  return "update shrit";
        }
        [HttpDelete("{id}")]
        public string DeletShrit()
        {
            return "delet shrit";
        }

        [HttpPost]
        public Shirt CreateShrit([FromBody] Shirt shirt)
        {
           
            return shirt;
        }

    }
}
