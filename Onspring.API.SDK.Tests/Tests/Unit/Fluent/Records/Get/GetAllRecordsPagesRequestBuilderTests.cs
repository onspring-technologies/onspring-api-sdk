using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetAllRecordsPagesRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static GetAllRecordsPagesRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetAllRecordsPagesRequestBuilder(_client);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstance()
        {
            var builder = new GetAllRecordsPagesRequestBuilder(_client);

            Assert.IsNotNull(builder);
            Assert.IsInstanceOfType<GetAllRecordsPagesRequestBuilder>(builder);
        }

        [TestMethod]
        public void FromApp_WhenCalled_ItShouldReturnAnInstance()
        {
            var appId = 1;
            var builder = _builder.FromApp(appId);

            Assert.IsNotNull(builder);
            Assert.IsInstanceOfType<GetAllRecordsPagesByAppRequestBuilder>(builder);
        }
    }
}