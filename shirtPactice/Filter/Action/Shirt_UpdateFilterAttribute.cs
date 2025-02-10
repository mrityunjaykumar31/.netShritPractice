using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using shirtPactice.Data;
using shirtPactice.Modal;

namespace shirtPactice.Filter.Action
{
    public class Shirt_UpdateFilterAttribute : ActionFilterAttribute
    {



        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirtId = context.ActionArguments["id"] as int?;
            var shirt = context.ActionArguments["shirt"] as Shirt;

            if (shirt != null && shirt.shirtId != shirtId)
            {

                context.ModelState.AddModelError("ShirtId", "Shirt id Invlid paylod id miss match");

                var validationProblem = new ValidationProblemDetails(context.ModelState) { Status = StatusCodes.Status400BadRequest };
                context.Result = new BadRequestObjectResult(validationProblem);

            }

        }
    }
}

