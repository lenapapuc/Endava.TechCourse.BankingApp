﻿using Endava.TechCourse.BankApp.Application.Commands.LoginUser;
using Endava.TechCourse.BankApp.Application.Commands.RegisterUser;
using Endava.TechCourse.BankApp.Application.Queries.GetUserDetails;
using Endava.TechCourse.BankApp.Server.Common.JWToken;
using Endava.TechCourse.BankApp.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Endava.TechCourse.BankApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly JwtService jwtService;

        public AccountController(IMediator mediator, JwtService jwtService)
        {
            ArgumentNullException.ThrowIfNull(mediator);
            this.mediator = mediator;
            this.jwtService = jwtService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var registerUserCommand = new RegisterUserCommand()
            {
                Username = dto.Username,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                Email = dto.Email
            };
            var result = await mediator.Send(registerUserCommand);
            return result.IsSuccessful ? Ok(result) : BadRequest(new { result.Error });
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var loginCommand = new LoginUserCommand()
            {
                Username = dto.Username,
                Password = dto.Password
            };

            var result = await mediator.Send(loginCommand);

            if (!result.IsSuccessful)
                return BadRequest(result.Error);

            var userDetailsQuery = new GetUserDetailsQuery()
            {
                Username = dto.Username
            };

            var userDetails = await mediator.Send(userDetailsQuery);

            string jwtToken = jwtService.CreateAuthToken(userDetails.Id, userDetails.Username, userDetails.Roles);

            Response.Cookies.Append(Constants.TokenCookieName, jwtToken, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTimeOffset.MaxValue
            });

            return Ok(jwtToken);
        }
    }
}
