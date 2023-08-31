

using System.Text;
using Newtonsoft.Json;
using POC.RabbitMQ.Consumer.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace POC.RabbitMQ.ConsoleConsumer;

class Program
{
    private static List<Product> _mockInventory = new List<Product>
    {
        new Product { ProductId = 1, Title = "Product 1", Price = 10, QuantityInStock = 100 },
        new Product { ProductId = 2, Title = "Product 2", Price = 20, QuantityInStock = 150 },
        new Product { ProductId = 3, Title = "Product 3", Price = 30, QuantityInStock = 250 },
        new Product { ProductId = 4, Title = "Product 4", Price = 40, QuantityInStock = 0 },
        new Product { ProductId = 5, Title = "Product 5", Price = 50, QuantityInStock = 5 },

    };

    private static int _quantityRequested; 

    static void Main(string[] args)
    {
        Console.WriteLine("Product ID | Title       | Price | Quantity In Stock");
        Console.WriteLine("-----------------------------------------------");
        foreach (var product in _mockInventory)
        {
            Console.WriteLine($"{product.ProductId,-10} | {product.Title,-12} | {product.Price,-6:C} | {product.QuantityInStock,-16}");
        }
        
        var factory = new ConnectionFactory()
        {
            HostName = "172.17.0.3",
            Port = 5672,
            UserName = "guest",
            Password = "guest",
            VirtualHost = "/"
        };

        using (var connection = factory.CreateConnection()) 
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(
                queue: "sales_queqe",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                var message = Encoding.UTF8.GetString(args.Body.ToArray());
                var messageProduct = JsonConvert.DeserializeObject<Message>(message);
                _quantityRequested = messageProduct.Quantity;
                ProcessMessage(messageProduct);
                
            };
            
            channel.BasicConsume(queue: "sales_queue", autoAck: true, consumer: consumer);
            
            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();
        }
    }
    
    private static void ProcessMessage(Message productInMessage)
    {
        var searchedProduct = _mockInventory.FirstOrDefault(p => p.ProductId == productInMessage.ProductId);
        if (searchedProduct != null)
        {
            if (searchedProduct.QuantityInStock >= _quantityRequested)
            {
                searchedProduct.QuantityInStock -= _quantityRequested;
                Console.WriteLine(
                    $"Product Id: {searchedProduct.ProductId}, Title: {searchedProduct.Title} deducted from stock. New stock: {searchedProduct.QuantityInStock}");
            }
            else
            {
                Console.WriteLine($"Product {searchedProduct.ProductId} is out of stock.");
            }
        }
        else
        {
            Console.WriteLine($"Product {searchedProduct.ProductId} not found.");
        }
    }
}