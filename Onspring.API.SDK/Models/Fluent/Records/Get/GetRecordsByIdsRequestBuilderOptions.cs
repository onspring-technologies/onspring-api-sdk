using Onspring.API.SDK.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents options for building requests to get records by IDs.
    /// </summary>
    public class GetRecordsByIdsRequestBuilderOptions
    {
        /// <summary>
        /// Gets or sets the IDs of the fields to retrieve. Default is an empty collection.
        /// </summary>
        public IEnumerable<int> FieldIds { get; set; } = Enumerable.Empty<int>();

        /// <summary>
        /// Gets or sets the data format for the query results. Default is <see cref="DataFormat.Raw"/> .
        /// </summary>
        public DataFormat Format { get; set; } = DataFormat.Raw;
    }
}