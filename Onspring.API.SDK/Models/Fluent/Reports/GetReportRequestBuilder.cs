using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetReportRequestBuilder : IGetReportRequestBuilder
    {
        private readonly IOnspringClient _client;

        internal GetReportRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetReportDataRequestBuilder FromReport(int reportId)
        {
            return new GetReportDataRequestBuilder(_client, reportId);
        }
    }
}