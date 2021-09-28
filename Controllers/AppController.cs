using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KamelijaWeb.ViewModels;
using KamelijaWeb.Services;
using KamelijaWeb.Data;
using Microsoft.AspNetCore.Authorization;

namespace KamelijaWeb.Controllers
{
    public class AppController: Controller
    {
        private readonly IMailService _mailService;
        private readonly IKamRepository _repository;

        public AppController(IMailService mailService, IKamRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
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
        [Authorize]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }
    }
}
