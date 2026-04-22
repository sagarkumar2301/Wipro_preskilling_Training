//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Sorting_algorithm;
using System;

class LinearSearchClass
{
    public static int LinearSearch(int[] arr, int key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
                return i;
        }
        return -1;
    }
}
class Program
{
    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50 };

        Console.WriteLine("Enter element to search:");
        int key = Convert.ToInt32(Console.ReadLine());

        
        int linearResult = LinearSearchClass.LinearSearch(arr, key);

        if (linearResult != -1)
            Console.WriteLine("Linear Search: Element found at index " + linearResult);
        else
            Console.WriteLine("Linear Search: Element not found");

        
        BinarySearchClass bs = new BinarySearchClass();
        int binaryResult = bs.BinarySearch(arr, key);

        if (binaryResult != -1)
            Console.WriteLine("Binary Search: Element found at index " + binaryResult);
        else
            Console.WriteLine("Binary Search: Element not found");
    }
}

