using AssemblyCardsSystem.WebApi.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyCardsSystem.WebApi
{
    using AssemblyCard = Model.AssemblyCard;
    public class DBConnector
    {
        private ConnectionFactory factory;
        public List<AssemblyCard> cards;
        private static DBConnector _instance;

        public static DBConnector GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DBConnector();
            }
            return _instance;
        }
        private DBConnector()
        {
            factory = new ConnectionFactory() { HostName = "localhost", Password = "guest", UserName = "guest" };
            cards = new List<AssemblyCard>();
            Task.Run(() => FetchCards());


            // send empty card so DBManager will sent updated cards
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                AssemblyCard card = new AssemblyCard
                {
                    CardId = string.Empty,
                };
                byte[] body;
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, card);
                    body = ms.ToArray();
                }

                Console.WriteLine("#########################try to fetch db ");
                channel.BasicPublish(exchange: "",
                                     routingKey: "queue-card-create",
                                     basicProperties: null,
                                     body: body);
            }
        }

        private void FetchCards()
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
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                };
                while (true)
                {
                    channel.BasicConsume(queue: queueName,
                     autoAck: false,
                     consumer: consumer);
                }
            }
        }

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

        public void Edited(AssemblyCard card)
        {
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
        }

        public void Create(AssemblyCard card)
        {
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
                                     routingKey: "queue-card-create",
                                     basicProperties: null,
                                     body: body);
            }
            return;
        }

    }
}
