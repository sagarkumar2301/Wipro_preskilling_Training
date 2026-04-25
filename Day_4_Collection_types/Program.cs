using System;
using System.Collections.Generic;

class Customer
{
    public int Id;
    public string Name;
}

class Order
{
    public int OrderId;
    public int CustomerId;
    public string Category;

    public Stack<string> Status = new Stack<string>();
}

class Program
{
    static List<Order> orders = new List<Order>();
    static Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
    static HashSet<string> categories = new HashSet<string>();
    static Queue<Order> orderQueue = new Queue<Order>();

    static void Main()
    {
        
        customers.Add(1, new Customer { Id = 1, Name = "Sagar" });

        
        AddOrder(101, 1, "Electronics");
        AddOrder(102, 1, "Books");

        
        UpdateStatus(101, "Shipped");
        UpdateStatus(101, "Delivered");

        
        ProcessOrders();

        
        foreach (var c in categories)
        {
            Console.WriteLine(c);
        }

        
        ShowStatus(101);
    }

    static void AddOrder(int id, int custId, string category)
    {
        Order o = new Order();
        o.OrderId = id;
        o.CustomerId = custId;
        o.Category = category;

        o.Status.Push("Order Placed");

        orders.Add(o);
        orderQueue.Enqueue(o);
        categories.Add(category);
    }

    static void UpdateStatus(int orderId, string status)
    {
        foreach (var o in orders)
        {
            if (o.OrderId == orderId)
            {
                o.Status.Push(status);
            }
        }
    }

    static void ProcessOrders()
    {
        while (orderQueue.Count > 0)
        {
            Order o = orderQueue.Dequeue();
            o.Status.Push("Processed");

            Console.WriteLine("Processing Order: " + o.OrderId);
        }
    }

    static void ShowStatus(int orderId)
    {
        foreach (var o in orders)
        {
            if (o.OrderId == orderId)
            {
                Console.WriteLine("Current Status: " + o.Status.Peek());
            }
        }
    }
}
