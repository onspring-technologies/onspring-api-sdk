using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetReportsByAppRequestBuilderOptions
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}