using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DeleteRecordsRequestBuilderTests
    {
        private static DeleteRecordsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var apiClientMock = Substitute.For<IOnspringClient>();
            _builder = new DeleteRecordsRequestBuilder(apiClientMock);
        }

        [TestMethod]
        public void FromApp_WhenCalled_ShouldReturnADeleteRecordsByAppRequestBuilderInstanceWithAppIdSetToCorrectValue()
        {
            var appId = 1;
            var builder = _builder.FromApp(appId);

            Assert.IsInstanceOfType<IDeleteRecordsByAppRequestBuilder>(builder);
            Assert.AreEqual(appId, builder.AppId);
        }
    }
}