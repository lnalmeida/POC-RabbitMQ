using System.Numerics;

namespace POC.RabbitMQ.Consumer.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public Double Price { get; set; }
    public int QuantityInStock { get; set; }
}