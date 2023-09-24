using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Unit.Fluent
{
    [TestClass, ExcludeFromCodeCoverage]
    public class AddFileRequestBuilderTests
    {
        private static readonly int _recordId = 1;
        private static readonly int _fieldId = 1;
        private static readonly string _name = "name";
        private static readonly Stream _stream = new MemoryStream();
        private static readonly string _type = "text/plain";
        private static readonly string _notes = "notes";
        private static readonly DateTime _modifiedDate = DateTime.UtcNow;
        private static IOnspringClient _client;
        private static AddFileRequestBuilder _builder;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _client = Substitute.For<IOnspringClient>();
            _builder = new AddFileRequestBuilder(_client);
        }

        [TestMethod]
        public void ToRecord_WhenCalled_ItShouldSetRecordIdProperty()
        {
            _builder.ToRecord(_recordId);

            Assert.AreEqual(_recordId, _builder.RecordId);
        }

        [TestMethod]
        public void InField_WhenCalled_ItShouldSetFieldIdProperty()
        {
            _builder.InField(_fieldId);

            Assert.AreEqual(_fieldId, _builder.FieldId);
        }

        [TestMethod]
        public void WithName_WhenCalled_ItShouldSetNameProperty()
        {
            _builder.WithName(_name);

            Assert.AreEqual(_name, _builder.Name);
        }

        [TestMethod]
        public void WithStream_WhenCalled_ItShouldSetStreamProperty()
        {
            _builder.WithStream(_stream);

            Assert.AreEqual(_stream, _builder.FileStream);
        }

        [TestMethod]
        public void WithType_WhenCalled_ItShouldSetTypeProperty()
        {
            _builder.WithType(_type);

            Assert.AreEqual(_type, _builder.Type);
        }

        [TestMethod]
        public void WithNotes_WhenCalled_ItShouldSetNotesProperty()
        {
            _builder.WithNotes(_notes);

            Assert.AreEqual(_notes, _builder.Notes);
        }

        [TestMethod]
        public void WithModifiedDate_WhenCalled_ItShouldSetModifiedDateProperty()
        {
            _builder.WithModifiedDate(null);

            Assert.AreEqual(null, _builder.ModifiedDate);

            _builder.WithModifiedDate(_modifiedDate);

            Assert.AreEqual(_modifiedDate, _builder.ModifiedDate);
        }

        [TestMethod]
        public async Task SendAsync_WhenCalled_ItShouldReturnAnApiResponse()
        {
            var apiResponse = new ApiResponse<CreatedWithIdResponse<int>>
            {
                StatusCode = HttpStatusCode.Created,
                Value = new CreatedWithIdResponse<int>
                {
                    Id = 1,
                }
            };

            _client
                .SaveFileAsync(Arg.Any<SaveFileRequest>())
                .Returns(apiResponse);

            var result = await _builder.SendAsync();

            Assert.AreEqual(apiResponse, result);
        }
    }
}