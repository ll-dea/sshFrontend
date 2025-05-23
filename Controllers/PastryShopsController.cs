using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Controllers
{
    public class PastryShopsController : Controller
    {
        private readonly IPastryShopService _pastryService;

        public PastryShopsController(IPastryShopService pastryService)
        {
            _pastryService = pastryService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _pastryService.GetAllAsync<APIResponse>();
            var list = new List<PastryShopDTO>();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<PastryShopDTO>>(response.Result.ToString());
            }

            return View(list);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _pastryService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<PastryShopDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PastryShopDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var token = HttpContext.Session.GetString("JWTToken");
            var response = await _pastryService.UpdateAsync<APIResponse>(dto, token);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Failed to update pastry shop");
            return View(dto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PastryShopDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var token = HttpContext.Session.GetString("JWTToken");
            var response = await _pastryService.CreateAsync<APIResponse>(dto, token); // Make sure this overload exists

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Failed to create pastry shop");
            return View(dto);
        }

        

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _pastryService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<PastryShopDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var token = HttpContext.Session.GetString("JWTToken");
            var response = await _pastryService.DeleteAsync<APIResponse>(id, token);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            return NotFound();
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _pastryService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<PastryShopDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }
    }
}
