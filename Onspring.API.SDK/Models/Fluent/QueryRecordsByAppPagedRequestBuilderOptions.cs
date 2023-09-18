using System.Collections.Generic;
using System.Linq;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models.Fluent
{
    public class QueryRecordsByAppPagedRequestBuilderOptions
    {
        public int PageNumber { get; private set; } = 1;
        public int PageSize { get; private set; } = 50;
        public IEnumerable<int> FieldIds { get; private set; } = Enumerable.Empty<int>();
        public DataFormat Format { get; private set; } = DataFormat.Raw;
    }
}