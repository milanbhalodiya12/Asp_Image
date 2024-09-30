using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using imgAdvancedaspnet.Models;

namespace imgAdvancedaspnet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Student s = new Student();
            return View(s);
        }

        [HttpPost]
        public ActionResult Index(Student s , HttpPostedFileBase img)
        {
            var db = new mydbEntities();
            if(img != null)
            {
                s.image = new byte[img.ContentLength];
                img.InputStream.Read(s.image, 0, img.ContentLength);
            }
            db.Students.Add(s);
            db.SaveChanges();
            return View(s);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}