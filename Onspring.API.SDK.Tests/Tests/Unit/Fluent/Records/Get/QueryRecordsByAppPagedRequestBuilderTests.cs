using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class QueryRecordsByAppPagedRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static QueryRecordsByAppPagedRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new QueryRecordsByAppPagedRequestBuilder(_client, 1, "filter");
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnInstanceWithPropertiesSet()
        {
            var appId = 1;
            var filter = "filter";
            var builder = new QueryRecordsByAppPagedRequestBuilder(_client, appId, filter);

            Assert.AreEqual(appId, builder.AppId);
            Assert.AreEqual(filter, builder.Filter);
            Assert.AreEqual(1, builder.PageNumber);
            Assert.AreEqual(50, builder.PageSize);
            Assert.AreEqual(Enumerable.Empty<int>(), builder.FieldIds);
            Assert.AreEqual(DataFormat.Raw, builder.Format);
        }

        [TestMethod]
        public void ForPageNumber_WhenCalled_ItShouldSetPageNumberProperty()
        {
            var pageNumber = 2;

            _builder.ForPageNumber(pageNumber);

            Assert.AreEqual(pageNumber, _builder.PageNumber);
        }

        [TestMethod]
        public void WithPageSize_WhenCalled_ItShouldSetPageSizeProperty()
        {
            var pageSize = 1;

            _builder.WithPageSize(pageSize);

            Assert.AreEqual(pageSize, _builder.PageSize);
        }

        [TestMethod]
        public void WithFieldIds_WhenCalled_ItShouldSetFieldIdsProperty()
        {
            var fieldIds = new int[] { 1, 2, 3 };

            _builder.WithFieldIds(fieldIds);

            Assert.AreEqual(fieldIds, _builder.FieldIds);
        }

        [TestMethod]
        public void WithFormat_WhenCalled_ItShouldSetFormatProperty()
        {
            var format = DataFormat.Raw;

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
                .QueryRecordsAsync(Arg.Any<QueryRecordsRequest>(), Arg.Any<PagingRequest>())
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
                .QueryRecordsAsync(Arg.Any<QueryRecordsRequest>(), Arg.Any<PagingRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync(options =>
            {
                options.PageNumber = 2;
                options.PageSize = 100;
                options.Format = DataFormat.Formatted;
                options.FieldIds = new[] { 1 };
            });

            Assert.AreEqual(apiResponse, result);
        }
    }
}