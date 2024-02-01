using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;
=======
>>>>>>> 37adc52dce82ee54449ea140264574bb0ea04451

namespace Test_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
<<<<<<< HEAD
        private readonly IConfiguration config;
       public AccountController(UserManager<ApplicationUser> userManager , IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
=======
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
>>>>>>> 37adc52dce82ee54449ea140264574bb0ea04451
        }
        [HttpPost("register")]
        public async Task<IActionResult> register(UserRegisterDTO userDto)
        {
<<<<<<< HEAD
            if (ModelState.IsValid == true)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = userDto.UserName;
=======
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = userDto.Name;
>>>>>>> 37adc52dce82ee54449ea140264574bb0ea04451
                user.Email = userDto.Email;
              IdentityResult result = await userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded) 
                {
                return Ok("account Add Success");
                }
            else
                {
                 return BadRequest(result.Errors.FirstOrDefault());
                }
            }
            return BadRequest(ModelState);
        }
<<<<<<< HEAD
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO userDto)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser? user = await userManager.FindByNameAsync( userDto.UserName );
                if (user != null)
                {
                  bool fond = await userManager.CheckPasswordAsync(user, userDto.Password );
                    if (fond)
                    {
                        //create clims
                        var claims = new List<Claim>();
                        claims.Add(new Claim (ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim (ClaimTypes.NameIdentifier , user.Id));
                        claims.Add(new Claim (JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()));
                        //create roles 
                        var roles = await userManager.GetRolesAsync(user);
                        foreach (var roleitem in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, roleitem));
                        }
                        // create signing&& key
                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));
                        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        
                        //create token
                        JwtSecurityToken myToken = new JwtSecurityToken( 
                            issuer: config["JWT:ValidIssuer"],
                            audience: config["JWT:ValidAudiance"],
                            claims: claims , 
                            expires: DateTime.Now.AddDays(15),
                            signingCredentials : signingCredentials
                            );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(myToken),
                            expiration = myToken.ValidTo
                        });
                    }
                    return Unauthorized();
                }
                return Unauthorized();

            }
            return Unauthorized();
        }
    }
    
   
=======
        

    }
>>>>>>> 37adc52dce82ee54449ea140264574bb0ea04451
}
