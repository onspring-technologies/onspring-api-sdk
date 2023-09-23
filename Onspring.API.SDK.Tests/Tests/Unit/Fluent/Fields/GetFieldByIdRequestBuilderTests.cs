using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetFieldByIdRequestBuilderTests
    {
        private static readonly int _fieldId = 1;
        private static IOnspringClient _client;
        private static GetFieldByIdRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetFieldByIdRequestBuilder(_client, _fieldId);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnInstanceWithPropertiesSet()
        {
            var builder = new GetFieldByIdRequestBuilder(_client, _fieldId);

            Assert.IsInstanceOfType<IGetFieldByIdRequestBuilder>(builder);
            Assert.AreEqual(_fieldId, builder.FieldId);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<Field>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new Field(),
            };

            _client
                .GetFieldAsync(Arg.Any<int>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }
    }
}