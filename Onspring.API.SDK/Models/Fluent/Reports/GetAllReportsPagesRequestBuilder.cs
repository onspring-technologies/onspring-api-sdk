using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for requests to get all pages of reports.
    /// </summary>
    /// <inheritdoc/>
    public class GetAllReportsPagesRequestBuilder : IGetAllReportsPagesRequestBuilder
    {
        private readonly IOnspringClient _client;

        internal GetAllReportsPagesRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetAllReportsPagesByAppRequestBuilder FromApp(int appId)
        {
            return new GetAllReportsPagesByAppRequestBuilder(_client, appId);
        }
    }
}