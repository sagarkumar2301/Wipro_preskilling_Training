using demo_project1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace demo_project1
{
    public class Student
    {
        public string Name;
        public int Age;

        public void Display()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
        }
    }

   
}
  