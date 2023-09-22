using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetRecordsRequestBuilderTests
    {
        private static GetRecordsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var apiClientMock = Substitute.For<IOnspringClient>();
            _builder = new GetRecordsRequestBuilder(apiClientMock);
        }

        [TestMethod]
        public void FromApp_WhenCalled_ShouldReturnAGetRecordsByAppRequestBuilderInstanceWithAppIdSetToCorrectValue()
        {
            var appId = 1;
            var builder = _builder.FromApp(appId);

            Assert.IsInstanceOfType<IGetRecordsByAppRequestBuilder>(builder);
            Assert.AreEqual(appId, builder.AppId);
        }
    }
}