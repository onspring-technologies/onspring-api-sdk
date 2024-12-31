using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for paged requests.
    /// </summary>
    /// <inheritdoc/>
    public class PagedRequestBuilder : IPagedRequestBuilder
    {
        private readonly IOnspringClient _client;

        internal PagedRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetAllAppsPagesRequestBuilder OfApps()
        {
            return new GetAllAppsPagesRequestBuilder(_client);
        }

        public IGetAllFieldsPagesRequestBuilder OfFields()
        {
            return new GetAllFieldsPagesRequestBuilder(_client);
        }

        public IGetAllRecordsPagesRequestBuilder OfRecords()
        {
            return new GetAllRecordsPagesRequestBuilder(_client);
        }

        public IGetAllReportsPagesRequestBuilder OfReports()
        {
            return new GetAllReportsPagesRequestBuilder(_client);
        }
    }
}
