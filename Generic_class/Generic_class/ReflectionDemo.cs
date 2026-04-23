using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_class
{
    public class ReflectionDemo
    {
        public void Run()
        {
            Console.WriteLine("---- US1: Reflection ----");

            Type type = typeof(Student);

            Console.WriteLine($"Class Name: {type.Name}");

            Console.WriteLine("Properties:");
            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine(prop.Name);
            }

            Console.WriteLine("Methods:");
            foreach (var method in type.GetMethods())
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}
