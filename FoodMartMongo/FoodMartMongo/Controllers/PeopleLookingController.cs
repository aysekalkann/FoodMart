using FoodMartMongo.Dtos.PeopleLookingDtos;
using FoodMartMongo.Services.PeopleLookingServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.Controllers
{
    public class PeopleLookingController : Controller
    {
        private readonly IPeopleLookingService _peopleLookingService;

        public PeopleLookingController(IPeopleLookingService peopleLookingService)
        {
            _peopleLookingService = peopleLookingService;
        }

        public async Task <IActionResult> PeopleLookingList()
        {
            var values=await _peopleLookingService.GetAllPeopleLookingAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreatePeopleLooking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePeopleLooking(CreatePeopleLookingDto createPeopleLookingDto)
        {
            await _peopleLookingService.CreatePeopleLookingAsync(createPeopleLookingDto);
            return RedirectToAction("PeopleLookingList");
        }
        public async Task<IActionResult>DeletePeopleLooking(string id)
        {
            await _peopleLookingService.DeletePeopleLookingAsync(id);
            return RedirectToAction("PeopleLookingList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePeopleLooking(string id)
        {
            var value = await _peopleLookingService.GetPeopleLookingByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePeopleLooking(UpdatePeopleLookingDto updatePeopleLookingDto)
        {
            await _peopleLookingService.UpdatePeopleLookingAsync(updatePeopleLookingDto);
            return RedirectToAction("PeopleLookingList");
        }
    }
}
