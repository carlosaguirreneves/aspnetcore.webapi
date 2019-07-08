using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Desafio.Repository;
using Desafio.WebAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Desafio.Domain;

namespace Desafio.WebAPI.Controllers
{
    [ApiController]
    [Route("/[controller]/")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private IUserRepository _repository { get; }

        public UserController(IUserRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _config = configuration;
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            try
            {
                var user = await _repository.FindByUserName(model.Login);
                if (user != null && user.Password == Util.Utility.ComputeHash(model.Password)) 
                {
                    return Ok(new
                    {
                        id = user.Id,
                        userName = user.UserName,
                        token = GenerateJWToken(user)
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Unauthorized();
        }

        private string GenerateJWToken(User model)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, model.Id),
                new Claim(ClaimTypes.Name, model.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}