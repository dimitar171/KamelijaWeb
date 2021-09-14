using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamelijaWeb.ViewModels;

namespace KamelijaWeb.Controllers
{
    public class AppController: Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet("Contact")]
        public IActionResult Contact()
        {
         
            
            return View();
        }
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
               
            }
            else
            {
               //
            }
            return View();

        }
        public IActionResult About()
        {
            ViewBag.Title = "За Нас";
            return View();
        }
    }
}
