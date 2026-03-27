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
    public class GetAllReportsPagesRequestBuilderTests
    {
        private static readonly int _appId = 1;
        private static IOnspringClient _client;
        private static GetAllReportsPagesRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetAllReportsPagesRequestBuilder(_client);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnBuilderInstance()
        {
            Assert.IsInstanceOfType<GetAllReportsPagesRequestBuilder>(_builder);
        }

        [TestMethod]
        public void FromApp_WhenCalled_ItShouldReturnGetAllReportsPagesByAppRequestBuilderInstance()
        {
            var result = _builder.FromApp(_appId);

            Assert.IsInstanceOfType<GetAllReportsPagesByAppRequestBuilder>(result);
        }
    }
}