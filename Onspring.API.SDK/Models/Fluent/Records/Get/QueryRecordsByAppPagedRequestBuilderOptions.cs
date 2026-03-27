using Onspring.API.SDK.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents options for building paged requests to query records by application.
    /// </summary>
    public class QueryRecordsByAppPagedRequestBuilderOptions
    {
        /// <summary>
        /// Gets or sets the page number for the paged request. Default is 1.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the page size for the paged request. Default is 50.
        /// </summary>
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// Gets or sets the field IDs to include in the query. Default is an empty collection.
        /// </summary>
        public IEnumerable<int> FieldIds { get; set; } = Enumerable.Empty<int>();

        /// <summary>
        /// Gets or sets the data format for the query results. Default is <see cref="DataFormat.Raw"/> .
        /// </summary>
        public DataFormat Format { get; set; } = DataFormat.Raw;
    }
}