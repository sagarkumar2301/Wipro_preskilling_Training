// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class Order
{
    public int OrderId;
    public string ProductName;
    public double Price;
}

class Customer
{
    public int CustomerId;
    public string Name;
}

class ECommerceSystem
{
    static void Main()
    {
        List<Order> orders = new List<Order>();
        Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
        HashSet<string> categories = new HashSet<string>();
        Queue<Order> orderQueue = new Queue<Order>();
        Stack<string> statusHistory = new Stack<string>();

        
        customers[1] = new Customer { CustomerId = 1, Name = "Sagar" };

        
        Order order1 = new Order { OrderId = 101, ProductName = "Laptop", Price = 50000 };
        orders.Add(order1);
        orderQueue.Enqueue(order1);
        categories.Add("Electronics");

        
        order1.Price = 48000;

        
        Order processed = orderQueue.Dequeue();
        Console.WriteLine($"Processing Order: {processed.ProductName}");

        
        statusHistory.Push("Order Placed");
        statusHistory.Push("Shipped");
        statusHistory.Push("Delivered");

        Console.WriteLine("Last Status: " + statusHistory.Pop());

        
        orders.Remove(order1);
    }
}
