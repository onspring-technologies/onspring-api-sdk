namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IAddFileRequestBuilder
    {
        IAddFileToRecordRequestBuilder ToRecord(int recordId);
    }
}