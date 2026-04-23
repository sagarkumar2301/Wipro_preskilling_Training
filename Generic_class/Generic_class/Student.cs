using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_class
{
    internal class Student
    {
        public string Name { get; set; }
        public int Marks { get; set; }

        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Marks: {Marks}");
        }
    }
}
