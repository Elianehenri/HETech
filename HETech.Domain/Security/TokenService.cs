using HETech.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HETech.Domain.Security
{
    public class TokenService
    {
        public static string GenerateToken(Usuario usuario, string jwtkey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(jwtkey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //propriedades de segurança do token
                    new Claim(ClaimTypes.Role, usuario.Role.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Name.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email.ToString()),
                }),
                //expirar em 2 horas
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
