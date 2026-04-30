using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSystem.Models
{
    public class SalesReport : BaseReport
    {
        public override string GetContent()
        {
            return "Sales Report Data";
        }
    }
}
