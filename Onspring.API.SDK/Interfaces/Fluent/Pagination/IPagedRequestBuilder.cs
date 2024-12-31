namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IPagedRequestBuilder
    {
        IGetAllAppsPagesRequestBuilder OfApps();
        IGetAllFieldsPagesRequestBuilder OfFields();
        IGetAllRecordsPagesRequestBuilder OfRecords();
    }
}