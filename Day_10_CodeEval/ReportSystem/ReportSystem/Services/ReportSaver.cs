using ReportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Services
{
    public class ReportSaver
    {
        public void Save(Report report)
        {
            Console.WriteLine("Report Saved: " + report.Content);
        }
    }
}
