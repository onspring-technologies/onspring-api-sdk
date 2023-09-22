using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetReportRequestBuilder : IGetReportRequestBuilder, IGetReportDataRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int ReportId { get; private set; }
        public DataFormat Format { get; private set; }
        public ReportDataType DataType { get; private set; }

        internal GetReportRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetReportDataRequestBuilder FromReport(int reportId)
        {
            ReportId = reportId;
            return this;
        }

        public IGetReportDataRequestBuilder WithDataType(ReportDataType dataType)
        {
            DataType = dataType;
            return this;
        }

        public IGetReportDataRequestBuilder WithFormat(DataFormat format)
        {
            Format = format;
            return this;
        }

        public async Task<ApiResponse<ReportData>> SendAsync()
        {
            return await _client.GetReportAsync(ReportId, DataType, Format);
        }

        public async Task<ApiResponse<ReportData>> SendAsync(Action<GetReportBuilderOptions> options)
        {
            var opts = new GetReportBuilderOptions();
            options.Invoke(opts);
            return await _client.GetReportAsync(ReportId, opts.DataType, opts.Format);
        }
    }
}