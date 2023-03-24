using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categorymanager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = categorymanager.GetList();
            return View(values);
        }
    }
}
