using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve a file.
    /// </summary>
    /// <inheritdoc/>
    public class GetFileRequestBuilder :
        IGetFileRequestBuilder,
        IGetFileFromRecordRequestBuilder,
        IGetFileInFieldRequestBuilder,
        IGetFileByIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int RecordId { get; private set; }
        public int FieldId { get; private set; }
        public int FileId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetFileRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
        internal GetFileRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetFileFromRecordRequestBuilder FromRecord(int recordId)
        {
            RecordId = recordId;
            return this;
        }

        public IGetFileInFieldRequestBuilder InField(int fieldId)
        {
            FieldId = fieldId;
            return this;
        }

        public IGetFileByIdRequestBuilder WithId(int fileId)
        {
            FileId = fileId;
            return this;
        }

        public async Task<ApiResponse<GetFileResponse>> SendAsync()
        {
            return await _client.GetFileAsync(RecordId, FieldId, FileId);
        }
    }
}