using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetRecordByIdRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static GetRecordByIdRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetRecordByIdRequestBuilder(_client, 1, 1);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var appId = 1;
            var recordId = 1;
            var builder = new GetRecordByIdRequestBuilder(_client, appId, recordId);

            Assert.IsInstanceOfType<IGetRecordByIdRequestBuilder>(builder);
            Assert.AreEqual(appId, builder.AppId);
            Assert.AreEqual(recordId, builder.RecordId);
            Assert.AreEqual(Enumerable.Empty<int>(), builder.FieldIds);
            Assert.AreEqual(DataFormat.Raw, builder.Format);
        }

        [TestMethod]
        public void WithFieldIds_WhenCalled_ItShouldSetInstancesFieldIds()
        {
            var fieldIds = new[] { 1, 2, 4, };

            _builder.WithFieldIds(fieldIds);

            Assert.AreEqual(fieldIds, _builder.FieldIds);
        }

        [TestMethod]
        public void WithFormat_WhenCalled_ItShouldSetInstancesFormat()
        {
            var fieldIds = new[] { 1, 2, 4, };

            _builder.WithFormat(DataFormat.Formatted);

            Assert.AreEqual(DataFormat.Formatted, _builder.Format);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnApiResponse()
        {
            var apiResponse = new ApiResponse<ResultRecord>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new ResultRecord(),
            };

            _client
                .GetRecordAsync(Arg.Any<GetRecordRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalledWithOptions_ItShouldReturnApiResponse()
        {
            var apiResponse = new ApiResponse<ResultRecord>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new ResultRecord(),
            };

            _client
                .GetRecordAsync(Arg.Any<GetRecordRequest>())
                .Returns(apiResponse);

            var result = await _builder
                .SendAsync(options =>
                {
                    options.Format = DataFormat.Raw;
                });

            Assert.AreEqual(apiResponse, result);
        }
    }
}