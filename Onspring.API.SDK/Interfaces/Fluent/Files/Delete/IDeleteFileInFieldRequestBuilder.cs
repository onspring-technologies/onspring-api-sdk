namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IDeleteFileInFieldRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        IDeleteFileByIdRequestBuilder WithId(int fileId);
    }
}