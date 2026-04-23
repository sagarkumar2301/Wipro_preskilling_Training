using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_class
{
    internal class Box<T>
    {
        public T Value;

        public void Show()
        {
            Console.WriteLine($"Value: {Value}");
        }
    }
}
