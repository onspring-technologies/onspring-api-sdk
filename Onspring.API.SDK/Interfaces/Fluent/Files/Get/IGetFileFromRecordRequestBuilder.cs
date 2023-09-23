namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetFileFromRecordRequestBuilder
    {
        int RecordId { get; }
        IGetFileInFieldRequestBuilder InField(int fieldId);
    }
}