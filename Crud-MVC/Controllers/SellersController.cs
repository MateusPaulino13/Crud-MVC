using Microsoft.AspNetCore.Mvc;

namespace Crud_MVC.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
