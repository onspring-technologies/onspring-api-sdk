namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IOnspringRequest
    {
        IConnectionRequestBuilder ToCheckConnection();
        IGetRecordsRequestBuilder ToGetRecords();
        IDeleteRecordsRequestBuilder ToDeleteRecords();
        ISaveRecordRequestBuilder ToSaveRecord();
        IGetReportsByAppRequestBuilder ToGetReports();
        IGetReportRequestBuilder ToGetReportData();
        ISaveListValueRequestBuilder ToSaveListValue();
        IDeleteListValueRequestBuilder ToDeleteListValue();
        // TODO: ToGetFile()
        // TODO: ToGetFileInfo()
        // TODO: ToAddFile()
        // TODO: ToDeleteFile()
        // TODO: ToGetFields()
        // TODO: ToGetApps()
    }
}