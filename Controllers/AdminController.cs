using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services;
using SSH_FrontEnd.Services.IServices;
using SSH_FrontEnd.VM.Admin;
using System.Security.Claims;

[Authorize(Roles = "admin")]
public class AdminController : Controller
{
    private readonly IPastryShopService _pastryService;
    private readonly IFloristService _floristService;
    private readonly IMusicProviderService _musicService;
    private readonly IVenueProviderService _venueService;
    private readonly IMenuService _menuService;
    private readonly IEventServices _eventServices; // Add this missing field  
    private readonly IUserService _userService; // Add this missing field  

    public AdminController(
        IEventServices eventService,
        IUserService userService,
        IPastryShopService pastryService,
        IFloristService floristService,
        IMusicProviderService musicService,
        IVenueProviderService venueService,
        IMenuService menuService)
    {
        _eventServices = eventService;
        _userService = userService;
        _pastryService = pastryService;
        _floristService = floristService;
        _musicService = musicService;
        _venueService = venueService;
        _menuService = menuService;
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
        var eventResponse = await _eventServices.GetAllAsync<APIResponse>();
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



    public async Task<IActionResult> ProviderDropdown()
    {
        var model = new AdminProviderSelectionVM
        {
            PastryShops = await _pastryService.GetAllAsync<List<PastryShopDTO>>(),
            Florists = await _floristService.GetAllAsync<List<FloristDTO>>(),
            MusicProviders = await _musicService.GetAllAsync<List<MusicProviderDTO>>(),
            VenueProviders = await _venueService.GetAllAsync<List<VenueProviderDTO>>(),
            Menus = await _menuService.GetAllAsync<List<MenuDTO>>()
        };

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
