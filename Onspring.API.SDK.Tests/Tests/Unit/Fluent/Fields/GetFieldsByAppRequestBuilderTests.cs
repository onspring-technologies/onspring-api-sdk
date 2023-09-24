using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetFieldsByAppRequestBuilderTests
    {
        private static readonly int _appId = 1;
        private static readonly int _pageNumber = 2;
        private static readonly int _pageSize = 25;
        private static IOnspringClient _client;
        private static GetFieldsByAppRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetFieldsByAppRequestBuilder(_client, _appId);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnInstanceWithPropertiesSet()
        {
            var builder = new GetFieldsByAppRequestBuilder(_client, _appId);

            Assert.IsInstanceOfType<IGetFieldsByAppRequestBuilder>(builder);
            Assert.AreEqual(_appId, builder.AppId);
        }

        [TestMethod]
        public void ForPage_WhenCalled_ItShouldSetPageNumberProperty()
        {
            _builder.ForPage(_pageNumber);

            Assert.AreEqual(_pageNumber, _builder.PageNumber);
        }

        [TestMethod]
        public void WithPageSize_WhenCalled_ItShouldSetPageSizeProperty()
        {
            _builder.WithPageSize(_pageSize);

            Assert.AreEqual(_pageSize, _builder.PageSize);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<GetPagedFieldsResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetPagedFieldsResponse(),
            };

            _client
                .GetFieldsForAppAsync(Arg.Any<int>(), Arg.Any<PagingRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalledWithOptions_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<GetPagedFieldsResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetPagedFieldsResponse(),
            };

            _client
                .GetFieldsForAppAsync(Arg.Any<int>(), Arg.Any<PagingRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync(options =>
            {
                options.PageNumber = 2;
                options.PageSize = 25;
            });

            Assert.AreEqual(apiResponse, result);
        }
    }
}