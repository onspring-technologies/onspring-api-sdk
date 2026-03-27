using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringRequestTests
    {
        private static OnspringRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var apiClientMock = Substitute.For<IOnspringClient>();
            _builder = new OnspringRequestBuilder(apiClientMock);
        }

        [TestMethod]
        public void ToGetRecords_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToGetRecords();

            Assert.IsInstanceOfType<IGetRecordsRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToCheckConnection_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToCheckConnection();

            Assert.IsInstanceOfType<IConnectionRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToSaveRecord_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToSaveRecord();

            Assert.IsInstanceOfType<ISaveRecordRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToDeleteRecords_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToDeleteRecords();

            Assert.IsInstanceOfType<IDeleteRecordsRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToGetReports_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToGetReports();

            Assert.IsInstanceOfType<IGetReportsByAppRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToGetReportData_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToGetReportData();

            Assert.IsInstanceOfType<IGetReportRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToGetFile_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToGetFile();

            Assert.IsInstanceOfType<IGetFileRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToGetFileInfo_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToGetFileInfo();

            Assert.IsInstanceOfType<IGetFileInfoRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToDeleteFile_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToDeleteFile();

            Assert.IsInstanceOfType<IDeleteFileRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToAddFile_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToAddFile();

            Assert.IsInstanceOfType<IAddFileRequestBuilder>(builder);
        }

        [TestMethod]
        public void ToGetFields_WhenCalled_ShouldReturnBuilderInstance()
        {
            var builder = _builder.ToGetFields();

            Assert.IsInstanceOfType<IGetFieldsRequestBuilder>(builder);
        }
    }
}