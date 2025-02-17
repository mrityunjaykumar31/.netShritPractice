using System.ComponentModel.DataAnnotations;

namespace shirtPactice.Modal
{
    public class Authenticate
    {
        
        public required string clientId { get; set; }
       
        public required string secret { get; set; }
    }
}
