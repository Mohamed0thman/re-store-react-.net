using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Servises
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public UserManager<User> _UserManager;
        public TokenService(UserManager<User> userManager, IConfiguration configuration)
        {
            _UserManager = userManager;
            _configuration = configuration;


        }


        public async Task<string> GenerateToken(User user)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)

            };

            var rols = await _UserManager.GetRolesAsync(user);
            foreach (var role in rols)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));

            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:TokenKey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenOption = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOption);
        }
    }
}