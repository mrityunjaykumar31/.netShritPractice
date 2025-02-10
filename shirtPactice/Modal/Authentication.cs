using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace shirtPactice.Modal
{
    public static class Authentication
    {

        private static readonly string _secretKey = "your-very-long-secret-key-that-is-256-bits"; // Secret key used for signing the token
        public static string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "User") // Add any roles or claims you need
        };

            // Create a symmetric security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            // Create signing credentials using the security key and algorithm (HMACSHA256)
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define token expiration
            var expirationTime = DateTime.UtcNow.AddSeconds(10);

            // Create the JWT token
            var jwtToken = new JwtSecurityToken(
                issuer: "YourIssuer",            // Issuer of the token (your app or domain)
                audience: "YourAudience",        // Audience (where the token is expected to be sent)
                claims: claims,                  // Claims to include in the token
                expires: expirationTime,         // Expiration time
                signingCredentials: signingCredentials);

            // Create a JWT token handler and serialize the token into a string
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtToken);
        }

        public static bool ValidateJwtToken(string? token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token)) return false;
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "YourIssuer",
                    ValidAudience = "YourAudience",
                    IssuerSigningKey = securityKey,
                    ClockSkew = TimeSpan.Zero,
                };

                // Validate the token
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                return validatedToken != null;  // If no exception is thrown, the token is valid
            }
            catch (Exception)
            {
                return false; // If validation fails, the token is invalid
            }
            
        }
    }
}
