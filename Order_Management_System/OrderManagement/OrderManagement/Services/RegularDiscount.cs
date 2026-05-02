using OrderManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    class RegularDiscount : IDiscount
    {
        public double ApplyDiscount(double amount)
        {
            return amount * 0.9;
        }
    }
}
