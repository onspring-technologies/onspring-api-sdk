using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DeleteListValueRequestBuilderTests
    {
        private static readonly int _listId = 1;
        private static readonly Guid _id = Guid.NewGuid();

        private static IOnspringClient _client;
        private static DeleteListValueRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new DeleteListValueRequestBuilder(_client);
        }

        [TestMethod]
        public void InList_WhenCalled_ItShouldSetListIdProperty()
        {
            _builder.InList(_listId);

            Assert.AreEqual(_listId, _builder.ListId);
        }

        [TestMethod]
        public void WithId_WhenCalled_ItShouldSetIdProperty()
        {
            _builder.WithId(_id);

            Assert.AreEqual(_id, _builder.Id);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnApiResponse()
        {
            var apiResponse = new ApiResponse();

            _client
                .DeleteListItemAsync(Arg.Any<int>(), Arg.Any<Guid>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }
    }
}