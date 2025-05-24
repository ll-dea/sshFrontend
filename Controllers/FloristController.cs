using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Controllers
{
    public class FloristsController : Controller
    {
        private readonly IFloristService _floristService;

        public FloristsController(IFloristService floristService)
        {
            _floristService = floristService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _floristService.GetAllAsync<APIResponse>();
            var list = new List<FloristDTO>();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<FloristDTO>>(response.Result.ToString());
            }

            return View(list);
        }

        // ✅ GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // ✅ POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FloristDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _floristService.CreateAsync<APIResponse>(dto);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Failed to create florist");
            return View(dto);
        }

        // ✅ GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _floristService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<FloristDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }

        // ✅ POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FloristDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _floristService.UpdateAsync<APIResponse>(dto);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Failed to update florist");
            return View(dto);
        }

        // ✅ GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _floristService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<FloristDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }

        // ✅ POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var token = HttpContext.Session.GetString("JWTToken");
            var response = await _floristService.DeleteAsync<APIResponse>(id, token);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(Index));

            return NotFound();
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _floristService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<FloristDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }
    }
}
