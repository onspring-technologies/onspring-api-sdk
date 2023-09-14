using System.Collections.Generic;
using System.Linq;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetRecordByIdRequestBuilderOptions
    {
        public IEnumerable<int> FieldIds { get; set; } = Enumerable.Empty<int>();
        public DataFormat DataFormat { get; set; } = DataFormat.Raw;
    }
}