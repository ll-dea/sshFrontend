using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using SSH_FrontEnd.Services.IServices;
using System.Collections.Generic;
namespace SSH_FrontEnd.Controllers.Client

{
    public class EventController: Controller
    {
        private readonly IEventServices _eventService;
        private readonly IMapper _mapper;
        public EventController(IEventServices eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexEvent()
        {
            List<EventDTO> list = new();
            var response = await _eventService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EventDTO>>(Convert.ToString(response.Result));
            }

            return View("~/Views/Client/Event/IndexEvent.cshtml", list);

        }
        public async Task<IActionResult> CreateEvent()
        {


            return View("~/Views/Client/Event/CreateEvent.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateEvent(EventDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _eventService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Event created successfully";
                    return RedirectToAction(nameof(IndexEvent));
                }
            }
            TempData["error"] = "Error encountered";

            return View("~/Views/Client/Event/CreateEvent.cshtml", model);

        }
        public async Task<IActionResult> UpdateEvent(int eventId)
        {
            var response = await _eventService.GetAsync<APIResponse>(eventId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Event updated successfully";

                EventDTO model = JsonConvert.DeserializeObject<EventDTO>(Convert.ToString(response.Result));
                return View("~/Views/Client/Event/UpdateEvent.cshtml", _mapper.Map<EventDTO>(model));
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdateEvent(EventDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _eventService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Event updated successfully";
                    return RedirectToAction(nameof(IndexEvent));
                }
            }
            TempData["error"] = "Error encountered";

            return View("~/Views/Client/Event/UpdateEvent.cshtml", model);


        }
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            var response = await _eventService.GetAsync<APIResponse>(eventId);
            if (response != null && response.IsSuccess)
            {
                var jsonResult = Convert.ToString(response.Result);
                var model = JsonConvert.DeserializeObject<EventDTO>(jsonResult);

                if (model == null)
                {
                    TempData["error"] = "Failed to deserialize event data.";
                    return NotFound();
                }

                return View("~/Views/Client/Event/DeleteEvent.cshtml", model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteEvent(EventDTO model)
        {

            var response = await _eventService.DeleteAsync<APIResponse>(model.EventId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Event deleted successfully";
                return RedirectToAction(nameof(IndexEvent));
            }
            TempData["error"] = "Error encountered";
            return View(model);

        }
    }
}
