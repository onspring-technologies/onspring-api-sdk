using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Integration.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DeleteFileRequestBuilderTests
    {
        private static readonly int _recordId = 1;
        private static readonly int _fieldId = 1;
        private static readonly int _fileId = 1;
        private static IOnspringClient _client;
        private static DeleteFileRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new DeleteFileRequestBuilder(_client);
        }

        [TestMethod]
        public void FromRecord_WhenCalled_ItShouldSetRecordIdProperties()
        {
            _builder.FromRecord(_recordId);

            Assert.AreEqual(_recordId, _builder.RecordId);
        }

        [TestMethod]
        public void InField_WhenCalled_ItShouldSetFieldIdProperties()
        {
            _builder.InField(_fieldId);

            Assert.AreEqual(_fieldId, _builder.FieldId);
        }

        [TestMethod]
        public void WithId_WhenCalled_ItShouldSetFileIdProperties()
        {
            _builder.WithId(_fileId);

            Assert.AreEqual(_fileId, _builder.FileId);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse();

            _client
                .DeleteFileAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }
    }
}