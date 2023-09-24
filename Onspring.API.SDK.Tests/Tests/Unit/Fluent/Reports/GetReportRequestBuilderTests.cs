using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetReportRequestBuilderTests
    {
        private static readonly int _reportId = 1;
        private static IOnspringClient _client;
        private static GetReportRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetReportRequestBuilder(_client);
        }

        [TestMethod]
        public void FromReport_WhenCalled_ItShouldReturnBuilderInstanceWithPropertiesSet()
        {
            var reportId = 1;

            var builder = _builder.FromReport(reportId);

            Assert.IsInstanceOfType<IGetReportDataRequestBuilder>(builder);
            Assert.AreEqual(reportId, builder.ReportId);
            Assert.AreEqual(DataFormat.Raw, builder.Format);
            Assert.AreEqual(ReportDataType.ReportData, builder.DataType);
        }

        [TestMethod]
        public void WithFormat_WhenCalled_ItShouldSetFormatProperty()
        {
            var format = DataFormat.Formatted;

            _builder.WithFormat(format);

            Assert.AreEqual(format, _builder.Format);
        }

        [TestMethod]
        public void WithDataType_WhenCalled_ItShouldSetDataTypeProperty()
        {
            var dataType = ReportDataType.ChartData;

            _builder.WithDataType(dataType);

            Assert.AreEqual(dataType, _builder.DataType);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<ReportData>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new ReportData(),
            };

            _client
                .GetReportAsync(
                    Arg.Any<int>(),
                    Arg.Any<ReportDataType>(),
                    Arg.Any<DataFormat>()
                )
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalledWithOptions_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<ReportData>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new ReportData(),
            };

            _client
                .GetReportAsync(
                    Arg.Any<int>(),
                    Arg.Any<ReportDataType>(),
                    Arg.Any<DataFormat>()
                )
                .Returns(apiResponse);

            var format = DataFormat.Formatted;
            var dataType = ReportDataType.ChartData;

            var result = await _builder.SendAsync(options =>
            {
                options.Format = format;
                options.DataType = dataType;
            });

            Assert.AreEqual(apiResponse, result);

            await _client
                .Received()
                .GetReportAsync(
                    _reportId,
                    dataType,
                    format
                );
        }
    }
}