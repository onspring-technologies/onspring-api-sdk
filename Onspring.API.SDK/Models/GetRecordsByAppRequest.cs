using Onspring.API.SDK.Enums;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a request to get records for a given app.
    /// </summary>
    public class GetRecordsByAppRequest
    {
        public int AppId { get; set; }
        public List<int> FieldIds { get; set; } = new List<int>();
        public DataFormat DataFormat { get; set; } = DataFormat.Raw;
        public PagingRequest PagingRequest { get; set; } = null;

        public GetRecordsByAppRequest()
        {
        }

        public GetRecordsByAppRequest(int appId)
        {
            AppId = appId;
        }

        public GetRecordsByAppRequest(int appId, PagingRequest pagingRequest)
        {
            AppId = appId;
            PagingRequest = pagingRequest;
        }
    }
}
