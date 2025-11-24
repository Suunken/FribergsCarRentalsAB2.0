using FribergsABData.Constants;
using FribergsABData.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FribergsABData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApiUser> userManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }
        [HttpPost]
        [Route("register")]
        
        public async Task<IActionResult> Register(UserDto userDto)
        {
            try
            {
                ApiUser user = new ApiUser()
                {
                    UserName = userDto.Email,
                    Email = userDto.Email,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName

                };

                var result = await userManager.CreateAsync(user, userDto.Password);

                if (result.Succeeded == false)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await userManager.AddToRoleAsync(user, ApiRoles.User);
                return Accepted();
            }
            catch (Exception ex) 
            {
                return Problem($"Något blev fel i {nameof(Register)}", statusCode: 500);
            }
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginUserDto loginUserDto)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(loginUserDto.Email);
                var passwordValid = await userManager.CheckPasswordAsync(user, loginUserDto.Password);
                if (user == null || passwordValid == false)
                {
                    return Unauthorized(loginUserDto);
                }


                string tokenString = await GenerateToken(user);

                var response = new AuthResponse
                {
                    Email = loginUserDto.Email,
                    Token = tokenString,
                    UserId = user.Id
                };

                return Accepted(response);

            }
            catch (Exception ex) 
            {
                return Problem($"Något blev fel i {nameof(Login)}", statusCode: 500);
            }

        }

        private async Task<string> GenerateToken(ApiUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var userClaims = await userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(roleClaims)
            .Union(userClaims);



            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}
