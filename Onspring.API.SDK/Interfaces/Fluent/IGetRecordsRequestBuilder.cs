using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetRecordsRequestBuilder
    {
        GetRecordsByAppRequestBuilder FromApp(int appId);
    }
}