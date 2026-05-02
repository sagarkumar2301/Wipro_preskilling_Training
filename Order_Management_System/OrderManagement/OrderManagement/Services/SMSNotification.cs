using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    class SMSNotification : Notification
    {
        public override void Send()
        {
            Console.WriteLine("Sending SMS");
        }
    }
}
