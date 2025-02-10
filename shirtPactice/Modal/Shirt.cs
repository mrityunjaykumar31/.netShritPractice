using shirtPactice.Modal.Validator;
using System.ComponentModel.DataAnnotations;

namespace shirtPactice.Modal
{
    public class Shirt
    {
        public int shirtId { get; set; }
        public string? shirtName { get; set; }
        public string? shirtDescription { get; set; }
        public string? gender { get; set; }
        [Shirt_Validation_]
        public int? size { get; set; }

        [Required]
        public string? shirtModel { get; set; }

    }
}
