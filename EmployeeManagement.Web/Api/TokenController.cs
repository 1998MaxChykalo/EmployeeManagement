// using System;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using EmployeeManagement.Domain.Models.ViewModels;
// using EmployeeManagement.Infrastructure.UnitOfWork;
// using EmployeeManagement.Web.models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;

// namespace EmployeeManagement.Web.Api
// {
//     public class TokenController : Controller
//     {   
//         IUnitOfWork _unitOfWork;
//         public TokenController(IUnitOfWork unitOfWork)
//         {
//             _unitOfWork = unitOfWork;
//         }
//         [AllowAnonymous]
//         [Route("api/token")]
//         [HttpPost]
//         public async Task<IActionResult> Token(LoginViewModel loginVM)
//         {        

//             if (!ModelState.IsValid) return BadRequest("Token failed to generate");

//             var user = (loginVM.Password == "password" && loginVM.Email == "username");

//             if (!user) return Unauthorized();

//             //Add Claims
//             var claims = new[]
//             {
//                 new Claim(JwtRegisteredClaimNames.UniqueName, "data"),
//                 new Claim(JwtRegisteredClaimNames.Sub, "data"),
//                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//             };

//             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rlyaKithdrYVl6Z80ODU350md")); //Secret
//             var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//             var token = new JwtSecurityToken("me",
//                 "you",
//                 claims,
//                 expires: DateTime.Now.AddMinutes(30),
//                 signingCredentials: creds);

//             return Ok(new JsonWebToken()
//             {
//                 access_token = new JwtSecurityTokenHandler().WriteToken(token),
//                 expires_in = 600000,
//                 token_type = "bearer"
//             });
//         }
//         // private ITokenProvider _tokenProvider;

//         // public TokenController(ITokenProvider tokenProvider) // We'll create this later, don't worry.
//         // {
//         //     _tokenProvider = tokenProvider;
//         // }

//         // public JsonWebToken Get([FromQuery] string grant_type, [FromQuery] string username, [FromQuery] string password, [FromQuery] string refresh_token)
//         // {
//         //     // Authenticate depending on the grant type.
//         //     User user = grant_type == "refresh_token" ? GetUserByToken(refresh_token) : GetUserByCredentials(username, password);

//         //     if (user == null)
//         //         throw new UnauthorizedAccessException("No!");

//         //     int ageInMinutes = 20;  // However long you want...

//         //     DateTime expiry = DateTime.UtcNow.AddMinutes(ageInMinutes);

//         //     var token = new JsonWebToken {
//         //         access_token = _tokenProvider.CreateToken(user, expiry),
//         //         expires_in   = ageInMinutes * 60
//         //     };

//         //     if (grant_type != "refresh_token")
//         //         token.refresh_token = GenerateRefreshToken(user);

//         //     return token;
//         // }

//         // private User GetUserByToken(string refreshToken)
//         // {
//         //     // TODO: Check token against your database.
//         //     if (refreshToken == "test")
//         //         return new User { UserName = "test" };

//         //     return null;
//         // }

//         // private User GetUserByCredentials(string username, string password)
//         // {
//         //     // TODO: Check username/password against your database.
//         //     if (username == password)
//         //         return new User { UserName = username };

//         //     return null;
//         // }

//         // private string GenerateRefreshToken(User user)
//         // {
//         //     // TODO: Create and persist a refresh token.
//         //     return "test";
//         // }
//     }
// }