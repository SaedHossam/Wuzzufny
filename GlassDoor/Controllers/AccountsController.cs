using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;
using GlassDoor.ViewModels;
using Microsoft.AspNetCore.Identity;
using GlassDoor.JwtFeatures;
using System.IdentityModel.Tokens.Jwt;

namespace GlassDoor.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;

        public AccountsController(UserManager<ApplicationUser> userManager, IMapper mapper, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<ApplicationUser>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            return StatusCode(201);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByEmailAsync(userForAuthentication.Email);

            if (user == null)
                return BadRequest("Authentication failed. Wrong Username or Password");
           
            if (!await _userManager.IsEmailConfirmedAsync(user))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Email is not confirmed" });

            //you can check here if the account is locked out in case the user enters valid credentials after locking the account.
            if (await _userManager.IsLockedOutAsync(user))
            {
                var content = $"Your account is locked out. To reset the password click this link: {userForAuthentication.clientURI}";
                // var message = new Message(new string[] { userForAuthentication.Email }, "Locked out account information", content, null);
                // await _emailSender.SendEmailAsync(message);

                return Unauthorized(new AuthResponseDto { ErrorMessage = "The account is locked out" });
            }

            if (!await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            {
                await _userManager.AccessFailedAsync(user);

                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            }
    

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            await _userManager.ResetAccessFailedCountAsync(user);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }

        //[HttpPost("ResetPassword")]
        //public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        //{
        //    //previous code

        //    await _userManager.SetLockoutEndDateAsync(user, new DateTime(2000, 1, 1));

        //    return Ok();
        //}
    }
}
