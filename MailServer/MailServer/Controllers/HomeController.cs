using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MailServer.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System.Security.Authentication;

namespace MailServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var massage = new MimeMessage();
            massage.From.Add(new MailboxAddress("Barbara Raciniewska", "student172071@gmail.com"));
            massage.To.Add(new MailboxAddress("to mail", "raciniewska.barbara@gmail.com"));

            massage.Subject = " Test MailKit";
            massage.Body = new TextPart("plain")
            {
                Text = "przykladowy text"
            };
            using( var client = new SmtpClient())
            {

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.gmail.com", 587,false);
                client.Authenticate("student172071@gmail.com", "Student1@");
                client.Send(massage);
                client.Disconnect(true);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
