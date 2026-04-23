using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_class
{
    internal class RefDemo
    {
        public void UpdateValue(ref int num)
        {
            num = num + 10;
        }
    }
}
