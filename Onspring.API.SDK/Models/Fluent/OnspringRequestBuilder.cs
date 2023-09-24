using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing Onspring API requests.
    /// </summary>
    /// <inheritdoc/>
    public class OnspringRequestBuilder : IOnspringRequestBuilder
    {
        private readonly IOnspringClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnspringRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The Onspring client to use for making API requests.</param>
        internal OnspringRequestBuilder(IOnspringClient client)
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

        public IGetFileRequestBuilder ToGetFile()
        {
            return new GetFileRequestBuilder(_client);
        }

        public IGetFileInfoRequestBuilder ToGetFileInfo()
        {
            return new GetFileInfoRequestBuilder(_client);
        }

        public IDeleteFileRequestBuilder ToDeleteFile()
        {
            return new DeleteFileRequestBuilder(_client);
        }

        public IAddFileRequestBuilder ToAddFile()
        {
            return new AddFileRequestBuilder(_client);
        }

        public IGetFieldsRequestBuilder ToGetFields()
        {
            return new GetFieldsRequestBuilder(_client);
        }

        public IGetAppsRequestBuilder ToGetApps()
        {
            return new GetAppsRequestBuilder(_client);
        }
    }
}