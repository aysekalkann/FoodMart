using FoodMartMongo.Services.PeopleLookingServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _PeopleLookingComponentPartial:ViewComponent
    {
        private readonly IPeopleLookingService _peopleLookingService;

        public _PeopleLookingComponentPartial(IPeopleLookingService peopleLookingService)
        {
            _peopleLookingService = peopleLookingService;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var values=await _peopleLookingService.GetAllPeopleLookingAsync();
            return View(values);
        }
    }
}
