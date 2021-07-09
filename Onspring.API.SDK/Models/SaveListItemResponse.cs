using System;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents the response for saving a list item.
    /// </summary>
    public class SaveListItemResponse : CreatedWithIdResponse<Guid>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SaveListItemResponse"/>.
        /// </summary>
        public SaveListItemResponse(Guid id)
            : base(id)
        {
        }
    }
}
