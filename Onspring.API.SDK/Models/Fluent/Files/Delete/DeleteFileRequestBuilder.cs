using Onspring.API.SDK.Interfaces.Fluent;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a file.
    /// </summary>
    /// <inheritdoc/>
    public class DeleteFileRequestBuilder :
        IDeleteFileRequestBuilder,
        IDeleteFileFromRecordRequestBuilder,
        IDeleteFileInFieldRequestBuilder,
        IDeleteFileByIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int RecordId { get; private set; }
        public int FieldId { get; private set; }
        public int FileId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteFileRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
        internal DeleteFileRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IDeleteFileFromRecordRequestBuilder FromRecord(int recordId)
        {
            RecordId = recordId;
            return this;
        }

        public IDeleteFileInFieldRequestBuilder InField(int fieldId)
        {
            FieldId = fieldId;
            return this;
        }

        public IDeleteFileByIdRequestBuilder WithId(int fileId)
        {
            FileId = fileId;
            return this;
        }

        public async Task<ApiResponse> SendAsync()
        {
            return await _client.DeleteFileAsync(RecordId, FieldId, FileId);
        }
    }
}