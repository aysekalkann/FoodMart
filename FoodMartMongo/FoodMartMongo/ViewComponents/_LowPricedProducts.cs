using FoodMartMongo.Dtos.ProductDto;
using FoodMartMongo.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _LowPricedProducts : ViewComponent
    {
        private readonly IProductService _productService;

        public _LowPricedProducts(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allProducts = await _productService.GetAllProductsAsync() ?? new List<ResultProductDto>();

            var lowestPricedProducts = allProducts
                .OrderBy(p => p.Price)
                .Take(6)
                .ToList();

            return View(lowestPricedProducts);
        }
    }
}
