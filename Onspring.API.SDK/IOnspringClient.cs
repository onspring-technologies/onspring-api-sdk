using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Onspring.API.SDK
{
    public interface IOnspringClient
    {
        Task<bool> CanConnectAsync();
        Task<ApiResponse> DeleteFileAsync(int recordId, int fieldId, int fileId);
        Task<ApiResponse> DeleteListItemAsync(int listId, Guid itemId);
        Task<ApiResponse> DeleteRecordAsync(int appId, int recordId);
        Task<ApiResponse> DeleteRecordsAsync(DeleteRecordsRequest request);
        Task<ApiResponse<App>> GetAppAsync(int appId);
        Task<ApiResponse<GetPagedAppsResponse>> GetAppsAsync(PagingRequest pagingRequest = null);
        Task<ApiResponse<GetAppsResponse>> GetAppsAsync(IEnumerable<int> appIds);
        Task<ApiResponse<Field>> GetFieldAsync(int fieldId);
        Task<ApiResponse<GetFieldsResponse>> GetFieldsAsync(IEnumerable<int> fieldIds);
        Task<ApiResponse<GetPagedFieldsResponse>> GetFieldsForAppAsync(int appId, PagingRequest pagingRequest = null);
        Task<ApiResponse<Stream>> GetFileAsync(int recordId, int fieldId, int fileId);
        Task<ApiResponse<GetFileInfoResponse>> GetFileInfoAsync(int recordId, int fieldId, int fileId);
        Task<ApiResponse<ResultRecord>> GetRecordAsync(GetRecordRequest request);
        Task<ApiResponse<GetRecordsResponse>> GetRecordsAsync(GetRecordsRequest request);
        Task<ApiResponse<GetPagedRecordsResponse>> GetRecordsByAppAsync(GetRecordsByAppRequest request);
        Task<ApiResponse<ReportData>> GetReportAsync(int reportId, ReportDataType dataType = ReportDataType.ReportData, DataFormat dataFormat = DataFormat.Raw);
        Task<ApiResponse<GetReportsForAppResponse>> GetReportsForAppAsync(int appId, PagingRequest pagingRequest = null);
        Task<ApiResponse<GetPagedRecordsResponse>> QueryRecordsAsync(QueryRecordsRequest request, PagingRequest pagingRequest = null);
        Task<ApiResponse<CreatedWithIdResponse<int>>> SaveFileAsync(SaveFileRequest request);
        Task<ApiResponse<SaveListItemResponse>> SaveListItemAsync(SaveListItemRequest saveListItemRequest);
        Task<ApiResponse<SaveRecordResponse>> SaveRecordAsync(SaveRecordRequest request);
    }
}