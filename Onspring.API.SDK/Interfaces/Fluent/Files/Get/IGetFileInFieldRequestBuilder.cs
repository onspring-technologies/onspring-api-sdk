namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetFileInFieldRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        IGetFileByIdRequestBuilder WithId(int fileId);
    }
}