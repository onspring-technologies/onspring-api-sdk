using System.Collections.Generic;
using System.Linq;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents the options for a request to get records by an app.
    /// </summary>
    public class GetRecordsByAppPagedRequestBuilderOptions
    {
        /// <summary>
        /// Gets or sets the IDs of the fields to retrieve.
        /// </summary>
        public IEnumerable<int> FieldIds { get; set; } = Enumerable.Empty<int>();

        /// <summary>
        /// Gets or sets the data format for the response.
        /// </summary>
        public DataFormat Format { get; set; } = DataFormat.Raw;

        /// <summary>
        /// Gets or sets the page size for the paged request. Default is 50.
        /// </summary>
        public int PageSize { get; set; } = 50;
    }
}