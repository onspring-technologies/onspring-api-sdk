using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a response to saving a record.
    /// </summary>
    public class SaveRecordResponse : CreatedWithIdResponse<int>
    {
        public List<string> Warnings { get; set; } = new List<string>();
    }
}
