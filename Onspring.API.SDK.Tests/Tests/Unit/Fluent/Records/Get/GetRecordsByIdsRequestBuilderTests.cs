using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetRecordsByIdsRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static GetRecordsByIdsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetRecordsByIdsRequestBuilder(_client, 1, new[] { 1, 2, 3 });
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var appId = 1;
            var recordIds = new[] { 1, 2, 3 };
            var builder = new GetRecordsByIdsRequestBuilder(_client, appId, recordIds);

            Assert.IsInstanceOfType<IGetRecordsByIdsRequestBuilder>(builder);
            Assert.AreEqual(appId, builder.AppId);
            Assert.AreEqual(recordIds, builder.RecordIds);
            Assert.AreEqual(Enumerable.Empty<int>(), builder.FieldIds);
            Assert.AreEqual(DataFormat.Raw, builder.Format);
        }

        [TestMethod]
        public void WithFieldIds_WhenCalled_ItShouldSetInstancesFieldIds()
        {
            var fieldIds = new[] { 1, 2, 3 };

            _builder.WithFieldIds(fieldIds);

            Assert.AreEqual(fieldIds, _builder.FieldIds);
        }

        [TestMethod]
        public void WithFormat_WhenCalled_ItShouldSetInstancesFormat()
        {
            var format = DataFormat.Formatted;

            _builder.WithFormat(format);

            Assert.AreEqual(format, _builder.Format);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<GetRecordsResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetRecordsResponse(),
            };

            _client
                .GetRecordsAsync(Arg.Any<GetRecordsRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalledWithOptions_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<GetRecordsResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetRecordsResponse(),
            };

            _client
                .GetRecordsAsync(Arg.Any<GetRecordsRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync(options =>
            {
                options.FieldIds = new[] { 1, 2, 3 };
                options.Format = DataFormat.Raw;
            });

            Assert.AreEqual(apiResponse, result);
        }
    }
}