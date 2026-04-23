using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_class
{
    internal class OutDemo
    {
        public void GetValues(out int number, out string message)
        {
            number = 100;
            message = "Operation Successful";
        }
    }
}
