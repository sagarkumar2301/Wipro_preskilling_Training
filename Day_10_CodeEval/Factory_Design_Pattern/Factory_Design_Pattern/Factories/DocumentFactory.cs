using Factory_Design_Pattern.Interfaces;
using Factory_Design_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern.Factories
{
    public class DocumentFactory
    {
        public static IDocument CreateDocument(string type)
        {
            if (type == "PDF")
                return new PdfDocument();
            else if (type == "WORD")
                return new WordDocument();

            throw new Exception("Invalid Type");
        }
    }
}
