using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetFileInfoRequestBuilder :
        IGetFileInfoRequestBuilder,
        IGetFileInfoFromRecordRequestBuilder,
        IGetFileInfoInFieldRequestBuilder,
        IGetFileInfoByIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int RecordId { get; private set; }
        public int FieldId { get; private set; }
        public int FileId { get; private set; }

        internal GetFileInfoRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetFileInfoFromRecordRequestBuilder FromRecord(int recordId)
        {
            RecordId = recordId;
            return this;
        }

        public IGetFileInfoInFieldRequestBuilder InField(int fieldId)
        {
            FieldId = fieldId;
            return this;
        }

        public IGetFileInfoByIdRequestBuilder WithId(int fileId)
        {
            FileId = fileId;
            return this;
        }

        public async Task<ApiResponse<GetFileInfoResponse>> SendAsync()
        {
            return await _client.GetFileInfoAsync(RecordId, FieldId, FileId);
        }
    }
}