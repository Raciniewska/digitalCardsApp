using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssemblyCardsSystem.WebApi.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AssemblyCardsSystem.WebApi.Controllers
{
    using AssemblyCard = Model.AssemblyCard;
    [Route("api/[controller]")]
    public class CardsController : Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private static DBConnector dbConnector = DBConnector.GetInstance();

        public CardsController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("Delete/{id}")]
        public void Delete(string id)
        {
            dbConnector.Delete(id);
            return;
        }


        [HttpGet("Send/{id}/{destinationEmail}")]
        public async Task<ActionResult> Send(string id, string destinationEmail)
        {
             AssemblyCard cardToSend = dbConnector.cards.SingleOrDefault(r => r.CardId == id);
            if (cardToSend == null)
             {
                 return NotFound($"AssemblyCard with id: {id} does not exist");
             }
             await _publishEndpoint.Publish<CardToSend>(new {

                 destinationEmail = destinationEmail,
                 EmployeeLN = cardToSend.EmployeeLN,
                 EmployeeFN = cardToSend.EmployeeFN,
                 EmployeeID = cardToSend.EmployeeID,
                 KNNR = cardToSend.KNNR,
                 Sort = cardToSend.Sort,
                 PrNr = cardToSend.PrNr
             });
            
            return Ok();
        }

        [HttpGet("Edit/{id}")]
        public CardsResource Edit(string id)
        {
            var cardToEdit = dbConnector.cards.SingleOrDefault(r => r.CardId == id);
            return new CardsResource { Id = cardToEdit.CardId, AssemblyCard = cardToEdit };
        }

        [HttpGet("Edited/{id}/{sort}/{KNNR}/{employeeID}/{employeeFN}/{employeeLN}")]
        public CardsResource Edited(string id,string employeeLN, string employeeFN, string employeeID, string knnr, string sort)
        {
            var card = new AssemblyCard
            {
                CardId = id,
                EmployeeFN = employeeFN,
                EmployeeLN = employeeLN,
                EmployeeID = employeeID,
                KNNR = knnr,
                Sort = sort,

            };
            dbConnector.Edited(card);

            return new CardsResource { Id = id, AssemblyCard = card };
        }

        [HttpGet("Create/{employeeLN}/{employeeFN}/{employeeID}/{knnr}/{sort}/{prnr}")]
        public void Create(string employeeLN, string employeeFN, string employeeID, string knnr, string sort, string prnr)
        {

                var card =  new AssemblyCard
                {
                    CardId = Guid.NewGuid().ToString(),
                    EmployeeFN = employeeFN,
                    EmployeeLN = employeeLN,
                    EmployeeID = employeeID,
                    KNNR = knnr,
                    Sort = sort,
                    PrNr = prnr,
                    
                };
            dbConnector.Create(card);

            return;
        }

  
        [HttpGet("created")]
        public IEnumerable<CardsResource> GetCreated()
        {
            return dbConnector.cards.Select(card => new CardsResource() { Id = card.CardId, AssemblyCard = card });
        }
    }
}