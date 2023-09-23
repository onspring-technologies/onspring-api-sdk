using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
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