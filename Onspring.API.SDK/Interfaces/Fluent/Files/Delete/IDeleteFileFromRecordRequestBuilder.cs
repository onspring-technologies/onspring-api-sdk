namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IDeleteFileFromRecordRequestBuilder
    {
        int RecordId { get; }
        IDeleteFileInFieldRequestBuilder InField(int fieldId);
    }
}