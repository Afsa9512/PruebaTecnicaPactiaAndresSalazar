using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.IdentityModel.Tokens;
using PruebaPactia.BL.Interfaces;
using PruebaPactia.BL.Task;
using PruebaPactia.Entities.Dtos;
using PruebaPactia.Entities.Models;
using PruebaPactia.Entities.Response;
using PruebaPactia.Utility;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaPactia.API.Controllers
{
    [SwaggerTag("Token", "Controlador para la Autenticación y asignación del Token")]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private UserBL _actionBL_User;
        public IConfiguration _configuration;

        private ResponseModel responseModel;

        public TokenController(IUserBL actionBL_User, IConfiguration config)
        {
            _actionBL_User = (UserBL?)actionBL_User;
            _configuration = config;
        }

        /// <summary>
        /// Obtener el TOKEN de Seguridad
        /// </summary>
        /// <param name="dto">Objeto de Seguridad</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(UserTokenDto dto)
        {
            // Valida que lleguen los datos
            if (dto != null && dto.email != null && dto.Password != null)
            {
                var user = await _actionBL_User.GetUserLoginAsync(dto.email, Encript.Seguridad.EncryptPassword(dto.Password));

                if (user != null)
                {
                    // Leemos el secret_key desde nuestro appseting
                    string secretKey = _configuration.GetValue<string>("SecretKey");
                    byte[] key = Encoding.ASCII.GetBytes(secretKey);

                    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.NameIdentifier, user.Data.IdUser),
                                new Claim(ClaimTypes.Name, user.Data.Email),
                        }),
                        // Nuestro token va a durar un día
                        Expires = DateTime.UtcNow.AddDays(15),
                        // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    // Generación del Token
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SecurityToken createdToken = tokenHandler.CreateToken(tokenDescriptor);

                    // llenar la información del modelo de respuesta
                    TokenResponse tokenResponse = new TokenResponse
                    {
                        token = tokenHandler.WriteToken(createdToken),
                        expires = tokenDescriptor.Expires.Value,
                        login = user.Data.Email,
                        FullName = user.Data.FullName,
                        idUser = user.Data.IdUser,
                    };


                    responseModel = new ResponseModel()
                    {
                        response = true,
                        result = tokenResponse,
                        message = "OK"
                    };

                    return Ok(responseModel);

                }
                else
                {
                    responseModel = new ResponseModel()
                    {
                        message = "Invalid credentials"
                    };
                    return Ok(responseModel);
                }
            }
            else
            {
                responseModel = new ResponseModel()
                {
                    message = $"Other Error in Authentication \n {dto.email}"
                };
                return Ok(responseModel);
            }
        }

    }
}