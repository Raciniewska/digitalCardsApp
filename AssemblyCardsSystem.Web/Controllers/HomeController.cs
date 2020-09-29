using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using AssemblyCardsSystem.Web.Configuration;
using Microsoft.AspNetCore.Mvc;
using AssemblyCardsSystem.Web.Models;
using AssemblyCardsSystem.Web.Utilities;
using Microsoft.Extensions.Options;

namespace AssemblyCardsSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly EnvironmentConfig _environmentConfiguration;

        public HomeController(IOptions<EnvironmentConfig> configuration)
        {
            _environmentConfiguration = configuration.Value;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }

        public IActionResult AdminConsole()
        {

            return View();
        }

        public IActionResult PlatformConfigure()
        {

            return View();
        }
        public IActionResult PlatformConfigurationSuccess()
        {

            return View();
        }
        public IActionResult AdminLogin()
        {

            return View();
        }

        
        public async Task<IActionResult> Edit(string id)
        {
            var createdCard = await RequestHandler.MakeRequest<CardsResource>($@"{_environmentConfiguration.AssemblyCardsSystemWebApiServiceHost}/api/Cards/Edit/" + id);
            return View(createdCard);
        }

        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await RequestHandler.MakeRequest<List<CardsResource>>($@"{_environmentConfiguration.AssemblyCardsSystemWebApiServiceHost}/api/Cards/Delete/" + id);
            }
            catch
            {
                return View("Views/Home/Search.cshtml");
            }
            return View("Views/Home/Search.cshtml");
        }

        public async Task<IActionResult> Search(string SearchKNNR, string SearchEL, string SearchSort)
        {

            var createdCards = await RequestHandler.MakeRequest<List<CardsResource>>($@"{_environmentConfiguration.AssemblyCardsSystemWebApiServiceHost}/api/Cards/created");

            var model = createdCards;
            List<CardsResource> resource = model.ToList();
            if (!String.IsNullOrEmpty(SearchKNNR) || !String.IsNullOrEmpty(SearchEL) || !String.IsNullOrEmpty(SearchSort))
            {
                if (!String.IsNullOrEmpty(SearchKNNR))
                {
                    resource = resource.Where(s => s.AssemblyCard.KNNR.Contains(SearchKNNR)).ToList();
                }
                if (!String.IsNullOrEmpty(SearchEL))
                {
                    resource = resource.Where(s => s.AssemblyCard.EmployeeLN.Contains(SearchEL)).ToList();
                }
                if (!String.IsNullOrEmpty(SearchEL))
                {
                    resource = resource.Where(s => s.AssemblyCard.Sort.Contains(SearchSort)).ToList();
                }
            }
            return View(resource);


        }

        public IActionResult Send(string id, string destinationEmail)
        {
            Console.WriteLine(destinationEmail);
            try
            {

                RequestHandler.MakeRequest<List<CardsResource>>($@"{_environmentConfiguration.AssemblyCardsSystemWebApiServiceHost}/api/Cards/Send/" + id + "/" + destinationEmail);

            }
            catch
            {
                return View("Views/Home/Search.cshtml");
            }
            return View();
        }

        public IActionResult Create()
        {

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