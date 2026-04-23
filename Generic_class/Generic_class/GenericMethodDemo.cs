using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_class
{
    internal class GenericMethodDemo
    {
        public void PrintData<T>(T data)
        {
            Console.WriteLine($"Data: {data}");
        }
    }
}
