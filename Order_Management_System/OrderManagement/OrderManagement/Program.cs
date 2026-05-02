using OrderManagement.Controllers;
using OrderManagement.Interfaces;
using OrderManagement.Models;
using OrderManagement.Repositories;
using OrderManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order { Id = 1, Amount = 1000 };

            // SRP usage
            OrderService service = new OrderService();
            service.ProcessOrder(order);

            OrderRepository repo = new OrderRepository();
            repo.Save(order);

            // OCP usage
            IDiscount discount = new PremiumDiscount();
            double finalAmount = discount.ApplyDiscount(order.Amount);
            Console.WriteLine("Final Amount: " + finalAmount);

            // LSP usage
            Notification notification = new EmailNotification();
            notification.Send();

            // DIP usage
            INotificationService emailService = new EmailService();
            OrderController controller = new OrderController(emailService);
            controller.CompleteOrder();
        }
    }
}
