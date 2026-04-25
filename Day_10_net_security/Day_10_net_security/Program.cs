// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static string filePath = "users.txt";

    static void Main()
    {
        Console.WriteLine("1. Register\n2. Login");
        Console.Write("Choose option: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Register();
        }
        else if (choice == 2)
        {
            Login();
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }

    // ================= US1: Hash Password =================
    static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            foreach (byte b in hash)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    // ================= US2: Store Hashed Password =================
    static void Register()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        string hashedPassword = HashPassword(password);

        // Store in file (username:hash)
        File.AppendAllText(filePath, username + ":" + hashedPassword + Environment.NewLine);

        Console.WriteLine("User registered successfully!");
    }

    // ================= US3: Validate Login =================
    static void Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        string hashedInput = HashPassword(password);

        if (!File.Exists(filePath))
        {
            Console.WriteLine("No users found.");
            return;
        }

        string[] users = File.ReadAllLines(filePath);

        foreach (string user in users)
        {
            string[] parts = user.Split(':');
            if (parts[0] == username)
            {
                if (parts[1] == hashedInput)
                {
                    Console.WriteLine("Login Successful ✅");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Password ❌");
                    return;
                }
            }
        }

        Console.WriteLine("User not found ❌");
    }
}
