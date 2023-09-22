using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetReportDataRequestBuilder : IGetReportDataRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int ReportId { get; private set; }
        public DataFormat Format { get; private set; } = DataFormat.Raw;
        public ReportDataType DataType { get; private set; } = ReportDataType.ReportData;

        internal GetReportDataRequestBuilder(IOnspringClient client, int reportId)
        {
            _client = client;
            ReportId = reportId;
        }

        public IGetReportDataRequestBuilder WithFormat(DataFormat format)
        {
            Format = format;
            return this;
        }

        public IGetReportDataRequestBuilder WithDataType(ReportDataType dataType)
        {
            DataType = dataType;
            return this;
        }

        public async Task<ApiResponse<ReportData>> SendAsync()
        {
            return await _client.GetReportAsync(ReportId, DataType, Format);
        }

        public async Task<ApiResponse<ReportData>> SendAsync(Action<GetReportDataRequestBuilderOptions> options)
        {
            var opts = new GetReportDataRequestBuilderOptions();
            options.Invoke(opts);
            return await _client.GetReportAsync(ReportId, opts.DataType, opts.Format);
        }
    }
}