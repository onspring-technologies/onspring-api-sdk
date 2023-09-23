namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetFileInfoInFieldRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        IGetFileInfoByIdRequestBuilder WithId(int fileId);
    }
}