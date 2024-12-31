using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetAllFieldsPagesRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static GetAllFieldsPagesRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetAllFieldsPagesRequestBuilder(_client);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnInstance()
        {
            var builder = new GetAllFieldsPagesRequestBuilder(_client);

            Assert.IsInstanceOfType<GetAllFieldsPagesRequestBuilder>(builder);
        }

        [TestMethod]
        public void FromApp_WhenCalled_ItShouldReturnInstance()
        {
            var result = _builder.FromApp(1);

            Assert.IsInstanceOfType<GetAllFieldsPagesByAppRequestBuilder>(result);
        }
    }
}