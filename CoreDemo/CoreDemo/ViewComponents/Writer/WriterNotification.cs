using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            NotificationManager nm = new NotificationManager(new EfNotificationRepository());
            var values = nm.GetList();
            return View(values);
            return View();
        }
    }
}
