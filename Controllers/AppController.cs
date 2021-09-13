using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamelijaWeb.Controllers
{
    public class AppController: Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.Title = "Контактирајте не";

            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "За Нас";
            return View();
        }
    }
}
