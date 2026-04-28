using Digital_Wallet_System.Interfaces;
using Digital_Wallet_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Wallet_System.Services
{
    //SRP + DIP
    public class WalletService
    {
        private readonly INotification _notification;
        private readonly List<Transaction> _transactions;

        public WalletService(INotification notification)
        {
            _notification = notification;
            _transactions = new List<Transaction>();
        }

        public void AddMoney(double amount)
        {
            _transactions.Add(new Transaction { Amount = amount, Type = "Credit" });
            _notification.Send($"Added {amount}");
        }

        public void MakePayment(IPayment payment, double amount)
        {
            payment.Pay(amount);

            _transactions.Add(new Transaction { Amount = amount, Type = "Debit" });

            _notification.Send($"Paid {amount}");
        }

        public void ShowTransactions()
        {
            Console.WriteLine("Transactions:");
            foreach (var t in _transactions)
            {
                Console.WriteLine($"{t.Type} - {t.Amount}");
            }
        }
    }
}
