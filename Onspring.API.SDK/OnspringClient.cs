using Onspring.API.SDK.Extensions;
using Onspring.API.SDK.Helpers;
using Onspring.API.SDK.Internals;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Onspring.API.SDK
{
    /// <summary>
    /// Client used to communicate with the Onspring API over HTTP. 
    /// </summary>
    public class OnspringClient : IOnspringClient
    {
        private readonly OnspringClientConfiguration _clientConfig;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of <see cref="OnspringClient"/>.
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="apiKey"></param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="apiKey"/> or <paramref name="baseAddress"/> is invalid</exception>
        public OnspringClient(string baseAddress, string apiKey)
            : this(new OnspringClientConfiguration(baseAddress, apiKey))
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="OnspringClient"/>. The BaseAddress on the <paramref name="httpClient"/> must be set prior to this.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="httpClient"></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="httpClient"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="apiKey"/> is null/empty/whitespace or if the <paramref name="httpClient"/>'s base address is invalid.</exception>
        public OnspringClient(string apiKey, HttpClient httpClient)
        {
            Arg.IsNotNullOrWhitespace(apiKey, nameof(apiKey));
            Arg.IsNotNull(httpClient, nameof(httpClient));
            Arg.IsNotNull(httpClient.BaseAddress, $"{nameof(httpClient)}.{nameof(httpClient.BaseAddress)}");

            _clientConfig = new OnspringClientConfiguration(httpClient.BaseAddress.ToString(), apiKey);
            _httpClient = httpClient;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="OnspringClient"/>.
        /// </summary>
        /// <param name="clientConfig"></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="clientConfig"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <see cref="OnspringClientConfiguration.ApiKey"/> is null/empty/whitespace or if the <see cref="OnspringClientConfiguration.BaseAddress"/> is invalid.</exception>
        public OnspringClient(OnspringClientConfiguration clientConfig)
        {
            Arg.IsNotNull(clientConfig, nameof(clientConfig));
            Arg.IsNotNullOrWhitespace(clientConfig.ApiKey, $"{nameof(clientConfig)}.{clientConfig.ApiKey}");
            Arg.IsValidUrl(clientConfig.BaseAddress, $"{nameof(clientConfig)}.{clientConfig.BaseAddress}");

            _clientConfig = clientConfig;
            _httpClient = HttpClientFactory.GetHttpClient(clientConfig.BaseAddress);
        }

        // ------------------------------------ Diagnostic ------------------------------------

        #region Diagnostic

        /// <summary>
        /// Determines if the API is reachable by calling the ping endpoint.
        /// </summary>
        /// <returns>Value indicating if the API is responsive.</returns>
        [Obsolete("Using CanConnectAsync is recommended.")]
        public bool CanConnect()
        {
            var canConnect = AsyncHelper.RunTask(() => CanConnectAsync());
            return canConnect;
        }

        /// <summary>
        /// Determines if the API is reachable by calling the ping endpoint.
        /// </summary>
        /// <returns>Value indicating if the API is responsive.</returns>
        public async Task<bool> CanConnectAsync()
        {
            var path = UrlHelper.GetPingPath();
            var response = await _httpClient.GetAsync(path);
            var canConnect = response.IsSuccessStatusCode;
            return canConnect;
        }

        #endregion

        // ------------------------------------ Apps ------------------------------------

        #region Apps

        /// <summary>
        /// Gets all accessible apps.
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [Obsolete("Using GetAppsAsync is recommended.")]
        public ApiResponse<GetPagedAppsResponse> GetApps(PagingRequest pagingRequest = null)
        {
            var getAppsResponse = AsyncHelper.RunTask(() => GetAppsAsync(pagingRequest));
            return getAppsResponse;
        }

        /// <summary>
        /// Gets all accessible apps.
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public async Task<ApiResponse<GetPagedAppsResponse>> GetAppsAsync(PagingRequest pagingRequest = null)
        {
            var path = UrlHelper.GetAppsPath(pagingRequest);
            var getAppsResponse = await GetAsync<GetPagedAppsResponse>(path);
            return getAppsResponse;
        }

        /// <summary>
        /// Gets the requested app. Returns null if app could not be found.
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        [Obsolete("Using GetAppAsync is recommended.")]
        public ApiResponse<App> GetApp(int appId)
        {
            var app = AsyncHelper.RunTask(() => GetAppAsync(appId));
            return app;
        }

        /// <summary>
        /// Gets the requested app. Returns null if app could not be found.
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<ApiResponse<App>> GetAppAsync(int appId)
        {
            var path = UrlHelper.GetAppByIdPath(appId);
            var app = await GetAsync<App>(path);
            return app;
        }

        /// <summary>
        /// Gets a batch of apps by their identifiers.
        /// </summary>
        /// <param name="appIds"></param>
        /// <returns></returns>
        [Obsolete("Using GetAppsAsync is recommended.")]
        public ApiResponse<GetAppsResponse> GetAppsBatch(IEnumerable<int> appIds)
        {
            var getAppsResponse = AsyncHelper.RunTask(() => GetAppsAsync(appIds));
            return getAppsResponse;
        }

        /// <summary>
        /// Gets a batch of apps by their identifiers.
        /// </summary>
        /// <param name="appIds"></param>
        /// <returns></returns>
        public async Task<ApiResponse<GetAppsResponse>> GetAppsAsync(IEnumerable<int> appIds)
        {
            var path = UrlHelper.GetAppsBatchPath();
            var getAppsResponse = await PostAsync<GetAppsResponse>(path, appIds.Distinct().ToArray());
            return getAppsResponse;
        }

        #endregion

        // ------------------------------------ Fields ------------------------------------

        #region Fields

        /// <summary>
        /// Gets the requested field. Returns null if field could not be found.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        [Obsolete("Using GetFieldAsync is recommended.")]
        public ApiResponse<Field> GetField(int fieldId)
        {
            var field = AsyncHelper.RunTask(() => GetFieldAsync(fieldId));
            return field;
        }

        /// <summary>
        /// Gets the requested field. Returns null if field could not be found.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        public async Task<ApiResponse<Field>> GetFieldAsync(int fieldId)
        {
            var path = UrlHelper.GetFieldByIdPath(fieldId);
            var field = await GetAsync<Field>(path);
            return field;
        }

        /// <summary>
        /// Gets the requested fields. 
        /// </summary>
        /// <param name="fieldIds"></param>
        /// <returns></returns>
        [Obsolete("Using GetFieldsAsync is recommended.")]
        public ApiResponse<GetFieldsResponse> GetFields(IEnumerable<int> fieldIds)
        {
            var fields = AsyncHelper.RunTask(() => GetFieldsAsync(fieldIds));
            return fields;
        }

        /// <summary>
        /// Gets the requested fields. 
        /// </summary>
        /// <param name="fieldIds"></param>
        /// <returns></returns>
        public async Task<ApiResponse<GetFieldsResponse>> GetFieldsAsync(IEnumerable<int> fieldIds)
        {
            var path = UrlHelper.GetFieldsBatchPath();
            var response = await PostAsync<GetFieldsResponse>(path, fieldIds);
            return response;
        }

        /// <summary>
        /// Gets the fields associated to the <paramref name="appId"/>. 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [Obsolete("Using GetFieldsForAppAsync is recommended.")]
        public ApiResponse<GetPagedFieldsResponse> GetFieldsForApp(int appId, PagingRequest pagingRequest = null)
        {
            var fields = AsyncHelper.RunTask(() => GetFieldsForAppAsync(appId, pagingRequest));
            return fields;
        }

        /// <summary>
        /// Gets the fields associated to the <paramref name="appId"/>. 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public async Task<ApiResponse<GetPagedFieldsResponse>> GetFieldsForAppAsync(int appId, PagingRequest pagingRequest = null)
        {
            var path = UrlHelper.GetFieldsByAppIdPath(appId, pagingRequest);
            var response = await GetAsync<GetPagedFieldsResponse>(path);
            return response;
        }

        #endregion

        // ------------------------------------ Files ------------------------------------

        #region Files

        /// <summary>
        /// Gets a file's information.
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fieldId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [Obsolete("Using GetFileInfoAsync is recommended.")]
        public ApiResponse<GetFileInfoResponse> GetFileInfo(int recordId, int fieldId, int fileId)
        {
            var apiResponse = AsyncHelper.RunTask(() => GetFileInfoAsync(recordId, fieldId, fileId));
            return apiResponse;
        }

        /// <summary>
        /// Gets a file's information.
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fieldId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public async Task<ApiResponse<GetFileInfoResponse>> GetFileInfoAsync(int recordId, int fieldId, int fileId)
        {
            var path = UrlHelper.GetFileInfoPath(recordId, fieldId, fileId);
            var apiResponse = await GetAsync<GetFileInfoResponse>(path);
            return apiResponse;
        }

        /// <summary>
        /// Gets a file.
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fieldId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [Obsolete("Using GetFileAsync is recommended.")]
        public ApiResponse<Stream> GetFile(int recordId, int fieldId, int fileId)
        {
            var apiResponse = AsyncHelper.RunTask(() => GetFileAsync(recordId, fieldId, fileId));
            return apiResponse;
        }

        /// <summary>
        /// Gets a file.
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fieldId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public async Task<ApiResponse<Stream>> GetFileAsync(int recordId, int fieldId, int fileId)
        {
            var path = UrlHelper.GetFilePath(recordId, fieldId, fileId);
            var response = await _httpClient.GetAsync(path, _clientConfig.ApiKey);

            var message = await ApiResponseFactory.TryGetMessageAsync(response);
            var apiResponse = new ApiResponse<Stream>
            {
                Message = message,
                StatusCode = response.StatusCode,
            };

            if (response.IsSuccessStatusCode)
            {
                apiResponse.Value = await response.Content.ReadAsStreamAsync();
            }

            return apiResponse;
        }

        /// <summary>
        /// Saves a file.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Obsolete("Using SaveFileAsync is recommended.")]
        public ApiResponse<CreatedWithIdResponse<int>> SaveFile(SaveFileRequest request)
        {
            var apiResponse = AsyncHelper.RunTask(() => SaveFileAsync(request));
            return apiResponse;
        }

        /// <summary>
        /// Saves a file.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<CreatedWithIdResponse<int>>> SaveFileAsync(SaveFileRequest request)
        {
            Arg.IsNotNull(request, nameof(request));

            var path = UrlHelper.GetSaveFilePath();
            var multiPartContent = new MultipartFormDataContent
            {
                { new ByteArrayContent(request.FileContents), "file", request.FileName },
                { new StringContent(request.RecordId.ToString()), nameof(request.RecordId) },
                { new StringContent(request.FieldId.ToString()), nameof(request.FieldId) },
                { new StringContent(request.Notes), nameof(request.Notes) },
            };

            if (request.ModifiedDate != null)
            {
                multiPartContent.Add(new StringContent(request.ModifiedDate.ToString()), nameof(request.ModifiedDate));
            }

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = multiPartContent,
            };

            var httpResponse = await _httpClient.SendAsync(httpRequest);

            var apiResponse = await ApiResponseFactory.GetApiResponseAsync<CreatedWithIdResponse<int>>(httpResponse);
            return apiResponse;
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fieldId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [Obsolete("Using DeleteFileAsync is recommended.")]
        public ApiResponse DeleteFile(int recordId, int fieldId, int fileId)
        {
            var apiResponse = AsyncHelper.RunTask(() => DeleteFileAsync(recordId, fieldId, fileId));
            return apiResponse;
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="fieldId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteFileAsync(int recordId, int fieldId, int fileId)
        {
            var path = UrlHelper.GetDeleteFilePath(recordId, fieldId, fileId);
            var apiResponse = await DeleteAsync(path);
            return apiResponse;
        }

        #endregion

        // ------------------------------------ Lists ------------------------------------

        #region Lists

        /// <summary>
        /// Deletes an item from the list.
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="itemId"></param>
        [Obsolete("Using DeleteListItemAsync is recommended.")]
        public ApiResponse DeleteListItem(int listId, Guid itemId)
        {
            var apiResponse = AsyncHelper.RunTask(() => DeleteListItemAsync(listId, itemId));
            return apiResponse;
        }

        /// <summary>
        /// Deletes an item from the list.
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="itemId"></param>
        public async Task<ApiResponse> DeleteListItemAsync(int listId, Guid itemId)
        {
            var path = UrlHelper.GetDeleteListItemPath(listId, itemId);
            var apiResponse = await DeleteAsync(path);
            return apiResponse;
        }

        /// <summary>
        /// Saves (inserts/updates) a list item to the provided list. Returns the identifier of the new list item
        /// or null if the list could not be found.
        /// </summary>
        /// <param name="saveListItemRequest"></param>
        /// <returns></returns>
        [Obsolete("Using SaveListItemAsync is recommended.")]
        public ApiResponse<SaveListItemResponse> SaveListItem(SaveListItemRequest saveListItemRequest)
        {
            var saveResponse = AsyncHelper.RunTask(() => SaveListItemAsync(saveListItemRequest));
            return saveResponse;
        }

        /// <summary>
        /// Saves (inserts/updates) a list item to the provided list. Returns the identifier of the new list item
        /// or null if the list could not be found.
        /// </summary>
        /// <param name="saveListItemRequest"></param>
        /// <returns></returns>
        public async Task<ApiResponse<SaveListItemResponse>> SaveListItemAsync(SaveListItemRequest saveListItemRequest)
        {
            Arg.IsNotNull(saveListItemRequest, nameof(saveListItemRequest));

            var path = UrlHelper.GetSaveListItemPath(saveListItemRequest.ListId);
            var response = await PutAsync<SaveListItemResponse>(path, saveListItemRequest);
            return response;
        }

        #endregion

        // ------------------------------------ Records ------------------------------------

        #region Records

        /// <summary>
        /// Gets the records associatd to an app.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Obsolete("Using GetRecordsByAppAsync is recommended.")]
        public ApiResponse<GetPagedRecordsResponse> GetRecordsByApp(GetRecordsByAppRequest request)
        {
            var apiResponse = AsyncHelper.RunTask(() => GetRecordsByAppAsync(request));
            return apiResponse;
        }

        /// <summary>
        /// Gets the records associatd to an app.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<GetPagedRecordsResponse>> GetRecordsByAppAsync(GetRecordsByAppRequest request)
        {
            Arg.IsNotNull(request, nameof(request));

            var path = UrlHelper.GetRecordsByAppIdPath(request.AppId, request.FieldIds, request.DataFormat, request.PagingRequest);
            var apiResponse = await GetAsync<GetPagedRecordsResponse>(path);
            return apiResponse;
        }

        /// <summary>
        /// Gets a record by its identifier.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Obsolete("Using GetRecordAsync is recommended.")]
        public ApiResponse<ResultRecord> GetRecord(GetRecordRequest request)
        {
            var apiResponse = AsyncHelper.RunTask(() => GetRecordAsync(request));
            return apiResponse;
        }

        /// <summary>
        /// Gets a record by its identifier.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<ResultRecord>> GetRecordAsync(GetRecordRequest request)
        {
            Arg.IsNotNull(request, nameof(request));

            var path = UrlHelper.GetRecordByIdPath(request.AppId, request.RecordId, request.FieldIds, request.DataFormat);
            var apiResponse = await GetAsync<ResultRecord>(path);
            return apiResponse;
        }

        /// <summary>
        /// Gets a batch of records.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Obsolete("Using GetRecordsAsync is recommended.")]
        public ApiResponse<GetRecordsResponse> GetRecords(GetRecordsRequest request)
        {
            var apiResponse = AsyncHelper.RunTask(() => GetRecordsAsync(request));
            return apiResponse;
        }

        /// <summary>
        /// Gets a batch of records.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<GetRecordsResponse>> GetRecordsAsync(GetRecordsRequest request)
        {
            Arg.IsNotNull(request, nameof(request));

            var path = UrlHelper.GetRecordsBatchPath();
            var apiResponse = await PostAsync<GetRecordsResponse>(path, request);
            return apiResponse;
        }

        /// <summary>
        /// Queries records.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [Obsolete("Using QueryRecordsAsync is recommended.")]
        public ApiResponse<GetPagedRecordsResponse> QueryRecords(QueryRecordsRequest request, PagingRequest pagingRequest = null)
        {
            var apiResponse = AsyncHelper.RunTask(() => QueryRecordsAsync(request, pagingRequest));
            return apiResponse;
        }

        /// <summary>
        /// Queries records.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public async Task<ApiResponse<GetPagedRecordsResponse>> QueryRecordsAsync(QueryRecordsRequest request, PagingRequest pagingRequest = null)
        {
            Arg.IsNotNull(request, nameof(request));

            var path = UrlHelper.GetQueryRecordsPath(pagingRequest);
            var apiResponse = await PostAsync<GetPagedRecordsResponse>(path, request);
            return apiResponse;
        }

        /// <summary>
        /// Saves a record.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Obsolete("Using SaveRecordAsync is recommended.")]
        public ApiResponse<SaveRecordResponse> SaveRecord(SaveRecordRequest request)
        {
            var apiResponse = AsyncHelper.RunTask(() => SaveRecordAsync(request));
            return apiResponse;
        }

        /// <summary>
        /// Saves a record.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<SaveRecordResponse>> SaveRecordAsync(SaveRecordRequest request)
        {
            Arg.IsNotNull(request, nameof(request));

            var path = UrlHelper.GetSaveRecordPath();
            var apiResponse = await PutAsync<SaveRecordResponse>(path, request);
            return apiResponse;
        }

        /// <summary>
        /// Deletes a record for a given app.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        [Obsolete("Using DeleteRecordAsync is recommended.")]
        public ApiResponse DeleteRecord(int appId, int recordId)
        {
            var apiResponse = AsyncHelper.RunTask(() => DeleteRecordAsync(appId, recordId));
            return apiResponse;
        }

        /// <summary>
        /// Deletes a record for a given app.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteRecordAsync(int appId, int recordId)
        {
            var path = UrlHelper.GetDeleteRecordPath(appId, recordId);
            var apiResponse = await DeleteAsync(path);
            return apiResponse;
        }

        /// <summary>
        /// Deletes a batch of records.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Obsolete("Using DeleteRecordsAsync is recommended.")]
        public ApiResponse DeleteRecords(DeleteRecordsRequest request)
        {
            var apiResponse = AsyncHelper.RunTask(() => DeleteRecordsAsync(request));
            return apiResponse;
        }

        /// <summary>
        /// Deletes a batch of records.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteRecordsAsync(DeleteRecordsRequest request)
        {
            Arg.IsNotNull(request, nameof(request));

            var path = UrlHelper.GetBatchDeleteRecordsPath();
            var apiResponse = await PostAsync(path, request);
            return apiResponse;
        }

        #endregion

        // ------------------------------------ Reports ------------------------------------

        #region Reports

        /// <summary>
        /// Gets the report for <paramref name="reportId"/>. Returns null if no report could be found.
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        [Obsolete("Using GetReportAsync is recommended.")]
        public ApiResponse<ReportData> GetReport(int reportId)
        {
            var report = AsyncHelper.RunTask(() => GetReportAsync(reportId));
            return report;
        }

        /// <summary>
        /// Gets the report for <paramref name="reportId"/>. Returns null if no report could be found.
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public async Task<ApiResponse<ReportData>> GetReportAsync(int reportId)
        {
            var path = UrlHelper.GetReportByIdPath(reportId);
            var report = await GetAsync<ReportData>(path);
            return report;
        }

        /// <summary>
        /// Gets the reports associated to the <paramref name="appId"/>.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [Obsolete("Using GetReportsForAppAsync is recommended.")]
        public ApiResponse<GetReportsForAppResponse> GetReportsForApp(int appId, PagingRequest pagingRequest = null)
        {
            var getReportsResponse = AsyncHelper.RunTask(() => GetReportsForAppAsync(appId, pagingRequest));
            return getReportsResponse;
        }

        /// <summary>
        /// Gets the reports associated to the <paramref name="appId"/>.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public async Task<ApiResponse<GetReportsForAppResponse>> GetReportsForAppAsync(int appId, PagingRequest pagingRequest = null)
        {
            var path = UrlHelper.GetReportByAppIdPath(appId, pagingRequest);
            var getReportsResponse = await GetAsync<GetReportsForAppResponse>(path);
            return getReportsResponse;
        }

        #endregion

        // ------------------------------------ Client internals ------------------------------------

        /// <summary>
        /// Performs an HTTP DELETE request to the <paramref name="path"/> and adds an API Key header.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private async Task<ApiResponse> DeleteAsync(string path)
        {
            var httpResponse = await _httpClient.DeleteAsync(path, _clientConfig.ApiKey);

            var apiResponse = await ApiResponseFactory.GetApiResponseAsync(httpResponse);
            return apiResponse;
        }

        /// <summary>
        /// Performs an HTTP GET request to the <paramref name="path"/> and adds an API Key header.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        private async Task<ApiResponse<T>> GetAsync<T>(string path)
            where T : class
        {
            var httpResponse = await _httpClient.GetAsync(path, _clientConfig.ApiKey);

            var apiResponse = await ApiResponseFactory.GetApiResponseAsync<T>(httpResponse);
            return apiResponse;
        }

        /// <summary>
        /// Performs an HTTP POST request to the <paramref name="path"/> and adds an API Key header.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private async Task<ApiResponse> PostAsync(string path, object content)
        {
            var httpResponse = await _httpClient.PostAsync(path, _clientConfig.ApiKey, content);

            var apiResponse = await ApiResponseFactory.GetApiResponseAsync(httpResponse);
            return apiResponse;
        }

        /// <summary>
        /// Performs an HTTP POST request to the <paramref name="path"/> and adds an API Key header.
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private async Task<ApiResponse<TOutput>> PostAsync<TOutput>(string path, object content)
            where TOutput : class
        {
            var httpResponse = await _httpClient.PostAsync(path, _clientConfig.ApiKey, content);

            var apiResponse = await ApiResponseFactory.GetApiResponseAsync<TOutput>(httpResponse);
            return apiResponse;
        }

        /// <summary>
        /// Performs an HTTP PUT request to the <paramref name="path"/> and adds an API Key header.
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private async Task<ApiResponse<TOutput>> PutAsync<TOutput>(string path, object content)
            where TOutput : class
        {
            var httpResponse = await _httpClient.PutAsync(path, _clientConfig.ApiKey, content);

            var apiResponse = await ApiResponseFactory.GetApiResponseAsync<TOutput>(httpResponse);
            return apiResponse;
        }
    }
}
