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

    public class GetPagedAppsRequestBuilderTests
    {
        private static readonly int _pageNumber = 1;
        private static IOnspringClient _client;
        private static GetPagedAppsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetPagedAppsRequestBuilder(_client, _pageNumber);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var builder = new GetPagedAppsRequestBuilder(_client, _pageNumber);

            Assert.IsInstanceOfType<IGetPagedAppsRequestBuilder>(builder);
            Assert.AreEqual(_pageNumber, builder.PageNumber);
        }

        [TestMethod]
        public void WithPageSize_WhenCalled_ItShouldSetPageSizeProperty()
        {
            var pageSize = 5;

            _builder.WithPageSize(pageSize);

            Assert.AreEqual(pageSize, _builder.PageSize);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<GetPagedAppsResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetPagedAppsResponse(),
            };

            _client
                .GetAppsAsync(Arg.Any<PagingRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }
    }
}