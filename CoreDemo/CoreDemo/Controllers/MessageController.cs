using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager messagemanager = new Message2Manager(new EfMessage2Repository());

        [AllowAnonymous]
        public IActionResult InBox()
        {
            int id = 1;
            var values = messagemanager.GetInboxListByWriter(id);
            return View(values);
        }
        [AllowAnonymous]

        public IActionResult MessageDetails(int id)
        {
            var value = messagemanager.TGetById(id);
            return View(value);
        }
    }
}
