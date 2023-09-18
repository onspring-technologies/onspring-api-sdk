using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Models.Fluent;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onspring.API.SDK
{
    /// <summary>
    /// Interface for the Onspring API client.
    /// </summary>
    public interface IOnspringClient
    {
        /// <summary>
        /// Creates a new Onspring request which exposes a fluent interface for making a request to the Onspring API.
        /// </summary>
        /// <returns>An instance of <see cref="OnspringRequest"/>.</returns>
        OnspringRequest CreateRequest();

        /// <summary>
        /// Determines if the API is reachable.
        /// </summary>
        /// <returns>Value indicating if the API is responsive.</returns>
        Task<bool> CanConnectAsync();

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fieldId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task<ApiResponse> DeleteFileAsync(int recordId, int fieldId, int fileId);

        /// <summary>
        /// Deletes an item from the list.
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="itemId"></param>
        Task<ApiResponse> DeleteListItemAsync(int listId, Guid itemId);

        /// <summary>
        /// Deletes a record for a given app.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        Task<ApiResponse> DeleteRecordAsync(int appId, int recordId);

        /// <summary>
        /// Deletes a batch of records.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ApiResponse> DeleteRecordsAsync(DeleteRecordsRequest request);

        /// <summary>
        /// Gets the requested app.
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        Task<ApiResponse<App>> GetAppAsync(int appId);

        /// <summary>
        /// Gets all accessible apps.
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<ApiResponse<GetPagedAppsResponse>> GetAppsAsync(PagingRequest pagingRequest = null);

        /// <summary>
        /// Gets a batch of apps by their identifiers.
        /// </summary>
        /// <param name="appIds"></param>
        /// <returns></returns>
        Task<ApiResponse<GetAppsResponse>> GetAppsAsync(IEnumerable<int> appIds);

        /// <summary>
        /// Gets the requested field.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        Task<ApiResponse<Field>> GetFieldAsync(int fieldId);

        /// <summary>
        /// Gets the requested fields. 
        /// </summary>
        /// <param name="fieldIds"></param>
        /// <returns></returns>
        Task<ApiResponse<GetFieldsResponse>> GetFieldsAsync(IEnumerable<int> fieldIds);

        /// <summary>
        /// Gets the fields associated to the <paramref name="appId"/>. 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<ApiResponse<GetPagedFieldsResponse>> GetFieldsForAppAsync(int appId, PagingRequest pagingRequest = null);

        /// <summary>
        /// Gets a file.
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fieldId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task<ApiResponse<GetFileResponse>> GetFileAsync(int recordId, int fieldId, int fileId);

        /// <summary>
        /// Gets a file's information.
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fieldId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task<ApiResponse<GetFileInfoResponse>> GetFileInfoAsync(int recordId, int fieldId, int fileId);

        /// <summary>
        /// Gets a record by its identifier.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ApiResponse<ResultRecord>> GetRecordAsync(GetRecordRequest request);

        /// <summary>
        /// Gets a batch of records.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ApiResponse<GetRecordsResponse>> GetRecordsAsync(GetRecordsRequest request);

        /// <summary>
        /// Gets the records associated to an app.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ApiResponse<GetPagedRecordsResponse>> GetRecordsForAppAsync(GetRecordsByAppRequest request);

        /// <summary>
        /// Gets the report for <paramref name="reportId"/>.
        /// </summary>
        /// <param name="reportId"></param>
        /// <param name="dataType"></param>
        /// <param name="dataFormat"></param>
        /// <returns></returns>
        Task<ApiResponse<ReportData>> GetReportAsync(int reportId, ReportDataType dataType = ReportDataType.ReportData, DataFormat dataFormat = DataFormat.Raw);

        /// <summary>
        /// Gets the reports associated to the <paramref name="appId"/>.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<ApiResponse<GetReportsForAppResponse>> GetReportsForAppAsync(int appId, PagingRequest pagingRequest = null);

        /// <summary>
        /// Queries records.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        Task<ApiResponse<GetPagedRecordsResponse>> QueryRecordsAsync(QueryRecordsRequest request, PagingRequest pagingRequest = null);

        /// <summary>
        /// Saves a file.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ApiResponse<CreatedWithIdResponse<int>>> SaveFileAsync(SaveFileRequest request);

        /// <summary>
        /// Saves (inserts/updates) a list item to the provided list. Returns the identifier of the new list item.
        /// </summary>
        /// <param name="saveListItemRequest"></param>
        /// <returns></returns>
        Task<ApiResponse<SaveListItemResponse>> SaveListItemAsync(SaveListItemRequest saveListItemRequest);

        /// <summary>
        /// Saves a record.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ApiResponse<SaveRecordResponse>> SaveRecordAsync(ResultRecord request);
    }
}