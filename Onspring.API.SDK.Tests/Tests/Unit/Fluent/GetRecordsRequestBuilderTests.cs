using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            _builder = new OnspringClient("https://api.onspring.com", "key")
                .CreateRequest()
                .ToGetRecords();
        }

        [TestMethod]
        public void FromApp_WhenCalled_ShouldReturnAGetRecordsByAppRequestBuilderInstanceWithAppIdSetToCorrectValue()
        {
            var appId = 1;
            var builder = _builder.FromApp(appId);

            Assert.IsInstanceOfType<GetRecordsByAppRequestBuilder>(builder);
            Assert.AreEqual(appId, builder.AppId);
        }
    }
}