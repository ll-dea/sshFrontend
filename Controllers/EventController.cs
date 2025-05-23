using Microsoft.AspNetCore.Mvc;

using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Models.ViewModels;
using SSH_FrontEnd.Services.IServices;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.VM.EventVM;

public class EventController : Controller
{
    private readonly IEventServices _eventService;
    private readonly IVenueProviderService _venueService;
    private readonly IMusicProviderService _musicService;
    private readonly IFloristService _floristService;
    private readonly IPastryShopService _pastryService;
    private readonly IVenueOrderService _venueOrderService;
    private readonly IPastryOrderService _pastryOrderService;
    private readonly IMusicProviderOrderService _musicProviderOrderService;
    private readonly IFlowerArrangmentOrderService _flowerArrangementOrderService;

    public EventController(
        IEventServices eventService,
        IVenueProviderService venueService,
        IMusicProviderService musicService,
        IFloristService floristService,
        IPastryShopService pastryService,
        IVenueOrderService venueOrderService,
        IPastryOrderService pastryOrderService,
        IMusicProviderOrderService musicProviderOrderService,
        IFlowerArrangmentOrderService flowerArrangementOrderService)
    {
        _eventService = eventService;
        _venueService = venueService;
        _musicService = musicService;
        _floristService = floristService;
        _pastryService = pastryService;
        _venueOrderService = venueOrderService;
        _pastryOrderService = pastryOrderService;
        _musicProviderOrderService = musicProviderOrderService;
        _flowerArrangementOrderService = flowerArrangementOrderService;
    }

    // GET: Create event form
    public async Task<IActionResult> Create()
    {
        var model = new EventCreateVM
        {
            Venues = await _venueService.GetAllAsync<List<VenueProvider>>(),
            MusicProviders = await _musicService.GetAllAsync<List<MusicProvider>>(),
            Florists = await _floristService.GetAllAsync<List<Florist>>(),
            PastryShops = await _pastryService.GetAllAsync<List<PastryShop>>()
        };

        return View("CreateEvent", model);
    }


    // POST: Save event and orders
    [HttpPost]
    public async Task<IActionResult> Create(EventCreateVM model)
    {
        model.Event.ApplicationUserId = User.FindFirst(System.Security.Claims.ClaimTypes.Sid)?.Value;

        if (!ModelState.IsValid)
        {
            // repopulate lists before returning
            model.Venues = await _venueService.GetAllAsync<List<VenueProvider>>();
            model.MusicProviders = await _musicService.GetAllAsync<List<MusicProvider>>();
            model.Florists = await _floristService.GetAllAsync<List<Florist>>();
            model.PastryShops = await _pastryService.GetAllAsync<List<PastryShop>>();
            return View("CreateEvent", model);
        }

        // Save event
        var createdEvent = await _eventService.CreateAsync<EventDTO>(model.Event);

        // Save provider orders
        await _venueOrderService.CreateAsync<APIResponse>(new VenueOrderDTO
        {
            EventId = createdEvent.EventId,
            VenueOrderId = model.SelectedVenueId
        });

        await _musicProviderOrderService.CreateAsync<APIResponse>(new MusicProviderOrderDTO
        {
            EventId = createdEvent.EventId,
            MusicProviderId = model.SelectedMusicProviderId
        });

        await _flowerArrangementOrderService.CreateAsync<APIResponse>(new FlowerArrangementOrderDTO
        {
            EventId = createdEvent.EventId,
            FloristId = model.SelectedFloristId
        });

        await _pastryOrderService.CreateAsync<APIResponse>(new PastryOrderDTO
        {
            EventId = createdEvent.EventId,
            ShopId = model.SelectedPastryShopId
        });

        return RedirectToAction("Dashboard", "Client");
    }

}
