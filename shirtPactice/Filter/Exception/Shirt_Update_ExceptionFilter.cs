using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using shirtPactice.Data;
using shirtPactice.Modal;

namespace shirtPactice.Filter.Exception
{
    public class Shirt_Update_ExceptionFilter: ExceptionFilterAttribute
    {
        private readonly ShirtDbContext dbContext;
        public Shirt_Update_ExceptionFilter(ShirtDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strshirtId = context.RouteData.Values["id"]as string;
            

            if (int.TryParse(strshirtId, out int shirtId ))
            {
                if (dbContext.Shirts.FirstOrDefault(x => x.shirtId == shirtId) == null) {
                    context.ModelState.AddModelError("ShirtId", "Shirt does not exit any more");

                    var validationProblem = new ValidationProblemDetails(context.ModelState) { Status = StatusCodes.Status400BadRequest };
                    context.Result = new BadRequestObjectResult(validationProblem);
                }
             
            }
        }
    }
}
