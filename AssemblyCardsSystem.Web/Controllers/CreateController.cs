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
    public class CreateController : Controller
    {
        private readonly EnvironmentConfig _environmentConfiguration;

        public async Task<IActionResult> Submit(string EmployeeLN, string EmployeeFN, string EmployeeID, string KNNR, string sort, string PrNr)
        {
            try
            {
                await RequestHandler.MakeRequest<List<CardsResource>>($@"{_environmentConfiguration.AssemblyCardsSystemWebApiServiceHost}/api/library/Create/"+EmployeeLN+"/"+EmployeeFN+"/"+EmployeeID+"/"+KNNR+"/"+sort+"/"+PrNr);
            }
            catch
            {
                return View("Views/Home/CreationDone.cshtml"); 
            }
            return View("Views/Home/CreationDone.cshtml");
        }

        public  IActionResult CreateNewOne()
        {
            return View("Views/Home/Create.cshtml");
        }
       
        public CreateController(IOptions<EnvironmentConfig> configuration)
        {
            _environmentConfiguration = configuration.Value;
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}