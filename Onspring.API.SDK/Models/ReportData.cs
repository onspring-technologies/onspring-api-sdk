using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class ReportData
    {
        public IReadOnlyList<string> Columns { get; set; }
        public IReadOnlyList<ReportDataRow> Rows { get; set; }
    }
}