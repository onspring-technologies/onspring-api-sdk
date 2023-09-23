namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetFileInfoFromRecordRequestBuilder
    {
        int RecordId { get; }
        IGetFileInfoInFieldRequestBuilder InField(int fieldId);
    }
}