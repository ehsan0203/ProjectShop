using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectHemid.Data;
using ProjectHemid.Interface;
using ProjectHemid.Model.Dto;
using ProjectHemid.Services;

namespace ProjectHemid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenService;

        public AuthController(UserManager<IdentityUser> userManager, AuthDbContext tokenService, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.tokenService = new TokenService(tokenService, configuration);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
        {
            var identityUser = await userManager.FindByEmailAsync(requestDto.Email);
            if (identityUser is not null)
            {
              var checkpasswordResult =  await userManager.CheckPasswordAsync(identityUser, requestDto.Password);
                if (checkpasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(identityUser);

                    var jwtToken = tokenService.CreatJwtToken(identityUser, roles.ToList());


                    var response = new LoginResponseDto()
                    {
                        Email = requestDto.Email,
                        Roles = roles.ToList(),
                        Token = jwtToken
                    };
                    return Ok(response);
                }
            }
            ModelState.AddModelError("","Email or Password Incorrect" );
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var user = new IdentityUser
            {
                UserName = request.Email?.Trim(),
                Email = request.Email?.Trim()
            };
           var identityResult= await userManager.CreateAsync(user,request.Password);
            if (identityResult.Succeeded)
            {
                identityResult = await userManager.AddToRoleAsync(user, "Reader");
                if(identityResult.Succeeded)
                {
                    return Ok();
                }
            }
            else
            {
                if(identityResult.Errors.Any())
                {
                    foreach(var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return ValidationProblem(ModelState);
        }
    }
}
