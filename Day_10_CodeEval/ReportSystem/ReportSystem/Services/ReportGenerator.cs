using ReportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Services
{
    public class ReportGenerator
    {
        public Report Generate()
        {
            return new Report { Content = "Report Data" };
        }
    }
}
