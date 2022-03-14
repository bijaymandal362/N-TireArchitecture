using System;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Data;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Account;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly DataContext _context; 
        private readonly ILogger<AccountController> _logger;
        public AccountController(DataContext context, TokenService tokenService, ILogger<AccountController> logger)
        {
            _logger = logger;
            _context = context;
            _tokenService = tokenService;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<PersonModel>> Login(LoginModel loginModel)
        {
            
            var person = await _context.Person.Where(x => x.Email == loginModel.Email).FirstOrDefaultAsync();
            if (person == null)
            {
                _logger.LogWarning($"Unauthorized: Email not found. Email: {loginModel.Email} Password:{loginModel.Password} Time: {DateTimeOffset.UtcNow}");
                return Unauthorized();
            }

            var passwordVerificationResult = new PasswordHasher<Person>().VerifyHashedPassword(person, person.PasswordHash, loginModel.Password);

            switch (passwordVerificationResult)
            {
                case PasswordVerificationResult.Failed:
                   _logger.LogWarning($"Unauthorized: Password Incorrect. Email: {loginModel.Email} Password:{loginModel.Password} Time: {DateTimeOffset.UtcNow}");
                    return Unauthorized();

                case PasswordVerificationResult.Success:
                    return CreateUserObject(person);


                default:
                  _logger.LogWarning($"BadRequest: Something went wrong when authenticating. Email: {loginModel.Email} Password:{loginModel.Password} Time: {DateTimeOffset.UtcNow}");
                    return BadRequest("Something went wrong in authenticating user");
            }
           
         


        }

        private PersonModel CreateUserObject(Person person)
        {
            return new PersonModel
            {
                FirstName = person.FirstName,
                PersonId = person.PersonId,
                Token = _tokenService.CreateToken(person)
            };
        }
    }
}