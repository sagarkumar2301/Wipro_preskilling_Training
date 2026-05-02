using OrderManagement.Interfaces;
using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    class Worker : IOrderProcessor
    {
        // ISP: Only implementing what is needed
        public void Process(Order order)
        {
            Console.WriteLine("Worker processing order");
        }
    }
}
