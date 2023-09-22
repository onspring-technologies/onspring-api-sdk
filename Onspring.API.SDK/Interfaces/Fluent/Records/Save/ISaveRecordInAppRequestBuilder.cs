namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface ISaveRecordInAppRequestBuilder
    {
        int AppId { get; }
        ISaveRecordByIdRequestBuilder WithId(int? recordId);
    }
}