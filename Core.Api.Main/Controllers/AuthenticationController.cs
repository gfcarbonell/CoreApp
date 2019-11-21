using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Api.Application.Contract.IServices;
using Core.Api.Application.Contract.IServices.Core;
using Core.Api.Business.Core;
using Core.Api.Business.Core.StoreProcedures;
using Core.Api.Business.StoreProcedures;
using Core.Api.Main.ViewModels.RequestModel;
using Core.Api.Main.ViewModels.RequestModel.Authentication;
using Core.Api.Main.ViewModels.ResponseModel;
using Core.Api.Main.ViewModels.ResponseModel.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Core.Api.Main.Controllers
{
    [Authorize]
    [Route("api/v1/authentication")]
    [Produces("application/json")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserService _userService;
        private readonly IUserSessionService _userSessionService;
        private readonly ISystemService _systemService;

        public AuthenticationController(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            ILogger<AuthenticationController> logger,
            IUserService userService,
            IUserSessionService userSessionService,
            ISystemService systemService,
            IMapper mapper

            )
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _userService = userService;
            _userSessionService = userSessionService;
            _systemService = systemService;
            _mapper = mapper;
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// <param name="request"></param>
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationModelRequest Request)
        {
            var response = new AuthenticationModelResponse();
            response.UrlApi = HttpContext.Request.Path.Value;
            try
            {
                if(Request.Login == null)
                {
                    response.ErrorCode = -1;
                    response.ErrorMessage = "Request! inválido.";
                    response.Success = false;
                    return BadRequest(response);
                }

                var RemoteIpAddress = HttpContext.Connection.RemoteIpAddress;
                string IPAddress = RemoteIpAddress.MapToIPv4().ToString().Trim();
                string Hostname = Dns.GetHostEntry(RemoteIpAddress).HostName.Trim();

                // Verify User
                User User = await _userService.Login(new sp_login()
                {
                    Username = Request.Login.Username,
                    Password = Request.Login.Password,
                    IPAddress = IPAddress,
                    Hostname = Hostname
                });

                if (User.ID <= 0)
                {
                    response.ErrorCode = -1;
                    response.ErrorMessage = "Usuario no identificado.";
                    response.Success = false;
                    return NotFound(response);
                }

                // Date
                var Now = DateTime.Now;
                var ExpiresDate = Now.AddMinutes(int.Parse(_configuration["JWT:Expires"]));

                // Create Token
                string Token = this.GetToken(new User()
                {
                    Username = Request.Login.Username
                }, Now, ExpiresDate);

                if (Token == null)
                {
                    response.ErrorCode = -1;
                    response.ErrorMessage = "El Token de seguridad no fue creado correctamente.";
                    response.Success = false;
                    return StatusCode(500, response);
                }

                // Add Session
                UserSession userSession = await _userSessionService.Add(new UserSession()
                {
                    UserID = User.ID,
                    Token = Token,
                    NotBeforeDate = Now,
                    ExpiresDate = ExpiresDate,
                    LoginDate = Now,
                    LogoutDate = null,
                    StateID = 1,
                    CreatedBy = User.ID,
                    CreateDate = Now,
                    HostnameCreated = Hostname,
                    IPAddressCreated = IPAddress,
                    UpdatedBy = User.ID,
                    UpdateDate = Now,
                    HostnameUpdated = Hostname,
                    IPAddressUpdated = IPAddress
                });

                IEnumerable<Business.Core.System> systems = await _systemService.GetByUser(User.ID);

                // Response
                response.Login = _mapper.Map<LoginModelResponse>(userSession);
                response.User = _mapper.Map<UserModelResponse>(User);
                response.Systems = _mapper.Map<ICollection<SystemModelResponse>>(systems);
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Error: {ex.Message}";
                response.Success = false;
                return StatusCode(500, response);
            }
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// <param name="request"></param>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(401)]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] AuthenticationModelRequest Request)
        {
            var response = new AuthenticationModelResponse();
            response.UrlApi = HttpContext.Request.Path.Value;

            try
            {
                if (Request.Logout == null)
                {
                    response.ErrorCode = -1;
                    response.ErrorMessage = "Request! inválido.";
                    response.Success = false;
                    return BadRequest(response);
                }

                var RemoteIpAddress = HttpContext.Connection.RemoteIpAddress;
                string IPAddress = RemoteIpAddress.MapToIPv4().ToString().Trim();
                string Hostname = Dns.GetHostEntry(RemoteIpAddress).HostName.Trim();

                var logout = await _userService.Logout(new sp_logout()
                {
                    Code = Request.Logout.Code,
                    IPAddress = IPAddress,
                    Hostname = Hostname
                });

                response.Logout = _mapper.Map<LogoutModelResponse>(logout);
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Error: {ex.Message}";
                response.Success = false;
                return StatusCode(500, response);
            }
        }
        private string GetToken(User user, DateTime notBefore, DateTime expires)
        {
            try
            {
                var Jti = Guid.NewGuid().ToString();

                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Jti),
                    new Claim(JwtRegisteredClaimNames.Iat, notBefore.ToString(), ClaimValueTypes.Integer)
                };
       
                var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
                var issuer = _configuration["JWT:Issuer"];
                var audience = _configuration["JWT:Audience"];
                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

                var jwt = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    notBefore: notBefore,
                    expires: expires,
                    signingCredentials: credentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);
                return token;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}