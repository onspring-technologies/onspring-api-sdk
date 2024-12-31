using Onspring.API.SDK.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents the options for a request to retrieve all pages of records by query.
    /// </summary>
    public class GetAllRecordsPagesByQueryRequestBuilderOptions
    {
        /// <summary>
        /// Gets or sets the IDs of the fields to retrieve.
        /// </summary>
        public IEnumerable<int> FieldIds { get; set; } = Enumerable.Empty<int>();

        /// <summary>
        /// Gets or sets the data format to retrieve. The default is <see cref="DataFormat.Raw"/>.
        /// </summary>
        public DataFormat DataFormat { get; set; } = DataFormat.Raw;

        /// <summary>
        /// Gets or sets the page size to retrieve. The default is 50.
        /// </summary>
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// Gets or sets the filter to apply to the records.
        /// </summary>
        public string Filter { get; set; }
    }
}