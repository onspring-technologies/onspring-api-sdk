using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DeleteRecordByIdRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static DeleteRecordByIdRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new DeleteRecordByIdRequestBuilder(_client, 1, 1);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnAnInstanceWithPropertiesSet()
        {
            var appId = 1;
            var recordId = 1;
            var builder = new DeleteRecordByIdRequestBuilder(_client, appId, recordId);

            Assert.IsInstanceOfType<DeleteRecordByIdRequestBuilder>(builder);
            Assert.AreEqual(appId, builder.AppId);
            Assert.AreEqual(recordId, builder.RecordId);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse();

            _client
                .DeleteRecordAsync(Arg.Any<int>(), Arg.Any<int>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }

    }
}