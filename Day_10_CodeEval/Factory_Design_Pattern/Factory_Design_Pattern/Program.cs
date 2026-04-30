using Factory_Design_Pattern.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = DocumentFactory.CreateDocument("WORD");
            doc.Open();
        }
    }
}
