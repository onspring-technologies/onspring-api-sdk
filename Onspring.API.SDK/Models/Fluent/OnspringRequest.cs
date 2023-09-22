using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class OnspringRequest : IOnspringRequest
    {
        private readonly IOnspringClient _client;

        internal OnspringRequest(IOnspringClient client)
        {
            _client = client;
        }

        public IConnectionRequestBuilder ToCheckConnection()
        {
            return new ConnectionRequestBuilder(_client);
        }

        public IGetRecordsRequestBuilder ToGetRecords()
        {
            return new GetRecordsRequestBuilder(_client);
        }

        public ISaveRecordRequestBuilder ToSaveRecord()
        {
            return new SaveRecordRequestBuilder(_client);
        }

        public IDeleteRecordsRequestBuilder ToDeleteRecords()
        {
            return new DeleteRecordsRequestBuilder(_client);
        }

        public IGetReportsByAppRequestBuilder ToGetReports()
        {
            return new GetReportsRequestBuilder(_client);
        }

        public IGetReportRequestBuilder ToGetReportData()
        {
            return new GetReportRequestBuilder(_client);
        }

        public ISaveListValueRequestBuilder ToSaveListValue()
        {
            return new SaveListValueRequestBuilder(_client);
        }

        public IDeleteListValueRequestBuilder ToDeleteListValue()
        {
            return new DeleteListValueRequestBuilder(_client);
        }
    }
}