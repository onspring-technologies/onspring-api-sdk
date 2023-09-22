namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetReportsRequestBuilder
    {
        IGetReportsByAppRequestBuilder FromApp(int appId);
    }
}