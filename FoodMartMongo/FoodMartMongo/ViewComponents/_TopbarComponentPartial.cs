using FoodMartMongo.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _TopbarComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _TopbarComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task <IViewComponentResult> InvokeAsync()
        {
            var values=await _categoryService.GetAllCategoryAsync();
            return View(values);  
        }
    }
}
