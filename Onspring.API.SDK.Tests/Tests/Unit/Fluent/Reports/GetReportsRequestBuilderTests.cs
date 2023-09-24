using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetReportsRequestBuilderTests
    {
        private static readonly int _appId = 1;
        private static readonly int _pageNumber = 2;
        private static readonly int _pageSize = 100;
        private static IOnspringClient _client;
        private static GetReportsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetReportsRequestBuilder(_client);
        }

        [TestMethod]
        public void FromApp_WhenCalled_ItShouldSetAppIdProperty()
        {
            _builder.FromApp(_appId);

            Assert.AreEqual(_appId, _builder.AppId);
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
        public async Task SendAsync_WhenCalled_ItShouldReturnApiResponse()
        {
            var apiResponse = new ApiResponse<GetReportsForAppResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetReportsForAppResponse(),
            };

            _client
                .GetReportsForAppAsync(Arg.Any<int>(), Arg.Any<PagingRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalledWithOptions_ItShouldReturnApiResponse()
        {
            var apiResponse = new ApiResponse<GetReportsForAppResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetReportsForAppResponse(),
            };

            _client
                .GetReportsForAppAsync(Arg.Any<int>(), Arg.Any<PagingRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync(options =>
            {
                options.PageNumber = _pageNumber;
                options.PageSize = _pageSize;
            });

            Assert.AreEqual(apiResponse, result);

            await _client
                .Received()
                .GetReportsForAppAsync(
                    _appId,
                    Arg.Is<PagingRequest>(
                        pr => pr.PageNumber == _pageNumber && pr.PageSize == _pageSize
                    )
                );
        }
    }
}