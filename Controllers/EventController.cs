using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.Common;
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
    private readonly IMapper _mapper;
    private readonly IMusicProviderService _musicService;
   
    private readonly IPastryService _pastryService;


    public EventController(IEventServices eventService, IVenueService venueService, IFloristService floristService, IMapper mapper, IMusicProviderService musicProviderService,  IPastryService pastryService)
    {
        _eventService = eventService;
        _venueService = venueService;
        _floristService = floristService;
        _mapper = mapper;
        _musicService = musicProviderService;
      
        _pastryService = pastryService;
    }

    public async Task<IActionResult> IndexEvent()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        List<EventDTO> list = new();
        var response = await _eventService.GetAllAsync<APIResponse>();
        if (response != null && response.IsSuccess && response.Result is not null)
        {
            list = JsonConvert.DeserializeObject<List<EventDTO>>(Convert.ToString(response.Result));
        }

        // ✅ Filter only events where ApplicationUserId == logged-in user ID
        list = list.Where(e => e.ApplicationUserId == userId).ToList();

        var mappedList = _mapper.Map<List<MyEventsViewModel>>(list);

        return View("~/Views/Client/MyEvents.cshtml", mappedList);
    }



    [HttpGet]
    
    public async Task<IActionResult> Create()
    {
        var model = new EventCreateVM
        {
            Venues = await LoadSelectListAsync<Venue>(_venueService),
            Florists = await LoadSelectListAsync<Florist>(_floristService),
            MusicProviders = await LoadSelectListAsync<MusicProvider>(_musicService),
           
            Pastries = await LoadSelectListAsync<Pastry>(_pastryService)

        };

        return View("CreateEvent", model);
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

    private async Task<IEnumerable<SelectListItem>> LoadSelectListAsync<TModel>(IBaseServices service)
    where TModel : class, IHasIdAndName
    {
        var response = await service.GetAllAsync<APIResponse>();

        if (response != null && response.IsSuccess && response.Result is not null)
        {
            var json = JsonConvert.SerializeObject(response.Result);
            var list = JsonConvert.DeserializeObject<List<TModel>>(json);

            return list.Select(item => new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.Name
            });
        }

        return Enumerable.Empty<SelectListItem>();
    }

}
