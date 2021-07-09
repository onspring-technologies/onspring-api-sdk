using Newtonsoft.Json;
using System;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request to add a list item to an existing list.
    /// </summary>
    public class SaveListItemRequest
    {
        /// <summary>
        /// Gets or sets the identifier of the list.
        /// </summary>
        [JsonIgnore]
        public int ListId { get; set; }

        /// <summary>
        /// Represents the identifier of the list item, if any. For inserting list items, this should be null.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Name of the list item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Numeric value of the list item, if any.
        /// </summary>
        public decimal? NumericValue { get; set; }

        /// <summary>
        /// Color of the list item. Must be in hexadecimal format.
        /// Default value is #ffffff.
        /// </summary>
        /// <example>#ffffff</example>
        public string Color { get; set; } = "#ffffff";

        /// <summary>
        /// Optional value indicating the weight of this item.
        /// </summary>
        public int Weight { get; set; }
    }
}
