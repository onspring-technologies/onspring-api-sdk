using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetAppsRequestBuilderTests
    {
        private static readonly int _pageNumber = 1;
        private static readonly int _appId = 1;
        private static readonly IEnumerable<int> _appIds = new[] { 1, 2, 3 };
        private static IOnspringClient _client;
        private static GetAppsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetAppsRequestBuilder(_client);
        }

        [TestMethod]
        public void ForPage_WhenCalled_ItShouldReturnBuilderInstanceWithPropertiesSet()
        {
            var builder = _builder.ForPage(_pageNumber);

            Assert.IsInstanceOfType<IGetPagedAppsRequestBuilder>(builder);
            Assert.AreEqual(_pageNumber, builder.PageNumber);
        }

        [TestMethod]
        public void WithIds_WhenCalled_ItShouldReturnBuilderInstanceWithPropertiesSet()
        {
            var builder = _builder.WithIds(_appIds);

            Assert.IsInstanceOfType<IGetAppsByIdsRequestBuilder>(builder);
            Assert.AreEqual(_appIds, builder.AppIds);
        }

        [TestMethod]
        public void WithId_WhenCalled_ItShouldReturnBuilderInstanceWithPropertiesSet()
        {
            var builder = _builder.WithId(_appId);

            Assert.IsInstanceOfType<IGetAppByIdRequestBuilder>(builder);
            Assert.AreEqual(_appId, builder.AppId);
        }
    }
}