// MenuController.cs
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using Utility;

namespace SSH_FrontEnd.Controllers
{
    public class MenusController : Controller
    {
        private readonly IMenuService _menuService;

        public MenusController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _menuService.GetAllAsync<APIResponse>();
            var list = new List<MenuDTO>();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<MenuDTO>>(response.Result.ToString());
            }

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var response = await _menuService.CreateAsync<APIResponse>(dto);

            if (response != null && response.IsSuccess)
            {
                TempData["Success"] = "Menu created successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Failed to create menu");
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _menuService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<MenuDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MenuDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var response = await _menuService.UpdateAsync<APIResponse>(dto);

            if (response != null && response.IsSuccess)
            {
                TempData["Success"] = "Menu updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Failed to update menu");
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _menuService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<MenuDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _menuService.DeleteAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                TempData["Success"] = "Menu deleted successfully!";
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _menuService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<MenuDTO>(response.Result.ToString());
                return View(model);
            }

            return NotFound();
        }
    }
}
