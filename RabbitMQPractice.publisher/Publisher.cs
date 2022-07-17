using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQPractice.publisher
{
    public class Publisher
    {
       public void pub()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://bbbsxkbx:zMwgNNn1ygxD4ycevJcrnCgLiEGD9XBw@rat.rmq2.cloudamqp.com/bbbsxkbx");

            using var conneciton = factory.CreateConnection();

            var channel = conneciton.CreateModel();

            var queue = channel.QueueDeclare("test-queue", true, false, false);

            var message = "Hello World!";

            var messageBody = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(string.Empty,"test-queue",null,messageBody);

            Console.WriteLine("Mesaj kuyruğa eklendi");

            Console.ReadLine();
        }
    }
}
