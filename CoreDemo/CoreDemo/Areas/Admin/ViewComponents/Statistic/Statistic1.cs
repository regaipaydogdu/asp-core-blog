using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm= new BlogManager(new EfBlogRepository());
        Context context = new Context();    
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2 = context.Contacts.Count();
            ViewBag.v3 = context.Comments.Count();

            string apikey= "23b55fbef69a9eb0e4600c28aba1b807";
            string connection = "https://api.openweathermap.org/data/2.5/weather?lat=41.0351&mode=xml&lang=tr&units=metric&lon=28.9833&appid=" + apikey;
            XDocument document= XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;


            return View();
        }
    }
}
