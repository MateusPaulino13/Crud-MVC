using Crud_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud_MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department(1, "Eletronics"));
            list.Add(new Department(2, "Fashion"));
            return View(list);
        }
    }
}
