using Digital_Wallet_System.Interfaces;
using Digital_Wallet_System.Payments;
using Digital_Wallet_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Wallet_System
{
    public class Program
    {
        static void Main()
        {
            INotification notification = new EmailNotification();

            WalletService wallet = new WalletService(notification);

            wallet.AddMoney(1000);

            wallet.MakePayment(new UPIPayment(), 200);
            wallet.MakePayment(new CardPayment(), 300);

            wallet.ShowTransactions();
        }
    }
}
