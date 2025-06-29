using FoodMartMongo.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _DiscountComponentPartial:ViewComponent
    {
        private readonly IDiscountService _discountService;

        public _DiscountComponentPartial(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _discountService.GetAllDiscountAsync();
            return View(values);
        }
    }
}
