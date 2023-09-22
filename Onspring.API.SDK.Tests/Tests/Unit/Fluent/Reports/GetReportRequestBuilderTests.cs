using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    public class GetReportRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static GetReportRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetReportRequestBuilder(_client);
        }

        [TestMethod]
        public void FromReport_WhenCalled_ItShouldReturnBuilderInstanceWithPropertiesSet()
        {
            var result = _builder.FromReport(1);

            Assert.IsInstanceOfType<IGetReportDataRequestBuilder>(result);
        }
    }
}