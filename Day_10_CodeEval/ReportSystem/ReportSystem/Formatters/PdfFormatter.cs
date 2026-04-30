using ReportSystem.Interfaces;
using ReportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Formatters
{
    public class PdfFormatter : IReportFormatter
    {
        public string Format(Report report)
        {
            return "PDF: " + report.Content;
        }
    }
}
