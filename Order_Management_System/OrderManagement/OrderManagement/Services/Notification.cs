using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    class Notification
    {
        public virtual void Send()
        {
            Console.WriteLine("Sending notification");
        }
    }
}
