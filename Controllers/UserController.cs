using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
namespace SSH_FrontEnd.Controllers
{

    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("login")]
        public IActionResult Login() => View();

       // [HttpPost("login")]
        //public async Task<IActionResult> Login(LoginDto loginDto)
        //{
          //  var user = await _userService.AuthenticateAsync(loginDto.Username, loginDto.Password);
            //if (user == null)
            //{
              //  ModelState.AddModelError("", "Invalid credentials");
              //  return View();
            //}

            //// Set authentication cookie or session
            //return RedirectToAction("Dashboard");
        //}

        [HttpGet("signup")]
        public IActionResult Signup() => View();

        [HttpGet("events")]
        public IActionResult Events() => View();

        [HttpGet("bookings")]
        public IActionResult Bookings() => View();

        [HttpGet("dashboard")]
        public IActionResult Dashboard() => View();


        //[HttpPost("signup")]
        //public async Task<IActionResult> Signup(RegisterDto registerDto)
        //{
        //  if (!ModelState.IsValid)
        //    return View();

        //await _userService.RegisterAsync(registerDto);
        //return RedirectToAction("Login");
        //}

        //[HttpGet("dashboard")]
        //public async Task<IActionResult> Dashboard()
        //{
        //  var userId = GetCurrentUserId();
        //var user = await _userService.GetUserByIdAsync(userId);
        //return View(user);
        //}

        //[HttpGet("bookings")]
        //public async Task<IActionResult> Bookings()
        //{
        // var userId = GetCurrentUserId();
        //var bookings = await _userService.GetUserBookingsAsync(userId);
        //return View(bookings);
        //}

        //[HttpGet("events")]
        //public async Task<IActionResult> Events()
        //{
        //  var userId = GetCurrentUserId();
        //var events = await _userService.GetUserEventsAsync(userId);
        //return View(events);
        //}

        //private int GetCurrentUserId()
        //{
        // Retrieve user ID from session or authentication context
        //}
    }
}
