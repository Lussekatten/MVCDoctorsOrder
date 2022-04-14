using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEmpty.Controllers
{
    public class MyController : Controller
    {
        public ViewResult Home()
        {
            ViewBag.Date = DateTime.Now.ToString();
            return View();
        }
        public ViewResult About()
        {
            ViewBag.Title = "Lucian testar viewbag";
            ViewBag.Date = DateTime.Now.ToString();
            return View();
        }
        public ViewResult Contact()
        {
            ViewBag.Date = DateTime.Now.ToString();
            return View();
        }
        public ViewResult Projects()
        {
            ViewBag.Date = DateTime.Now.ToString();
            return View();
        }
    }

}
