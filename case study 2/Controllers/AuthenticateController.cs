using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiProductCaseStudy.Models;

namespace WebApiProductCaseStudy.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public List<UserModel> usersList = null;
        public AuthenticateController()
        {
            usersList = new List<UserModel>()
            {
                new UserModel() { UserId = 1, UserName = "akshay", Password = "1999", Role = "Admin" },
                new UserModel() { UserId = 2, UserName = "Aks", Password = "2000", Role = "User" }
            };
        }

        [HttpPost]
        public IActionResult Login(LoginModel requestUser)
        {
            UserModel userObj = usersList.Where(x => x.UserName == requestUser.UserName && x.Password == requestUser.Password).FirstOrDefault();

            if (userObj != null)
            {
                string tokenStr = GenerateJSONWebToken(userObj);
                return Ok(new { token = tokenStr });
            }
            else
            {
                return BadRequest("Invalid user id or password");
            }
        }

        private string GenerateJSONWebToken(UserModel userObj)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            List<Claim> authClaims = new List<Claim>
            {
                    new Claim(ClaimTypes.NameIdentifier,Convert.ToString(userObj.UserId)),
                    new Claim(ClaimTypes.Name, userObj.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  // (JWT ID) Claim
                    new Claim(ClaimTypes.Role, userObj.Role)
             };

            JwtSecurityToken token = new JwtSecurityToken(
                        issuer: "mySystem",
                        audience: "myUsers",
                        claims: authClaims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: credentials);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
