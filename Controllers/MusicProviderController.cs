// MusicProvidersController.cs
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Controllers
{
    public class MusicProvidersController : Controller
    {
        private readonly IMusicProviderService _musicService;

        public MusicProvidersController(IMusicProviderService musicService)
        {
            _musicService = musicService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _musicService.GetAllAsync<APIResponse>();
            var list = new List<MusicProviderDTO>();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<MusicProviderDTO>>(response.Result.ToString());
            }

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MusicProviderDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var response = await _musicService.CreateAsync<APIResponse>(dto);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Failed to create music provider");
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _musicService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<MusicProviderDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MusicProviderDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var response = await _musicService.UpdateAsync<APIResponse>(dto);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Failed to update music provider");
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _musicService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<MusicProviderDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _musicService.DeleteAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            return NotFound();
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _musicService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<MusicProviderDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }
    }
}
