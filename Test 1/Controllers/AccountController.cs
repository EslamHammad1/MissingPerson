using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> register(UserRegisterDTO userDto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = userDto.Name;
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
        

    }
}
