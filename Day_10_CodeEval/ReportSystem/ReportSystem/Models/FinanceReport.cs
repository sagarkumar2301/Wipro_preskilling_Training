using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Models
{
    public class FinanceReport : BaseReport
    {
        public override string GetContent()
        {
            return "Finance Report Data";
        }
    }
}
