using Digital_Wallet_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Wallet_System.Payments
{
    //LSP
    public class NetBankingPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} using Net Banking");
        }
    }
}
