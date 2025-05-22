using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using SSH_FrontEnd.VM.Client;

namespace SSH_FrontEnd.Controllers
{
    public class PastryController : Controller
    {
        private readonly IPastryService _pastryService;
        private readonly IPastryShopService _pastryShopService;
        private readonly IPastryTypeService _pastryTypeService;

        public PastryController(IPastryService pastryService, IPastryShopService pastryShopService, IPastryTypeService pastryTypeService)
        {
            _pastryService = pastryService;
            _pastryShopService = pastryShopService;
            _pastryTypeService = pastryTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var pastryResponse = await _pastryService.GetAllAsync<APIResponse>();
            var shopResponse = await _pastryShopService.GetAllAsync<APIResponse>();
            var typeResponse = await _pastryTypeService.GetAllAsync<APIResponse>();

            var pastries = JsonConvert.DeserializeObject<List<PastryDTO>>(Convert.ToString(pastryResponse.Result));
            var shops = JsonConvert.DeserializeObject<List<PastryShopDTO>>(Convert.ToString(shopResponse.Result));
            var types = JsonConvert.DeserializeObject<List<PastryTypeDTO>>(Convert.ToString(typeResponse.Result));

            var mergedList = pastries.Select(p =>
            {
                var shop = shops.FirstOrDefault(s => s.ShopId == p.ShopId);
                var type = types.FirstOrDefault(t => t.PastryTypeId == p.PastryTypeId);

                return new PastryCombinedViewModel
                {
                    PastryId = p.PastryId,
                    Name = p.PastryName,
                    ShopName = shop?.ShopName ?? "Unknown Shop",
                    TypeName = type?.TypeName ?? "Unknown Type"
                };
            }).ToList();

            return View(mergedList);
        }
    }


}
