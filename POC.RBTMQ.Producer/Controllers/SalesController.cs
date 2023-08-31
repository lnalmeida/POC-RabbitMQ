using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using POC.RBTMQ.Producer.Messages;
using RabbitMQ.Client;

namespace POC.RBTMQ.Producer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController: ControllerBase
{
    private readonly IConnection _rabbitMqConnection;

    public SalesController(IConnection rabbitMqConnection)
    {
        _rabbitMqConnection = rabbitMqConnection;
        if (_rabbitMqConnection.IsOpen)
        {
            System.Console.WriteLine("RabbitMQ server connected");
        }
        else
        {
            System.Console.WriteLine("RabbitMQ server not connected");
        }
    }
    
    [HttpPost]
    public IActionResult PostSale([FromBody] SaleMessage saleMessage)
    {
        using var channel = _rabbitMqConnection.CreateModel();
        var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(saleMessage));
        channel.QueueDeclare(
            queue: "sales_queue", 
            durable: false, 
            exclusive: false, 
            autoDelete: false,
            arguments: null);
        channel.BasicPublish(exchange:"", routingKey:"sales_queue", basicProperties: null, body: messageBody);
        return Ok($"Message sended successfully: {JsonSerializer.Serialize(saleMessage)}");
    }
}

