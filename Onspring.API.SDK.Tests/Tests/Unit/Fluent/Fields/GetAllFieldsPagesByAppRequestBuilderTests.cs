using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetAllFieldsPagesByAppRequestBuilderTests
    {
        private static readonly int _appId = 1;
        private static IOnspringClient _client;
        private static GetAllFieldsPagesByAppRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetAllFieldsPagesByAppRequestBuilder(_client, _appId);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnInstanceWithPropertiesSet()
        {
            var builder = new GetAllFieldsPagesByAppRequestBuilder(_client, _appId);

            Assert.IsInstanceOfType<GetAllFieldsPagesByAppRequestBuilder>(builder);
            Assert.AreEqual(_appId, builder.AppId);
        }

        [TestMethod]
        public void WithPageSize_WhenCalled_ItShouldReturnInstanceWithPageSizeSet()
        {
            var pageSize = 100;

            var result = _builder.WithPageSize(pageSize);

            Assert.IsInstanceOfType<GetAllFieldsPagesByAppRequestBuilder>(result);
            Assert.AreEqual(pageSize, result.PageSize);
        }

        [TestMethod]
        public void SendAsync_WhenCalled_ItShouldReturnAsyncEnumerable()
        {
            var result = _builder.SendAsync();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<IAsyncEnumerable<ApiResponse<GetPagedFieldsResponse>>>(result);
        }

        [TestMethod]
        public void SendAsyncWithOptions_WhenCalled_ItShouldReturnAsyncEnumerable()
        {
            var result = _builder.SendAsync(options => options.PageSize = 100);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<IAsyncEnumerable<ApiResponse<GetPagedFieldsResponse>>>(result);
        }
    }
}