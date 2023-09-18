using Onspring.API.SDK.Models.Fluent;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IOnspringRequest
    {
        GetRecordsRequestBuilder ToGetRecords();
    }
}