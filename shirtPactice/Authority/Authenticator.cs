using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace shirtPactice.Authority
{
    public static class Authenticator
    {
        public static bool Authenticate(string clentID,string secret)
        {
            var app =  AppRepositry.GetApplicationByClientId(clentID);
            if (app == null) return false;

            return (app.ClientId == clentID && app.Secret == secret);
        }

        public static string CreateToken(string clientId, DateTime expireAt,string strsecretKey)
        {
            var app = AppRepositry.GetApplicationByClientId(clientId);

            var claims = new List<Claim>
            {
                new Claim("AppName", app?.ApplicationName??string.Empty),
                new Claim("Read", (app?.Scopes??string.Empty).Contains("read")?"true":"false"),
                new Claim("Write", (app?.Scopes??string.Empty).Contains("write")?"true":"false"),
                new Claim("AppName", app?.ApplicationName??string.Empty),
            };

            var secretKey = Encoding.ASCII.GetBytes(strsecretKey);

            var jwt = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature
                    ),
                claims: claims,
                expires: expireAt,
                notBefore: DateTime.UtcNow
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
