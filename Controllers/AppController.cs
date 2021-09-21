using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamelijaWeb.ViewModels;
using KamelijaWeb.Services;
using KamelijaWeb.Data;

namespace KamelijaWeb.Controllers
{
    public class AppController: Controller
    {
        private readonly IMailService _mailService;
        private readonly KamContext _context;

        public AppController(IMailService mailService, KamContext context)
        {
            _mailService = mailService;
            _context = context;
        }
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
                    // Send the Email
                    _mailService.SendMessage("shawn@wildermuth.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                    ViewBag.UserMessage = "Mail Sent...";
                    ModelState.Clear();
                }

                return View();

        }
        public IActionResult About()
        {
            ViewBag.Title = "За Нас";
            return View();
        }
        public IActionResult Shop()
        {
            var results = from p in _context.Products
                         orderby p.Category
                         select p;
            return View(results.ToList());
        }
    }
}
