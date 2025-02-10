using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using shirtPactice.Data;
using shirtPactice.Modal;
using shirtPactice.Repository;

namespace shirtPactice.Filter.Action
{
    public class Shirt_ValidateIdFilterAttribute : ActionFilterAttribute
    {
        private readonly ShirtDbContext dbContext;

        public Shirt_ValidateIdFilterAttribute(ShirtDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirtId = context.ActionArguments["id"] as int?;
            var shirt = dbContext.Shirts.Find(shirtId);
            if (shirtId.HasValue)
            {
                if (shirtId <= 0)
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt id Invlid");

                    var validationProblem = new ValidationProblemDetails(context.ModelState) { Status = StatusCodes.Status400BadRequest };
                    context.Result = new BadRequestObjectResult(validationProblem);
                }
                else if (shirt == null)
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt id Invlid");
                    var validationProblem = new ValidationProblemDetails(context.ModelState) { Status = StatusCodes.Status404NotFound };

                    context.Result = new NotFoundObjectResult(validationProblem);
                }
                else
                {
                    context.HttpContext.Items["shirt"] = shirt;
                }
            }

        }
    }
}
