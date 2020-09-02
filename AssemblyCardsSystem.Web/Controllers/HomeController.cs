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
            var rentedBooks = await RequestHandler.MakeRequest<List<LibraryResource>>($@"{_environmentConfiguration.AssemblyCardsSystemWebApiServiceHost}/api/library/rented/");

            var model = rentedBooks.Select(resource => $"{resource?.Id} - {resource?.Book?.Title}, {resource?.Book?.Author}");
          
            return View(model.ToList());
        }
       

        public  IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
           
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await RequestHandler.MakeRequest<List<CardsResource>>($@"{_environmentConfiguration.AssemblyCardsSystemWebApiServiceHost}/api/library/Delete/" + id);
            }
            catch
            {
                return View("Views/Home/Search.cshtml");
            }
            return View("Views/Home/Search.cshtml");
        }
            public async Task<IActionResult> Search()
        {
            var createdCards = await RequestHandler.MakeRequest<List<CardsResource>>($@"{_environmentConfiguration.AssemblyCardsSystemWebApiServiceHost}/api/library/created/");

            var model = createdCards;//.Select(resource => $"KNNR: {resource?.AssemblyCard?.KNNR} --- Employee Lastname: {resource?.AssemblyCard?.EmployeeLN} --- Sort No.: {resource?.AssemblyCard?.Sort}");

            return View(model.ToList());
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}