using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _MailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}