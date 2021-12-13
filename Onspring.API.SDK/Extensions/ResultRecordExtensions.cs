using Onspring.API.SDK.Models;
using System.Linq;

namespace Onspring.API.SDK.Extensions
{
    /// <summary>
    /// Extensions around <see cref="ResultRecord"/>.
    /// </summary>
    internal static class ResultRecordExtensions
    {
        /// <summary>
        /// Converts the <see cref="ResultRecord"/> to a <see cref="SaveRecordRequest"/>.
        /// </summary>
        /// <returns></returns>
        public static SaveRecordRequest ToSaveRequest(this ResultRecord record)
        {
            if (record == null)
            {
                return null;
            }

            int? recordId = record.RecordId == default ? (int?)null : record.RecordId;
            var fields = record.FieldData.ToDictionary(f => f.FieldId, f => f.GetValue());
            var saveRequest = new SaveRecordRequest
            {
                AppId = record.AppId,
                RecordId = recordId,
                Fields = fields,
            };

            return saveRequest;
        }
    }
}
