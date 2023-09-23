namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IAddFileToRecordRequestBuilder
    {
        int RecordId { get; }
        IAddFileInFieldRequestBuilder InField(int fieldId);
    }
}