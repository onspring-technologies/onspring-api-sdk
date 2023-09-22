using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringRequestTests
    {
        private static OnspringRequest _onspringRequest;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var apiClientMock = Substitute.For<IOnspringClient>();
            _onspringRequest = new OnspringRequest(apiClientMock);
        }

        [TestMethod]
        public void ToGetRecords_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _onspringRequest.ToGetRecords();

            Assert.IsInstanceOfType<IGetRecordsRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToCheckConnection_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _onspringRequest.ToCheckConnection();

            Assert.IsInstanceOfType<IConnectionRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToSaveRecord_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _onspringRequest.ToSaveRecord();

            Assert.IsInstanceOfType<ISaveRecordRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToDeleteRecords_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _onspringRequest.ToDeleteRecords();

            Assert.IsInstanceOfType<IDeleteRecordsRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToGetReports_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _onspringRequest.ToGetReports();

            Assert.IsInstanceOfType<IGetReportsByAppRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToGetReportData_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _onspringRequest.ToGetReportData();

            Assert.IsInstanceOfType<IGetReportRequestBuilder>(builder);
        }
    }
}