using Onspring.API.SDK.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Onspring.API.SDK
{
    public interface IOnspringClient
    {
        bool CanConnect();
        Task<bool> CanConnectAsync();
        ApiResponse DeleteFile(int recordId, int fieldId, int fileId);
        Task<ApiResponse> DeleteFileAsync(int recordId, int fieldId, int fileId);
        ApiResponse DeleteListItem(int listId, Guid itemId);
        Task<ApiResponse> DeleteListItemAsync(int listId, Guid itemId);
        ApiResponse DeleteRecord(int appId, int recordId);
        Task<ApiResponse> DeleteRecordAsync(int appId, int recordId);
        ApiResponse DeleteRecordBatch(BatchDeleteRecordsRequest request);
        Task<ApiResponse> DeleteRecordBatchAsync(BatchDeleteRecordsRequest request);
        ApiResponse<App> GetApp(int appId);
        Task<ApiResponse<App>> GetAppAsync(int appId);
        ApiResponse<GetPagedAppsResponse> GetApps(PagingRequest pagingRequest = null);
        Task<ApiResponse<GetPagedAppsResponse>> GetAppsAsync(PagingRequest pagingRequest = null);
        ApiResponse<GetAppsResponse> GetAppsBatch(IEnumerable<int> appIds);
        Task<ApiResponse<GetAppsResponse>> GetAppsBatchAsync(IEnumerable<int> appIds);
        ApiResponse<Field> GetField(int fieldId);
        Task<ApiResponse<Field>> GetFieldAsync(int fieldId);
        ApiResponse<GetFieldsResponse> GetFields(IEnumerable<int> fieldIds);
        Task<ApiResponse<GetFieldsResponse>> GetFieldsAsync(IEnumerable<int> fieldIds);
        ApiResponse<GetPagedFieldsResponse> GetFieldsForApp(int appId, PagingRequest pagingRequest = null);
        Task<ApiResponse<GetPagedFieldsResponse>> GetFieldsForAppAsync(int appId, PagingRequest pagingRequest = null);
        ApiResponse<Stream> GetFile(int recordId, int fieldId, int fileId);
        Task<ApiResponse<Stream>> GetFileAsync(int recordId, int fieldId, int fileId);
        ApiResponse<GetFileInfoResponse> GetFileInfo(int recordId, int fieldId, int fileId);
        Task<ApiResponse<GetFileInfoResponse>> GetFileInfoAsync(int recordId, int fieldId, int fileId);
        ApiResponse<ResultRecord> GetRecord(GetRecordRequest request);
        Task<ApiResponse<ResultRecord>> GetRecordAsync(GetRecordRequest request);
        ApiResponse<GetRecordsResponse> GetRecords(BatchGetRecordsRequest request);
        Task<ApiResponse<GetRecordsResponse>> GetRecordsAsync(BatchGetRecordsRequest request);
        ApiResponse<GetPagedRecordsResponse> GetRecordsByApp(GetRecordsByAppRequest request);
        Task<ApiResponse<GetPagedRecordsResponse>> GetRecordsByAppAsync(GetRecordsByAppRequest request);
        ApiResponse<ReportData> GetReport(int reportId);
        Task<ApiResponse<ReportData>> GetReportAsync(int reportId);
        ApiResponse<GetReportsForAppResponse> GetReportsForApp(int appId, PagingRequest pagingRequest = null);
        Task<ApiResponse<GetReportsForAppResponse>> GetReportsForAppAsync(int appId, PagingRequest pagingRequest = null);
        ApiResponse<GetPagedRecordsResponse> QueryRecords(QueryRecordsRequest request, PagingRequest pagingRequest = null);
        Task<ApiResponse<GetPagedRecordsResponse>> QueryRecordsAsync(QueryRecordsRequest request, PagingRequest pagingRequest = null);
        ApiResponse<CreatedWithIdResponse<int>> SaveFile(SaveFileRequest request);
        Task<ApiResponse<CreatedWithIdResponse<int>>> SaveFileAsync(SaveFileRequest request);
        ApiResponse<SaveListItemResponse> SaveListItem(SaveListItemRequest saveListItemRequest);
        Task<ApiResponse<SaveListItemResponse>> SaveListItemAsync(SaveListItemRequest saveListItemRequest);
        ApiResponse<SaveRecordResponse> SaveRecord(SaveRecordRequest request);
        Task<ApiResponse<SaveRecordResponse>> SaveRecordAsync(SaveRecordRequest request);
    }
}