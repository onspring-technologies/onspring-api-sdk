using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Interfaces.Fluent;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GetFieldsByIdsRequestBuilderTests
    {
        private static readonly IEnumerable<int> _fieldIds = new[] { 1, 2, 3 };
        private static IOnspringClient _client;
        private static GetFieldsByIdsRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new GetFieldsByIdsRequestBuilder(_client, _fieldIds);
        }

        [TestMethod]
        public void Constructor_WhenCalled_ItShouldReturnInstanceWithPropertiesSet()
        {
            var builder = new GetFieldsByIdsRequestBuilder(_client, _fieldIds);

            Assert.IsInstanceOfType<IGetFieldsByIdsRequestBuilder>(builder);
            Assert.AreEqual(_fieldIds, builder.FieldIds);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<GetFieldsResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new GetFieldsResponse(),
            };

            _client
                .GetFieldsAsync(Arg.Any<IEnumerable<int>>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }
    }
}