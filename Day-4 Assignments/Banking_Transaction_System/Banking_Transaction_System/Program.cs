// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class Transaction
{
    public string TransactionId;
    public double Amount;
}

class BankingSystem
{
    static void Main()
    {
        List<Transaction> history = new List<Transaction>();
        Dictionary<string, double> accounts = new Dictionary<string, double>();
        Queue<Transaction> pending = new Queue<Transaction>();
        Stack<Transaction> rollback = new Stack<Transaction>();
        HashSet<string> uniqueIds = new HashSet<string>();

        accounts["ACC1"] = 10000;

        Transaction t1 = new Transaction { TransactionId = "T1", Amount = 2000 };

        // Prevent duplicate
        if (uniqueIds.Add(t1.TransactionId))
        {
            pending.Enqueue(t1);
        }

        // Process transaction
        Transaction tx = pending.Dequeue();
        accounts["ACC1"] -= tx.Amount;

        history.Add(tx);
        rollback.Push(tx);

        Console.WriteLine("Balance: " + accounts["ACC1"]);

        // Rollback
        Transaction last = rollback.Pop();
        accounts["ACC1"] += last.Amount;

        Console.WriteLine("After Rollback Balance: " + accounts["ACC1"]);
    }
}
