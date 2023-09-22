using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DeleteRecordsByIdsRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static DeleteRecordsByIdsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new DeleteRecordsByIdsRequestBuilder(_client, 1, new[] { 1, 2, 3 });
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var appId = 1;
            var recordIds = new[] { 1, 2, 3 };
            var builder = new DeleteRecordsByIdsRequestBuilder(_client, appId, recordIds);

            Assert.IsInstanceOfType<IDeleteRecordsByIdsRequestBuilder>(builder);
            Assert.AreEqual(appId, builder.AppId);
            Assert.AreEqual(recordIds, builder.RecordIds);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse();

            _client
                .DeleteRecordsAsync(Arg.Any<DeleteRecordsRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }
    }
}