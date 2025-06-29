using FoodMartMongo.Dtos.ProductDto;
using FoodMartMongo.Services.CategoryServices;
using FoodMartMongo.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace FoodMartMongo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // Ürünlerin listesini görüntüleme
        public async Task<IActionResult> ProductList()
        {
            var products = await _productService.GetAllProductsAsync();  // Ürünleri alıyoruz
            var categories = await _categoryService.GetAllCategoryAsync(); // Kategorileri alıyoruz

            // Kategorileri Dictionary'ye dönüştürmeden önce 'null' değerleri kontrol edelim
            var categoryDict = categories
                .Where(c => c.CategoryId != null)  // Null olmayan CategoryId'leri alıyoruz
                .ToDictionary(c => c.CategoryId, c => c.CategoryName);

            // Ürünler ile kategorileri ilişkilendiriyoruz
            var productsWithCategoryNames = products.Select(product => new FoodMartMongo.Dtos.ProductDto.ProductWithCategoryDto
            {
                Product = product,
                CategoryName = product.CategoryId != null && categoryDict.ContainsKey(product.CategoryId)
                    ? categoryDict[product.CategoryId]
                    : "Bilinmiyor"
            }).ToList();
            ;

            return View(productsWithCategoryNames);  // View'e doğru tipte model gönderiyoruz
        }




        // Yeni ürün oluşturma (GET)
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _categoryService.GetAllCategoryAsync(); // Kategorileri alıyoruz
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId
            }).ToList(); // Kategorileri ViewBag'e gönderiyoruz
            return View();
        }

        // Yeni ürün oluşturma (POST)
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (ModelState.IsValid) // Eğer model geçerliyse
            {
                createProductDto.Status = true; // Ürün durumu aktif yapılıyor
                await _productService.CreateProductAsync(createProductDto); // Ürünü ekliyoruz
                return RedirectToAction("ProductList"); // Ürünler listesine yönlendiriyoruz
            }
            // Hata durumunda tekrar aynı sayfaya yönlendiriyoruz
            return View(createProductDto);
        }

        // Ürün güncelleme (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var product = await _productService.GetProductByIdAsync(id); // Ürünü id'ye göre alıyoruz
            var categories = await _categoryService.GetAllCategoryAsync(); // Kategorileri alıyoruz

            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId
            }).ToList(); // Kategorileri ViewBag'e gönderiyoruz

            return View(product); // Ürün bilgisi ile güncelleme formunu döndürüyoruz
        }

        // Ürün güncelleme (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (ModelState.IsValid) // Eğer model geçerliyse
            {
                await _productService.UpdateProductAsync(updateProductDto); // Ürünü güncelliyoruz
                return RedirectToAction("ProductList"); // Ürünler listesine yönlendiriyoruz
            }
            return View(updateProductDto); // Geçerli değilse güncellenmiş veriyi tekrar gönderiyoruz
        }
    }
}
