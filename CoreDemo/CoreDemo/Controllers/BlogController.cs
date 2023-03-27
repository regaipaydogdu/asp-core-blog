using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
	
	public class BlogController : Controller
	{
		BlogManager blogmanager = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

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
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values =blogmanager.GetListWithCategoryByWriterBm(writerId);
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
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();

            BlogValidator bv = new BlogValidator();

                ValidationResult results = bv.Validate(p);
                if (results.IsValid)
                {
                    p.BlogStatus = true;
                    p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString();
                    p.WriterId=writerId;
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
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            p.WriterId= writerId;
            p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString();
            p.BlogStatus = true;
            blogmanager.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

    }
}
