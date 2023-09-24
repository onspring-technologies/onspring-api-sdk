using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetAppsByIdsRequestBuilderTests
    {
        private static readonly IEnumerable<int> _appIds = new[] { 1, 2, 3 };
        private static IOnspringClient _client;
        private static GetAppsByIdsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetAppsByIdsRequestBuilder(_client, _appIds);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var builder = new GetAppsByIdsRequestBuilder(_client, _appIds);

            Assert.IsInstanceOfType<IGetAppsByIdsRequestBuilder>(builder);
            Assert.AreEqual(_appIds, builder.AppIds);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<GetAppsResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetAppsResponse(),
            };

            _client
                .GetAppsAsync(Arg.Any<IEnumerable<int>>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }
    }
}