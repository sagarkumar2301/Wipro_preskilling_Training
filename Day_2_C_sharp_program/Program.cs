// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number: ");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the second number: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int sum = num1 + num2;

        Console.WriteLine("The sum is: " +sum);
    }
}