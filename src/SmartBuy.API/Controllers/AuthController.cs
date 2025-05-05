using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartBuy.API.Model;
using SmartBuy.Core.Entities;
using SmartBuy.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SmartBuy.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/conta")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JWTSettings _jwtSettings;
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<JWTSettings> jwtSettings,
            ApplicationDbContext applicationDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("registrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if(!ModelState.IsValid) 
                return ValidationProblem(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var vendedorTemp = new Vendedor
            {
                IdVendedor = user.Id,
                Nome = registerUser.Email,
                Email = registerUser.Email,
                Senha = registerUser.Senha,
            };

            var result = await _userManager.CreateAsync(user, registerUser.Senha);
            if (result.Succeeded) 
            {
                //salva o vendedor
                _applicationDbContext.Vendedores.Add(vendedorTemp);
                await _applicationDbContext.SaveChangesAsync();

                await _signInManager.SignInAsync(user, false);
                return Ok(GerarJwt());
            }
            return Problem("Falha ao registrar o usuaário");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Senha, false, true);

            if (result.Succeeded) 
            {
                return Ok(GerarJwt());
            }
            return Problem("Usuário ou senha inválidos");
        }

        private string GerarJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Segredo);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor 
            {
                Issuer = _jwtSettings.Emissor,
                Audience = _jwtSettings.Audiencia,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);  

            return encodedToken;
        }
    }
}
