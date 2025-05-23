using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services;
using SSH_FrontEnd.Services.IServices;
using SSH_FrontEnd.VM.Client;
using SSH_FrontEnd.VM.EventVM;
using System.Security.Claims;

[Authorize(Roles = "client")] 
public class ClientController : Controller
{
    private readonly IEventServices _eventService;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public ClientController(IEventServices eventService,IMapper mapper)
    {
        _eventService = eventService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Dashboard()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var response = await _eventService.GetAllAsync<APIResponse>();

        var model = new ClientDashboardViewModel
        {
            WelcomeMessage = $"Welcome, {User.Identity?.Name ?? "Client"}",
            UpcomingEvents = new List<MyEventsViewModel>()
        };

        if (response != null && response.IsSuccess && response.Result is not null)
        {
            var json = JsonConvert.SerializeObject(response.Result);
            var events = JsonConvert.DeserializeObject<List<EventDTO>>(json);

            
            var userEvents = events
                .Where(e => e.ApplicationUserId == userId)
                .ToList();

            model.UpcomingEvents = userEvents.Select(e => new MyEventsViewModel
            {
                EventId = e.EventId,
                EventName = e.EventName,
                EventType = e.EventType,
                EventDate = e.EventDate,
                VenueName = "TBD",     
                Status = "Scheduled"   
            }).ToList();
        }

        return View(model);
    }
    public async Task<IActionResult> MyEvents()
    {
        var token = User.FindFirst("access_token")?.Value;
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        var allEventsDto = await _eventService.GetAllAsync<List<EventDTO>>();

        // Option 1: Use AutoMapper to map DTO to ViewModel
        var allEventsVM = _mapper.Map<List<MyEventsViewModel>>(allEventsDto);

        // Filter to only this user's events
        var myEvents = allEventsVM.Where(e => e.ApplicationUserId == userId).ToList();

        return View("My_Events", myEvents);
    }

    public async Task<IActionResult> Profile()
    {
        var user = User;

        if (user == null || !user.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }

        var token = user.FindFirst("access_token")?.Value;
        var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            return RedirectToAction("Login", "Account");
        }

        var userDto = await _userService.GetAsync(userId, token);

        if (userDto == null)
        {
            return NotFound("User not found");
        }

        var profileVM = _mapper.Map<ProfileViewModel>(userDto);

        return View("Profile",profileVM);
    }


}
