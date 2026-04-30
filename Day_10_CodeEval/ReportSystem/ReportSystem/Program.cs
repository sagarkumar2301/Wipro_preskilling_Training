using ReportSystem.Formatters;
using ReportSystem.Interfaces;
using ReportSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem
{
    class Program
    {
        static void Main()
        {
            var generator = new ReportGenerator();
            var saver = new ReportSaver();

            var report = generator.Generate();

            IReportFormatter formatter = new PdfFormatter(); // change to ExcelFormatter easily

            var service = new ReportService(formatter);
            service.Process(report);

            saver.Save(report);
        }
    }
}
