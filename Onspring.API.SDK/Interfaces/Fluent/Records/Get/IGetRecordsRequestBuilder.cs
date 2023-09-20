namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetRecordsRequestBuilder
    {
        IGetRecordsByAppRequestBuilder FromApp(int appId);
    }
}