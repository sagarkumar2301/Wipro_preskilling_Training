using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repositories
{
    class OrderRepository
    {
        // SRP: Only responsible for saving data
        public void Save(Order order)
        {
            Console.WriteLine("Order saved to database");
        }
    }
}
