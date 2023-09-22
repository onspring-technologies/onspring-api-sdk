using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetRecordsByAppRequestBuilderTests
    {
        private static IOnspringClient _client;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
        }

        [TestMethod]
        public void Constructor_WhenCalled_ReturnsInstanceOfBuilder()
        {
            var appId = 1;
            var builder = new GetRecordsByAppRequestBuilder(_client, appId);

            Assert.AreEqual(appId, builder.AppId);
        }

        [TestMethod]
        public void ForPage_WhenCalled_ReturnsInstanceOfPagedAppBuilderWithPropetiesSet()
        {
            var appId = 1;
            var pageNumber = 1;
            var builder = new GetRecordsByAppRequestBuilder(_client, appId);

            var pagedBuilder = builder.ForPage(pageNumber);

            Assert.IsInstanceOfType<IGetRecordsByAppPagedRequestBuilder>(pagedBuilder);
            Assert.AreEqual(appId, pagedBuilder.AppId);
            Assert.AreEqual(pageNumber, pagedBuilder.PageNumber);
        }

        [TestMethod]
        public void WithId_WhenCalled_ReturnsRecordByIdBuilderWithPropertiesSet()
        {
            var appId = 1;
            var recordId = 1;
            var builder = new GetRecordsByAppRequestBuilder(_client, appId);

            var recordByIdBuilder = builder.WithId(recordId);

            Assert.IsInstanceOfType<IGetRecordByIdRequestBuilder>(recordByIdBuilder);
            Assert.AreEqual(appId, recordByIdBuilder.AppId);
            Assert.AreEqual(recordId, recordByIdBuilder.RecordId);
        }

        [TestMethod]
        public void WithIds_WhenCalled_ReturnsRecordsByIdsBuilderWithPropertiesSet()
        {
            var appId = 1;
            var recordIds = new[] { 1, 2, 3 };
            var builder = new GetRecordsByAppRequestBuilder(_client, appId);

            var recordsByIdsBuilder = builder.WithIds(recordIds);

            Assert.IsInstanceOfType<IGetRecordsByIdsRequestBuilder>(recordsByIdsBuilder);
            Assert.AreEqual(appId, recordsByIdsBuilder.AppId);
            Assert.AreEqual(recordIds, recordsByIdsBuilder.RecordIds);
        }

        [TestMethod]
        public void WithFilter_WhenCalledWithFilterString_ReturnsQueryRecordsBuilderWithPropertiesSet()
        {
            var appId = 1;
            var filter = new Filter(1, FilterOperator.Equal, 1);
            var builder = new GetRecordsByAppRequestBuilder(_client, appId);

            var queryRecordsBuilder = builder.WithFilter(filter.ToString());

            Assert.IsInstanceOfType<IQueryRecordsByAppPagedRequestBuilder>(queryRecordsBuilder);
            Assert.AreEqual(appId, queryRecordsBuilder.AppId);
            Assert.AreEqual(filter.ToString(), queryRecordsBuilder.Filter);
        }

        [TestMethod]
        public void WithFilter_WhenCalledWithFilterAction_ReturnsQueryRecordsBuilderWithPropertiesSet()
        {
            var appId = 1;
            var filter = new Filter(1, FilterOperator.Equal, 1);
            var builder = new GetRecordsByAppRequestBuilder(_client, appId);

            var queryRecordsBuilder = builder.WithFilter(f =>
            {
                f.FieldId = filter.FieldId;
                f.Operator = filter.Operator;
                f.Value = filter.Value;
            });

            Assert.IsInstanceOfType<IQueryRecordsByAppPagedRequestBuilder>(queryRecordsBuilder);
            Assert.AreEqual(appId, queryRecordsBuilder.AppId);
            Assert.AreEqual(filter.ToString(), queryRecordsBuilder.Filter);
        }
    }
}