// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
namespace Generic_class
{

    class Program
    {
        static void Main()
        {
            // US1: Reflection
            var reflection = new ReflectionDemo();
            reflection.Run();

            // US2: Generic Class
            Console.WriteLine("\n---- US2: Generic Class ----");

            Box<int> intBox = new Box<int>();
            intBox.Value = 10;
            intBox.Show();

            Box<string> strBox = new Box<string>();
            strBox.Value = "Hello";
            strBox.Show();

            // US3: Generic Method
            Console.WriteLine("\n---- US3: Generic Method ----");

            var generic = new GenericMethodDemo();
            generic.PrintData(123);
            generic.PrintData("Sagar");

            // US4: ref
            Console.WriteLine("\n---- US4: ref ----");

            var refDemo = new RefDemo();
            int num = 20;
            Console.WriteLine($"Before: {num}");
            refDemo.UpdateValue(ref num);
            Console.WriteLine($"After: {num}");

            // US5: out
            Console.WriteLine("\n---- US5: out ----");

            var outDemo = new OutDemo();
            int result;
            string message;

            outDemo.GetValues(out result, out message);

            Console.WriteLine($"Number: {result}");
            Console.WriteLine($"Message: {message}");
        }
    }
}