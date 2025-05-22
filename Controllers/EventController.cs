using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using SSH_FrontEnd.VM.EventVM;
using Utility;

namespace SSH_FrontEnd.Controllers
{
    [Authorize(Roles = "client")]
    public class EventController : Controller
    {
        private readonly IEventServices _eventService;
        private readonly IVenueProviderService _venueProviderService;
        private readonly IVenueService _venueService;
        private readonly IVenueOrderService _venueOrderService;

        private readonly IFloristService _floristService;
        private readonly IFlowerArrangmentService _flowerService;
        private readonly IFlowerArrangmentOrderService _flowerOrderService;

        private readonly IMusicProviderService _musicService;
        private readonly IMusicProviderOrderService _musicOrderService;
        private readonly IPlaylistItemService _playlistService;

        private readonly IMenuService _menuService;
        private readonly IMenuOrderService _menuOrderService;

        private readonly IPastryShopService _pastryShopService;
        private readonly IPastryService _pastryService;
        private readonly IPastryOrderService _pastryOrderService;

        private readonly IMapper _mapper;

        public EventController(
            IEventServices eventService,
            IVenueProviderService venueProviderService,
            IVenueService venueService,
            IVenueOrderService venueOrderService,
            IFloristService floristService,
            IFlowerArrangmentService flowerService,
            IFlowerArrangmentOrderService flowerOrderService,
            IMusicProviderService musicService,
            IMusicProviderOrderService musicOrderService,
            IPlaylistItemService playlistService,
            IMenuService menuService,
            IMenuOrderService menuOrderService,
            IPastryShopService pastryShopService,
            IPastryService pastryService,
            IPastryOrderService pastryOrderService,
            IMapper mapper)
        {
            _eventService = eventService;
            _venueProviderService = venueProviderService;
            _venueService = venueService;
            _venueOrderService = venueOrderService;

            _floristService = floristService;
            _flowerService = flowerService;
            _flowerOrderService = flowerOrderService;

            _musicService = musicService;
            _musicOrderService = musicOrderService;
            _playlistService = playlistService;

            _menuService = menuService;
            _menuOrderService = menuOrderService;

            _pastryShopService = pastryShopService;
            _pastryService = pastryService;
            _pastryOrderService = pastryOrderService;

            _mapper = mapper;
        }

    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFinal(EventCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Florists = await _floristService.GetAllAsync<List<FloristDTO>>();
                model.PastryShops = await _pastryShopService.GetAllAsync<List<PastryShopDTO>>();
                model.VenueProviders = await _venueProviderService.GetAllAsync<List<VenueProviderDTO>>();
                model.MusicProviders = await _musicService.GetAllAsync<List<MusicProviderDTO>>();
                model.Menus = await _menuService.GetAllAsync<List<MenuDTO>>();
                return View("CreateEvent", model);
            }

            var createdEvent = await _eventService.CreateAsync<EventDTO>(model.Event);
            if (createdEvent == null)
            {
                ModelState.AddModelError("", "Could not create event.");
                return View("CreateEvent", model);
            }

            int eventId = createdEvent.EventId;

            // BOOKED PASTRIES
            // BOOKED PASTRY SHOPS
            foreach (var shopId in model.BookedPastryShopIds)
            {
                var pastries = await _pastryService.GetAllAsync<List<PastryDTO>>();
                var shopPastries = pastries.Where(p => p.ShopId == shopId).ToList();

                foreach (var pastry in shopPastries)
                {
                    var dto = new PastryOrderDTO
                    {
                        OrderName = pastry.PastryName,
                        OrderPrice = pastry.Price,
                        AgencyFee = 0,
                        OrderDescription = $"Auto-booked from event {eventId}",
                        Notes = "",
                        EventId = eventId
                    };
                    await _pastryOrderService.CreateAsync<APIResponse>(dto);
                }
            }


            // BOOKED MENUS
            //foreach (var id in model.BookedMenuIds)
            //{
            //    var menu = await _menuService.GetAsync<MenuDTO>(id);
            //    var dto = new MenuOrderDTO
            //    {
            //        OrderName = menu.MenuName,
            //        OrderPrice = menu.Price,
            //        AgencyFee = 0,
            //        Allergents = "",
            //        IngreedientsForbiddenByReligion = "",
            //        AdditionalRequests = "",
            //        EventId = eventId
            //    };
            //    await _menuOrderService.CreateAsync<APIResponse>(dto);
            //}

            // BOOKED VENUES
            // BOOKED VENUE PROVIDERS
            foreach (var providerId in model.BookedVenueProviderIds)
            {
                var venues = await _venueService.GetAllAsync<List<VenueDTO>>();
                var providerVenues = venues.Where(v => v.VenueProviderId == providerId).ToList();

                foreach (var venue in providerVenues)
                {
                    var dto = new VenueOrderDTO
                    {
                        VenueId = venue.VenueId,
                        Name = venue.Name,
                        Description = venue.Description,
                        Price = venue.Price,
                        Address = venue.Address,
                        AgencyFee = 0,
                        Notes = "",
                        EventId = eventId
                    };
                    await _venueOrderService.CreateAsync<APIResponse>(dto);
                }
            }


