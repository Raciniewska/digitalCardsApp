using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using AssemblyCardsSystem.WebApi.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AssemblyCardsSystem.WebApi.Controllers
{
    using AssemblyCard = Model.AssemblyCard;
    [Route("api/[controller]")]
    public class CardsController : Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private ConnectionFactory factory;
        private static List<AssemblyCard> cards;

        public CardsController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };
            Task.Run(() => FetchCards());
        }

        public List<AssemblyCard> FetchCards()
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "exchange-card-read", type: ExchangeType.Fanout);

                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                  exchange: "exchange-card-read",
                                  routingKey: "");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(body, 0, body.Length);
                        ms.Position = 0;
                        cards = bf.Deserialize(ms) as List<AssemblyCard>;
                        Console.WriteLine(" list of cards updated ");
                    }
                };
                while(true)
                {
                    channel.BasicConsume(queue: queueName,
                     autoAck: true,
                     consumer: consumer);
                }
            }
            
            return null;
        }

        [HttpGet("Delete/{id}")]
        public void Delete(string id)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                byte[] body = Encoding.UTF8.GetBytes(id);
                
                channel.BasicPublish(exchange: "",
                                     routingKey: "queue-card-delete",
                                     basicProperties: null,
                                     body: body);
            }
            return;
        }

        [HttpGet("Send/{id}")]
        public async Task<ActionResult> Send(string id)
        {
             AssemblyCard cardToSend = null; ;
             if (cardToSend == null)
             {
                 return NotFound($"AssemblyCard with id: {id} does not exist");
             }
             await _publishEndpoint.Publish<CardToSend>(new {EmployeeLN = cardToSend.EmployeeLN,
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
            return null;
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
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                byte[] body;
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, card);
                    body = ms.ToArray();
                }


                channel.BasicPublish(exchange: "",
                                     routingKey: "queue-card-update",
                                     basicProperties: null,
                                     body: body);
            }
            return new CardsResource { Id = id, AssemblyCard = card };
        }

        [HttpGet("Create/{employeeLN}/{employeeFN}/{employeeID}/{knnr}/{sort}/{prnr}")]
        public void Create(string employeeLN, string employeeFN, string employeeID, string knnr, string sort, string prnr)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
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
                byte[] body;
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, card);
                    body = ms.ToArray();
                }


                channel.BasicPublish(exchange: "",
                                     routingKey: "queue-card-create",
                                     basicProperties: null,
                                     body: body);
            }
            return;
        }

  
        [HttpGet("created")]
        public IEnumerable<CardsResource> GetCreated()
        {
            return cards.Select(card => new CardsResource() { Id = card.CardId, AssemblyCard = card }).ToList(); ;
        }
    }
}