using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using SSH_FrontEnd.VM.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Utility;

namespace SSH_FrontEnd.Controllers
{
    

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

      
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var loginDto = new LoginRequestDTO
            {
                UserName = model.Email,
                Password = model.Password
            };

            var response = await _authService.LoginAsync<APIResponse>(loginDto);

            if (response != null && response.IsSuccess && response.Result is not null)
            {
                // Extract JWT from response
                var json = JsonConvert.SerializeObject(response.Result);
                var loginResponse = JsonConvert.DeserializeObject<LoginResponseDTO>(json);
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(loginResponse.Token);

                // Extract and normalize claims
                var claims = token.Claims.ToList();

                // Normalize "role" -> ClaimTypes.Role
                var roleClaim = claims.FirstOrDefault(c => c.Type == "role")?.Value;
                if (!string.IsNullOrEmpty(roleClaim))
                {
                    claims.Add(new Claim(ClaimTypes.Role, roleClaim));
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Redirect based on role
                var userRole = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value?.ToLower();

                if (userRole == "admin")
                    return RedirectToAction("Dashboard", "Admin");
                else if (userRole == "client")
                    return RedirectToAction("Dashboard", "Client");

                return RedirectToAction("Index", "Home"); // fallback
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }



        [HttpGet]
        public IActionResult Register()

        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var registerDto = new RegisterationRequestDTO
            {
                Name = model.Name,
                UserName = model.Email,
                Password = model.Password,
                Role = "client" // or assign dynamically
            };

            var response = await _authService.RegisterAsync<APIResponse>(registerDto);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Registration failed.");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

    }

}
