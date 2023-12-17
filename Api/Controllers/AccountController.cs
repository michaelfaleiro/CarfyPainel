using Api.Data;
using Api.Dtos.Role;
using Api.Dtos.User;
using Api.Extensions;
using Api.Models;
using Api.Services;
using Api.Services.Account;
using Api.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Api.Controllers
{
    [ApiController]
    public class AccountController(TokenService tokenService, IMapper mapper, IAccountService accountService) : ControllerBase
    {
        private readonly TokenService _tokenService = tokenService;
        private readonly IMapper _mapper = mapper;
        private readonly IAccountService _accountService = accountService;

        [HttpPost("v1/api/accounts")]
        public async Task<ActionResult<User>> CreateUserAsync([FromBody] CreateUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<User>(ModelState.GetErrors()));
            }

            var user = _mapper.Map<User>(model);

            user.Password = PasswordHasher.Hash(user.Password);

            try
            {
                await _accountService.CreateUserAsync(user);

                return Created($"v1/api/account/{user.Id}", new ResultViewModel<dynamic>(new { user.Name, user.Email, user.Roles }));
            }
            catch (DbUpdateException)
            {
                return HttpStatusCode(400, new ResultViewModel<User>("Email já cadastrado"));
            }
            catch
            {
                return HttpStatusCode(500, new ResultViewModel<User>("Erro interno no servidor"));
            }
        }

        private ActionResult<User> HttpStatusCode(int v, ResultViewModel<User> resultViewModel)
        {
            throw new NotImplementedException();
        }

        [HttpPost("v1/api/accounts/login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<User>(ModelState.GetErrors()));
            }

            var userLogin = _mapper.Map<User>(model);

            try
            {
                var user = await _accountService.GetUserByEmailAsync(userLogin.Email);

                if (user == null)
                    return HttpStatusCode(401, new ResultViewModel<User>("Email ou Senha Inválidos"));

                if (!PasswordHasher.Verify(user.Password, userLogin.Password))
                    return HttpStatusCode(401, new ResultViewModel<User>("Email ou Senha Inválidos"));

                var token = _tokenService.GenerateToken(user);
                return Ok(new ResultViewModel<string>(token, null));
            }
            catch (Exception)
            {
                return HttpStatusCode(500, new ResultViewModel<User>("Erro interno no servidor"));
            }
        }

        [HttpPost("v1/api/roles")]
        public async Task<ActionResult> PostRole([FromBody] CreateRole model, [FromServices] DbApiContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<User>(ModelState.GetErrors()));
            }

            var role = _mapper.Map<Role>(model);

            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();

            return Created("v1", role);
        }
    }
}