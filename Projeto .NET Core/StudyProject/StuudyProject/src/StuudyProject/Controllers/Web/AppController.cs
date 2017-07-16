using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StuudyProject.Models;
using StuudyProject.Services;
using StuudyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuudyProject.Controllers.Web
{
    public class AppController: Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private WorldContext _context;

        public AppController(IMailService mailService, IConfigurationRoot config, WorldContext context)
        {
            _context = context;
            _mailService = mailService;
            _config = config;
        }
        public IActionResult Index()
        {
            var data = _context.Trips.ToList();
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if(model.Email.Contains("aol.com"))
            {
                ModelState.AddModelError("", "We do not support AOL adresses");
            }
            if (ModelState.IsValid)
            {
                _mailService.SendEmail(_config["MailSettings:ToAdress"], model.Email, "From the World", model.Message);
                ModelState.Clear();
                ViewBag.UserMessage = "MessageSent";
            }
            return View();

        }
        public IActionResult About()
        {
            return View();
        }
    }
}