            // BOOKED FLORISTS
            foreach (var id in model.BookedFloristIds)
            {
                var flowers = await _flowerService.GetAllAsync<List<FlowerArrangementDTO>>();
                var floristFlowers = flowers.Where(f => f.FloristId == id);
                foreach (var f in floristFlowers)
                {
                    var dto = new FlowerArrangementOrderDTO
                    {
                        OrderName = f.Name,
                        OrderPrice = f.Price,
                        AgencyFee = 0,
                        OrderDescription = f.Description,
                        Notes = "",
                        EventId = eventId
                    };
                    await _flowerOrderService.CreateAsync<APIResponse>(dto);
                }
            }

            // BOOKED MUSIC PROVIDERS
            foreach (var id in model.BookedMusicProviderIds)
            {
                var music = await _musicService.GetAsync<MusicProviderDTO>(id);
                var dto = new MusicProviderOrderDTO
                {
                    OrderName = music.Name,
                    OrderPrice = music.BaseHourlyRate ?? 0,
                    AgencyFee = (double)(music.AgencyFee ?? 0),
                    Notes = "",
                    MusicProviderAddress = music.Address,
                    PhoneNumber = music.PhoneNumber,
                    Email = music.Email,
                    EventId = eventId
                };
                await _musicOrderService.CreateAsync<APIResponse>(dto);
            }


            TempData["success"] = "Event successfully created!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var floristRes = await _floristService.GetAllAsync<APIResponse>();
            var pastryRes = await _pastryShopService.GetAllAsync<APIResponse>();
            var venueRes = await _venueProviderService.GetAllAsync<APIResponse>();
            var musicRes = await _musicService.GetAllAsync<APIResponse>();
            var menuRes = await _menuService.GetAllAsync<APIResponse>();

            var vm = new EventCreateVM
            {
                Event = new EventDTO(),
                Florists = ExtractList<FloristDTO>(floristRes),
                PastryShops = ExtractList<PastryShopDTO>(pastryRes),
                VenueProviders = ExtractList<VenueProviderDTO>(venueRes),
                MusicProviders = ExtractList<MusicProviderDTO>(musicRes),
                Menus = ExtractList<MenuDTO>(menuRes)
            };

            return View("CreateEvent", vm);
        }

        private List<T> ExtractList<T>(APIResponse response)
        {
            if (response?.IsSuccess == true && response.Result != null)
            {
                return JsonConvert.DeserializeObject<List<T>>(response.Result.ToString());
            }
            return new List<T>();
        }

        [HttpGet]
        public async Task<IActionResult> GetPastryDetailsList()
        {
            var response = await _pastryShopService.GetAllAsync<APIResponse>();
            var list = ExtractList<PastryShopDTO>(response);
            return PartialView("_PastryDetailsList", list); // sends HTML to browser
        }
        [HttpGet]
        public async Task<IActionResult> GetMusicDetailsList()
        {
            var response = await _musicService.GetAllAsync<APIResponse>();
            var list = ExtractList<MusicProviderDTO>(response);
            return PartialView("_MusicDetailsList", list);
        }
        [HttpGet]
        public async Task<IActionResult> GetVenueDetailsList()
        {
            var response = await _venueProviderService.GetAllAsync<APIResponse>();
            var list = ExtractList<VenueProviderDTO>(response);
            return PartialView("_VenueDetailsList", list);
        }
        [HttpGet]
        public async Task<IActionResult> GetFloristDetailsList()
        {
            var response = await _floristService.GetAllAsync<APIResponse>();
            var list = ExtractList<FloristDTO>(response);
            return PartialView("_FloristDetailsList", list);
        }
        [HttpGet]
        public async Task<IActionResult> GetMenuDetailsList()
        {
            var response = await _menuService.GetAllAsync<APIResponse>();
            var list = ExtractList<MenuDTO>(response);
            return PartialView("_MenuDetailsList", list);
        }
        public async Task<IActionResult> LoadPastryShopsWithPastries()
        {
            var shopResponse = await _pastryShopService.GetAllAsync<APIResponse>();
            var pastryResponse = await _pastryService.GetAllAsync<APIResponse>();

            var shops = JsonConvert.DeserializeObject<List<PastryShopDTO>>(Convert.ToString(shopResponse.Result));
            var pastries = JsonConvert.DeserializeObject<List<PastryDTO>>(Convert.ToString(pastryResponse.Result));

            // Manual frontend join
            foreach (var shop in shops)
            {
                shop.Pastries = pastries.Where(p => p.ShopId == shop.ShopId).ToList();
            }

            return PartialView("_PastryDetailsList", shops);
        }


    }
}
