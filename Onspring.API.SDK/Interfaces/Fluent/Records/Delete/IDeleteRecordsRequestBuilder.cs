namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IDeleteRecordsRequestBuilder
    {
        IDeleteRecordsByAppRequestBuilder FromApp(int appId);
    }
}