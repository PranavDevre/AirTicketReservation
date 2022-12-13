using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace AIR_RESERVATION_SYSTEM_API.Token
{
    public class TokenGenerator : ITokenGenerator
    {
        //    string GenrateToken()
        public string GenerateToken(string name, string pass)
        {
            var userClaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,pass)
            };

            var userSecurityKey = Encoding.UTF8.GetBytes("axdcfvgrtefdthyg");
            var userSymmetricSecurityKey = new SymmetricSecurityKey(userSecurityKey);
            var userSigninCredentials = new SigningCredentials(userSymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var userJWTSecurityToken = new JwtSecurityToken
           (
                issuer: "Admin",
                audience: "Login",
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: userSigninCredentials

                );
            var userSecurityHandler = new JwtSecurityTokenHandler().WriteToken(userJWTSecurityToken);
            return userSecurityHandler;
        }
    }
}
