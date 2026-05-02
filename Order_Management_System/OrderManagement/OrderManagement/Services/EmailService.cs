using OrderManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    class EmailService : INotificationService
    {
        public void Send()
        {
            Console.WriteLine("Email sent");
        }
    }
}
