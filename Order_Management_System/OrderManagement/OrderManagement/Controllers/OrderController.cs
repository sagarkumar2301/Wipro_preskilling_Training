using OrderManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    class OrderController
    {
        private readonly INotificationService _notificationService;

        // DIP: Injecting abstraction instead of concrete class
        public OrderController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void CompleteOrder()
        {
            Console.WriteLine("Order completed");

            _notificationService.Send();
        }
    }
}
