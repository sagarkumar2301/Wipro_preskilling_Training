using ReportSystem.Interfaces;
using ReportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Services
{
    public class ReportService
    {
        private readonly IReportFormatter _formatter;

        public ReportService(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Process(Report report)
        {
            string result = _formatter.Format(report);
            Console.WriteLine(result);
        }
    }
}
