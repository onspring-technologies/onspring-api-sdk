using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SaveListValueRequestBuilderTests
    {
        private static readonly int _listId = 1;
        private static readonly Guid? _id = Guid.NewGuid();
        private static readonly string _name = "Name";
        private static readonly decimal _numValue = 1;
        private static readonly string _color = "#db3e3e";
        private static IOnspringClient _client;
        private static SaveListValueRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new SaveListValueRequestBuilder(_client);
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
        public void WithName_WhenCalled_ItShouldSetNameProperty()
        {
            _builder.WithName(_name);

            Assert.AreEqual(_name, _builder.Name);
        }

        [TestMethod]
        public void WithColor_WhenCalled_ItShouldSetColorProperty()
        {
            _builder.WithColor(_color);

            Assert.AreEqual(_color, _builder.Color);
        }

        [TestMethod]
        public void WithNumericValue_WhenCalled_ItShouldSetNumericValueProperty()
        {
            _builder.WithNumericValue(_numValue);

            Assert.AreEqual(_numValue, _builder.NumericValue);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnApiResponse()
        {
            var apiResponse = new ApiResponse<SaveListItemResponse>
            {
                StatusCode = HttpStatusCode.OK,
                Value = new SaveListItemResponse(Guid.NewGuid()),
            };

            _client
                .SaveListItemAsync(Arg.Any<SaveListItemRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }
    }
}