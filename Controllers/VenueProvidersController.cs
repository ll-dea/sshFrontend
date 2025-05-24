// VenuesController.cs
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Controllers
{
    public class VenueProvidersController : Controller
    {
        private readonly IVenueService _venueService;

        public VenueProvidersController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _venueService.GetAllAsync<APIResponse>();
            var list = new List<VenueDTO>();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VenueDTO>>(response.Result.ToString());
            }

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VenueDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var response = await _venueService.CreateAsync<APIResponse>(dto);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Failed to create venue");
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _venueService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<VenueDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VenueDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var response = await _venueService.UpdateAsync<APIResponse>(dto);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Failed to update venue");
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _venueService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<VenueDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _venueService.DeleteAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            return NotFound();
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _venueService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<VenueDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }
    }
}
