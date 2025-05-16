using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using SSH_FrontEnd.VM.EventVM;
using Utility;

[Authorize(Roles = "client")]
public class EventController : Controller
{
    private readonly IEventServices _eventService;
    private readonly IVenueService _venueService;
    private readonly IFloristService _floristService;

    public EventController(IEventServices eventService, IVenueService venueService, IFloristService floristService)
    {
        _eventService = eventService;
        _venueService = venueService;
        _floristService = floristService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var model = new EventCreateVM
        {
            Venues = await LoadVenuesAsync(),
            Florists = await LoadFloristsAsync()
        };

        return View("CreateEvent", model); // make sure your .cshtml is named CreateEvent.cshtml
    }

    [HttpPost]
    public async Task<IActionResult> Create(EventCreateVM model)
    {
        if (!ModelState.IsValid)
        {
            model.Venues = await LoadVenuesAsync();
            model.Florists = await LoadFloristsAsync();
            return View("CreateEvent", model);
        }

        var eventDto = new EventDTO
        {
            EventName = model.EventName,
            EventType = model.EventType,
            EventDate = model.EventDate
        };

        var response = await _eventService.CreateAsync<APIResponse>(eventDto);

        if (response != null && response.IsSuccess)
        {
            return RedirectToAction("MyEvents");
        }

        ModelState.AddModelError("", "Failed to create event.");
        model.Venues = await LoadVenuesAsync();
        model.Florists = await LoadFloristsAsync();
        return View("CreateEvent", model);
    }

    private async Task<IEnumerable<SelectListItem>> LoadVenuesAsync()
    {
        var apiResponse = await _venueService.GetAllAsync<APIResponse>();

        if (apiResponse.IsSuccess && apiResponse.Result is not null)
        {
            var json = JsonConvert.SerializeObject(apiResponse.Result);
            var venues = JsonConvert.DeserializeObject<List<Venue>>(json);
            return venues.Select(v => new SelectListItem { Value = v.VenueId.ToString(), Text = v.Name });
        }

        return Enumerable.Empty<SelectListItem>();
    }

    private async Task<IEnumerable<SelectListItem>> LoadFloristsAsync()
    {
        var apiResponse = await _floristService.GetAllAsync<APIResponse>();

        if (apiResponse.IsSuccess && apiResponse.Result is not null)
        {
            var json = JsonConvert.SerializeObject(apiResponse.Result);
            var florists = JsonConvert.DeserializeObject<List<Florist>>(json);
            return florists.Select(f => new SelectListItem { Value = f.FloristId.ToString(), Text = f.Name });
        }

        return Enumerable.Empty<SelectListItem>();
    }
}
