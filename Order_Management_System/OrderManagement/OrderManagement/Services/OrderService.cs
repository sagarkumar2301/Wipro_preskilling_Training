using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    class OrderService
    {
        // SRP: Only responsible for order processing
        public void ProcessOrder(Order order)
        {
            Console.WriteLine("Order processed");
        }
    }
}
