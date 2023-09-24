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
    public class GetRecordsByAppPagedRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static GetRecordsByAppPagedRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetRecordsByAppPagedRequestBuilder(_client, 1, 1);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var appId = 1;
            var pageNumber = 1;
            var builder = new GetRecordsByAppPagedRequestBuilder(_client, appId, pageNumber);

            Assert.IsInstanceOfType<IGetRecordsByAppPagedRequestBuilder>(builder);
            Assert.AreEqual(appId, builder.AppId);
            Assert.AreEqual(pageNumber, builder.PageNumber);
            Assert.AreEqual(Enumerable.Empty<int>(), builder.FieldIds);
            Assert.AreEqual(DataFormat.Raw, builder.Format);
            Assert.AreEqual(50, builder.PageSize);
        }

        [TestMethod]
        public void WithPageSize_WhenCalled_ItShouldSetInstancesPageSize()
        {
            var pageSize = 1;

            _builder.WithPageSize(pageSize);

            Assert.AreEqual(pageSize, _builder.PageSize);
        }


        [TestMethod]
        public void WithFieldIds_WhenCalled_ItShouldSetInstancesFieldIds()
        {
            var fieldIds = new int[] { 1, 2, 4 };

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
            var apiResponse = new ApiResponse<GetPagedRecordsResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetPagedRecordsResponse(),
            };

            _client
                .GetRecordsForAppAsync(Arg.Any<GetRecordsByAppRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalledWithOptions_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<GetPagedRecordsResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetPagedRecordsResponse(),
            };

            _client
                .GetRecordsForAppAsync(Arg.Any<GetRecordsByAppRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync(options =>
            {
                options.PageSize = 10;
                options.FieldIds = new[] { 1, 2, 3 };
                options.Format = DataFormat.Raw;
            });

            Assert.AreEqual(apiResponse, result);
        }
    }
}