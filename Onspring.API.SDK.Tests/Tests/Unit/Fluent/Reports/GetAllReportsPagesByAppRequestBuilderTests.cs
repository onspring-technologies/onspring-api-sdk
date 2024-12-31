using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetAllReportsPagesByAppRequestBuilderTests
    {
        private static readonly int _appId = 1;
        private static IOnspringClient _client;
        private static GetAllReportsPagesByAppRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetAllReportsPagesByAppRequestBuilder(_client, _appId);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnBuilderInstanceWithPropertiesSet()
        {
            Assert.AreEqual(_appId, _builder.AppId);
            Assert.AreEqual(50, _builder.PageSize);
        }

        [TestMethod]
        public void WithPageSize_WhenCalled_ItShouldSetPageSizeProperty()
        {
            var pageSize = 100;

            var builder = new GetAllReportsPagesByAppRequestBuilder(_client, _appId)
                .WithPageSize(pageSize);

            Assert.AreEqual(pageSize, builder.PageSize);
        }

        [TestMethod]
        public void SendAsync_WhenCalled_ItShouldReturnAsyncEnumerable()
        {
            var result = _builder.SendAsync();

            Assert.IsInstanceOfType<IAsyncEnumerable<ApiResponse<GetReportsForAppResponse>>>(result);
        }

        [TestMethod]
        public void SendAsync_WhenCalledWithOptions_ItShouldReturnAsyncEnumerable()
        {
            var result = _builder.SendAsync(o => o.PageSize = 100);

            Assert.IsInstanceOfType<IAsyncEnumerable<ApiResponse<GetReportsForAppResponse>>>(result);
        }
    }
}