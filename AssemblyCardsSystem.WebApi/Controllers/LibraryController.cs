using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssemblyCardsSystem.WebApi.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AssemblyCardsSystem.WebApi.Controllers
{
    [Route("api/[controller]")]

    public class CardsController : Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;

        private static List<CardsResource> _Cards = new List<CardsResource>();

        public CardsController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("Delete/{id}")]
        public void Delete(string id)
        {
            var cardToDelete = _Cards.SingleOrDefault(r => r.Id == id);
            if (cardToDelete == null)
            {
                return;
            }
            _Cards.Remove(cardToDelete);
            return;
        }

        [HttpGet("Edit/{id}")]
        public CardsResource Edit(string id)
        {
            var cardToEdit = _Cards.SingleOrDefault(r => r.Id == id);
            return cardToEdit;
        }

        [HttpGet("Edited/{id}/{sort}/{KNNR}/{employeeID}/{employeeFN}/{employeeLN}")]
        public CardsResource Edited(string id,string employeeLN, string employeeFN, string employeeID, string knnr, string sort)
        {

            var cardToEdit = _Cards.SingleOrDefault(r => r.Id == id);
            cardToEdit.AssemblyCard.EmployeeFN = employeeFN;
            cardToEdit.AssemblyCard.EmployeeLN = employeeLN;
            cardToEdit.AssemblyCard.EmployeeID = employeeID;
            cardToEdit.AssemblyCard.KNNR = knnr;
            cardToEdit.AssemblyCard.Sort = sort;
            return cardToEdit;
        }

        [HttpGet("Create/{employeeLN}/{employeeFN}/{employeeID}/{knnr}/{sort}/{prnr}")]
        public void Create(string employeeLN, string employeeFN, string employeeID, string knnr, string sort, string prnr)
        {
            Guid guid = Guid.NewGuid();
            string str = guid.ToString();

            _Cards.Add(new CardsResource
            {
                Id = str,
                AssemblyCard = new AssemblyCard
                {
                    EmployeeFN = employeeFN,
                    EmployeeLN = employeeLN,
                    EmployeeID = employeeID,
                    KNNR = knnr,
                    Sort = sort,
                    PrNr = prnr,
                }
            });
            return;
        }

        [HttpGet("created")]
        public IEnumerable<CardsResource> GetCreated()
        {

                return _Cards;
        }
    }
}