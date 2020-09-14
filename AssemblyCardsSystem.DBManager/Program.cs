using AssemblyCardsSystem.DBManager.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyCardsSystem.DBManager
{
    using AssemblyCard = Model.AssemblyCard;


    public class YourMessage { public string Text { get; set; } }

    class Program
    {
        private static ConnectionFactory factory;
        static void Main(string[] args)
        {
            factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };
            publishProducts();
            Task.Run(() => initCreateQueue());
            Task.Run(() => initUpdateQueue());
            Task.Run(() => initDeleteQueue());

            Console.ReadLine();
        }

        private static void initCreateQueue()
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "queue-card-create",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(body, 0, body.Length);
                        ms.Position = 0;
                        var card = bf.Deserialize(ms) as AssemblyCard;
                        insertProduct(card);
                        publishProducts();
                    }

                    Console.WriteLine(" queue-card-create ");
                    
                };
                while (true)
                {
                    channel.BasicConsume(queue: "queue-card-create",
                                         autoAck: true,
                                         consumer: consumer);
                };
            }
        }

        private static void initUpdateQueue()
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "queue-card-update",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(body, 0, body.Length);
                        ms.Position = 0;
                        var card = bf.Deserialize(ms) as AssemblyCard;
                        updateProduct(card);
                        publishProducts();
                    }
                    Console.WriteLine(" queue-card-update ");
                };
               
                while (true)
                {
                    channel.BasicConsume(queue: "queue-card-update",
                                        autoAck: true,
                                        consumer: consumer);
                };
            }
        }

        private static void initDeleteQueue()
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "queue-card-delete",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var id = Encoding.UTF8.GetString(body);
                    deleteProduct(id);
                    publishProducts();
                    Console.WriteLine(" queue-card-delete ");
                };

                while (true)
                {
                    channel.BasicConsume(queue: "queue-card-delete",
                     autoAck: true,
                     consumer: consumer);
                };

            }
        }

        static void insertProduct(AssemblyCard card)
        {
            using (var db = new CardsContext())
            {
                db.Add(card);
                db.SaveChanges();
            }
        }

        static void publishProducts()
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "exchange-card-read", type: ExchangeType.Fanout);

                byte[] body;
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (var db = new CardsContext())
                    {
                        List<AssemblyCard> cards = db.Cards.ToList();
                        bf.Serialize(ms, cards);
                        body = ms.ToArray();
                    }
                }

                channel.BasicPublish(exchange: "exchange-card-read",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }
        }

        static void updateProduct(AssemblyCard card)
        {
            using (var db = new CardsContext())
            {
                AssemblyCard savedCard = db.Cards.SingleOrDefault(r => r.CardId == card.CardId);
                if (savedCard == null)
                {
                    return;
                }
                savedCard.EmployeeFN = card.EmployeeFN;
                savedCard.EmployeeLN = card.EmployeeLN;
                savedCard.EmployeeID = card.EmployeeID;
                savedCard.KNNR = card.KNNR;
                savedCard.Sort = card.Sort;
                db.SaveChanges();
            }
        }

        static void deleteProduct(string id)
        {
            using (var db = new CardsContext())
            {
                AssemblyCard card = db.Cards.SingleOrDefault(r => r.CardId == id);
                if (card == null)
                {
                    return;
                }
                db.Cards.Remove(card);
                db.SaveChanges();
            }
        }
    }
}
