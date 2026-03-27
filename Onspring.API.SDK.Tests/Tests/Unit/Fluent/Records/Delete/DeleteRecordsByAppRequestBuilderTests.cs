using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DeleteRecordsByAppRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static DeleteRecordsByAppRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new DeleteRecordsByAppRequestBuilder(_client, 1);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var appId = 1;
            var builder = new DeleteRecordsByAppRequestBuilder(_client, appId);

            Assert.IsInstanceOfType<IDeleteRecordsByAppRequestBuilder>(builder);
            Assert.AreEqual(appId, builder.AppId);
        }

        [TestMethod]
        public void WithId_WhenCalled_ItShouldReturnCorrectBuilderInstanceWithPropertiesSet()
        {
            var recordId = 1;

            var builder = _builder.WithId(recordId);

            Assert.IsInstanceOfType<IDeleteRecordByIdRequestBuilder>(builder);
            Assert.AreEqual(_builder.AppId, builder.AppId);
            Assert.AreEqual(recordId, builder.RecordId);
        }

        [TestMethod]
        public void WithIds_WhenCalled_ItShouldReturnCorrectBuilderInstanceWithPropertiesSet()
        {
            var recordIds = new[] { 1, 2, 3 };

            var builder = _builder.WithIds(recordIds);

            Assert.IsInstanceOfType<IDeleteRecordsByIdsRequestBuilder>(builder);
            Assert.AreEqual(_builder.AppId, builder.AppId);
            Assert.AreEqual(recordIds, builder.RecordIds);
        }
    }
}