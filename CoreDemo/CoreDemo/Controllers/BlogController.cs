using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class BlogController : Controller
	{
		BlogManager blogmanager = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
		{
			var values = blogmanager.GetBlogListWithCategory();
			return View(values);
		}

		public IActionResult BlogReadAll(int id)	
		{
			ViewBag.i = id;	
			var values = blogmanager.GetBlogById(id);
			return View(values);
		}

        public IActionResult BlogListByWriter()
        {
			var values =blogmanager.GetListWithCategoryByWriterBm(1);
			return View(values);
        }

		[HttpGet]
        public IActionResult AddBlog()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
		[HttpPost]
        public IActionResult AddBlog(Blog p)
        {
          
                BlogValidator bv = new BlogValidator();

                ValidationResult results = bv.Validate(p);
                if (results.IsValid)
                {
                    p.BlogStatus = true;
                    p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString();
                    p.WriterId=1;
                    blogmanager.TAdd(p);
                    return RedirectToAction("BlogListByWriter", "Blog");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                return View();
            
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = blogmanager.TGetById(id);
            blogmanager.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = blogmanager.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues; 
            return View(blogvalue);             
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            p.WriterId= 1;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString();
            p.BlogStatus = true;
            blogmanager.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

    }
}
