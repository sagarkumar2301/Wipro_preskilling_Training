using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multicasting_delegate
{
    class Reader
    {
        public string Name;
        public Reader(string name)
        {
            Name = name;
        }
        public void ReceiveNews(string news)
        {
            Console.WriteLine(Name + "received: " + news);
        }
    }
}
