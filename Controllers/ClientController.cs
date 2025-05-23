using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using SSH_FrontEnd.VM.Client;
using SSH_FrontEnd.VM.EventVM;
using System.Security.Claims;

[Authorize(Roles = "CLIENT")] 
public class ClientController : Controller
{
    private readonly IEventServices _eventService;

    public ClientController(IEventServices eventService)
    {
        _eventService = eventService;
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
}
