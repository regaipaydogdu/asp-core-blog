using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context context = new Context();
            ViewBag.value= context.Blogs.Count().ToString();
            ViewBag.value1 = context.Blogs.Where(x => x.WriterId == 1).Count();
            ViewBag.value2 = context.Categories.Count().ToString();
            return View();
        }
    }
}
