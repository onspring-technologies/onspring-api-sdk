namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IOnspringRequestBuilder
    {
        IConnectionRequestBuilder ToCheckConnection();
        IGetRecordsRequestBuilder ToGetRecords();
        IDeleteRecordsRequestBuilder ToDeleteRecords();
        ISaveRecordRequestBuilder ToSaveRecord();
        IGetReportsByAppRequestBuilder ToGetReports();
        IGetReportRequestBuilder ToGetReportData();
        ISaveListValueRequestBuilder ToSaveListValue();
        IDeleteListValueRequestBuilder ToDeleteListValue();
        IGetFileRequestBuilder ToGetFile();
        IGetFileInfoRequestBuilder ToGetFileInfo();
        IDeleteFileRequestBuilder ToDeleteFile();
        IAddFileRequestBuilder ToAddFile();
        IGetFieldsRequestBuilder ToGetFields();
        // TODO: ToGetApps()
    }
}