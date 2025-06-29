using FoodMartMongo.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _ProductComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
       public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _productService.GetAllProductsAsync();
            return View(values);
        }
    }
}
