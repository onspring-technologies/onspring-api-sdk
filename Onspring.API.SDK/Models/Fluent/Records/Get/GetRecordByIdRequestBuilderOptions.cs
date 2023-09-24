using Onspring.API.SDK.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents the options for a request to get a record by ID.
    /// </summary>
    public class GetRecordByIdRequestBuilderOptions
    {
        /// <summary>
        /// Gets or sets the IDs of the fields to retrieve.
        /// </summary>
        public IEnumerable<int> FieldIds { get; set; } = Enumerable.Empty<int>();

        /// <summary>
        /// Gets or sets the data format for the response.
        /// </summary>
        public DataFormat Format { get; set; } = DataFormat.Raw;
    }
}