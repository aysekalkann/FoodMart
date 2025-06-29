using FoodMartMongo.Dtos.ProductDto;

namespace FoodMartMongo.Controllers
{
    internal class ProductWithCategoryDto
    {
        public ResultProductDto Product { get; set; }
        public string CategoryName { get; set; }
    }
}