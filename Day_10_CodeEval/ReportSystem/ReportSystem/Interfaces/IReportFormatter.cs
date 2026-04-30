using ReportSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Interfaces
{
    public interface IReportFormatter
    {
        string Format(Report report);
    }
}
