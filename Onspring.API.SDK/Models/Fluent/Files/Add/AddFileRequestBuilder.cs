using Onspring.API.SDK.Interfaces.Fluent;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to add a file.
    /// </summary>
    /// <inheritdoc/>
    public class AddFileRequestBuilder :
        IAddFileRequestBuilder,
        IAddFileToRecordRequestBuilder,
        IAddFileInFieldRequestBuilder,
        IAddFileWithNameRequestBuilder,
        IAddFileWithStreamRequestBuilder,
        IAddFileWithTypeRequestBuilder,
        IAddFileWithNotesRequestBuilder,
        IAddFileWithModifiedDateRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int RecordId { get; private set; }
        public int FieldId { get; private set; }
        public string Name { get; private set; }
        public Stream FileStream { get; private set; }
        public string Type { get; private set; }
        public string Notes { get; private set; }
        public DateTime? ModifiedDate { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddFileRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
        internal AddFileRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IAddFileToRecordRequestBuilder ToRecord(int recordId)
        {
            RecordId = recordId;
            return this;
        }

        public IAddFileInFieldRequestBuilder InField(int fieldId)
        {
            FieldId = fieldId;
            return this;
        }

        public IAddFileWithNameRequestBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public IAddFileWithStreamRequestBuilder WithStream(Stream stream)
        {
            FileStream = stream;
            return this;
        }

        public IAddFileWithTypeRequestBuilder WithType(string type)
        {
            Type = type;
            return this;
        }

        public IAddFileWithNotesRequestBuilder WithNotes(string notes)
        {
            Notes = notes;
            return this;
        }

        public IAddFileWithModifiedDateRequestBuilder WithModifiedDate(DateTime? modifiedDate)
        {
            ModifiedDate = modifiedDate;
            return this;
        }



        public async Task<ApiResponse<CreatedWithIdResponse<int>>> SendAsync()
        {
            return await _client.SaveFileAsync(
                new SaveFileRequest
                {
                    RecordId = RecordId,
                    FieldId = FieldId,
                    Notes = Notes,
                    ModifiedDate = ModifiedDate,
                    ContentType = Type,
                    FileName = Name,
                    FileStream = FileStream,
                }
            );
        }
    }
}