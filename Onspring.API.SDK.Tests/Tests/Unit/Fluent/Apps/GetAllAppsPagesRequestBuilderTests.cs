using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetAllAppsPagesRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static GetAllAppsPagesRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetAllAppsPagesRequestBuilder(_client);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstance()
        {
            var builder = new GetAllAppsPagesRequestBuilder(_client);

            Assert.IsInstanceOfType<GetAllAppsPagesRequestBuilder>(builder);
        }

        [TestMethod]
        public void WithPageSize_WhenCalled_ItShouldSetPageSize()
        {
            var pageSize = 100;

            var builder = new GetAllAppsPagesRequestBuilder(_client).WithPageSize(pageSize);

            Assert.AreEqual(pageSize, builder.PageSize);
        }

        [TestMethod]
        public void SendAsync_WhenCalled_ItShouldReturnAnAsyncEnumerableApiResponse()
        {
            var result = _builder.SendAsync();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<IAsyncEnumerable<ApiResponse<GetPagedAppsResponse>>>(result);
        }

        [TestMethod]
        public void SendAsyncWithOptions_WhenCalled_ItShouldReturnAnAsyncEnumerableApiResponse()
        {
            var result = _builder.SendAsync(options => options.PageSize = 100);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<IAsyncEnumerable<ApiResponse<GetPagedAppsResponse>>>(result);
        }
    }
}