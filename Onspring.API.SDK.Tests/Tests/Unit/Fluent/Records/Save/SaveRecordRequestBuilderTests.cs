using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SaveRecordRequestBuilderTests
    {
        private static IOnspringClient _client;
        private static SaveRecordRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new SaveRecordRequestBuilder(_client);
        }

        [TestMethod]
        public void InApp_WhenCalled_ItShouldSetAppId()
        {
            var appId = 1;

            _builder.InApp(appId);

            Assert.AreEqual(appId, _builder.AppId);
        }

        [TestMethod]
        public void WithId_WhenCalledWithNull_ItShouldSetRecordId()
        {
            int? recordId = null;

            _builder.WithId(recordId);

            Assert.AreEqual(recordId, _builder.RecordId);
        }

        [TestMethod]
        public void WithId_WhenCalledWithIdValue_ItShouldSetRecordId()
        {
            int? recordId = 1;

            _builder.WithId(recordId);

            Assert.AreEqual(recordId, _builder.RecordId);
        }

        [TestMethod]
        public void WithValues_WhenCalled_ItShouldSetValues()
        {
            var values = new[] { new RecordFieldValue() };

            _builder.WithValues(values);

            Assert.AreEqual(values, _builder.Values);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<SaveRecordResponse>
            {
                StatusCode = HttpStatusCode.Created,
                Value = new SaveRecordResponse(),
            };

            _client
                .SaveRecordAsync(Arg.Any<ResultRecord>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }
    }
}