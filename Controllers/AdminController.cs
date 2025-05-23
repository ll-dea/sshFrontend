using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using SSH_FrontEnd.VM.Admin;
using System.Security.Claims;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IEventServices _eventService;
    private readonly IUserService _userService;

    public AdminController(IEventServices eventService, IUserService userService)
    {
        _eventService = eventService;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var token = HttpContext.Session.GetString("JWTToken");

        var model = new AdminDashboardViewModel
        {
            TotalUsers = 0,
            TotalEvents = 0,
            EventStats = new List<AdminEventStatsViewModel>()
        };

        // Fetch users  
        var userResponse = await _userService.GetAllAsync<APIResponse>(token); // Explicitly specify the type argument  
        if (userResponse != null && userResponse.IsSuccess && userResponse.Result is not null)
        {
            var json = JsonConvert.SerializeObject(userResponse.Result);
            var users = JsonConvert.DeserializeObject<List<ApplicationUserDTO>>(json);
            model.TotalUsers = users.Count;
        }

        // Fetch events  
        var eventResponse = await _eventService.GetAllAsync<APIResponse>();
        if (eventResponse != null && eventResponse.IsSuccess && eventResponse.Result is not null)
        {
            var json = JsonConvert.SerializeObject(eventResponse.Result);
            var events = JsonConvert.DeserializeObject<List<EventDTO>>(json);

            model.TotalEvents = events.Count;
            model.EventStats = events
                .GroupBy(e => e.EventType)
                .Select(g => new AdminEventStatsViewModel
                {
                    EventType = g.Key,
                    Count = g.Count()
                })
                .ToList();
        }

        return View(model);
    }
    public async Task<IActionResult> Users()
    {
        var token = HttpContext.Session.GetString("JWTToken");
        var response = await _userService.GetAllAsync<APIResponse>(token);

        if (response != null && response.IsSuccess)
        {
            var userList = JsonConvert.DeserializeObject<List<ApplicationUserDTO>>(Convert.ToString(response.Result));
            return View(userList);
        }

        return View(new List<ApplicationUserDTO>());
    }

}
