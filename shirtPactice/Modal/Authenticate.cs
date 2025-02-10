using System.ComponentModel.DataAnnotations;

namespace shirtPactice.Modal
{
    public class Authenticate
    {
        
        public required string userName { get; set; }
       
        public required string password { get; set; }
    }
}
