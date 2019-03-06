#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
// ReSharper disable UnusedMember.Global

namespace Onspring.API.SDK.Helpers
{
    public sealed class HttpHelper
    {
        private readonly UrlHelper _urlHelper;
        private readonly string _apiKey;

        public HttpHelper(string baseUrl, string apiKey)
        {
            _urlHelper = new UrlHelper(baseUrl);
            _apiKey = apiKey;
        }

        /// <summary>
        /// Pings the server and returns true if successful
        /// </summary>
        [Obsolete("Prefer use of async method")]
        public bool CanConnect()
        {
            var uri = _urlHelper.PingUri;
            using (var response = MakeGetRequest(uri))
            {
                return IsSuccessfulRequest(response);
            }
        }
        public async Task<bool> CanConnectAsync()
        {
            var uri = _urlHelper.PingUri;
            using (var response = await MakeGetRequestAsync(uri).ConfigureAwait(false))
            {
                return IsSuccessfulRequest(response);
            }
        }

        [Obsolete("Prefer use of async method")]
        public IReadOnlyList<App> GetApps()
        {
            var uri = _urlHelper.AllAppsUri;
            using (var response = MakeGetRequest(uri))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadApps(rs);
                }
            }
        }
        public async Task<IReadOnlyList<App>> GetAppsAsync()
        {
            var uri = _urlHelper.AllAppsUri;
            using (var response = await MakeGetRequestAsync(uri).ConfigureAwait(false))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadApps(rs);
                }
            }
        }

        [Obsolete("Prefer use of async method")]
        public IReadOnlyList<Field> GetAppFields(int appId)
        {
            var uri = _urlHelper.GetAppFieldsUri(appId);
            using (var response = MakeGetRequest(uri))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadFields(rs);
                }
            }
        }
        public async Task<Field> GetAppFieldAsync(int fieldId)
        {
            var uri = _urlHelper.GetAppFieldUri(fieldId);
            using (var response = await MakeGetRequestAsync(uri).ConfigureAwait(false))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadField(rs);
                }
            }
        }

        [Obsolete("Prefer use of async method")]
        public Field GetAppField(int fieldId)
        {
            var uri = _urlHelper.GetAppFieldUri(fieldId);
            using (var response = MakeGetRequest(uri))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadField(rs);
                }
            }
        }
        public async Task<IReadOnlyList<Field>> GetAppFieldsAsync(int appId)
        {
            var uri = _urlHelper.GetAppFieldsUri(appId);
            using (var response = await MakeGetRequestAsync(uri).ConfigureAwait(false))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadFields(rs);
                }
            }
        }

        [Obsolete("Prefer use of async method")]
        public IReadOnlyList<Report> GetAppReports(int appId)
        {
            var uri = _urlHelper.GetAppReportsUri(appId);
            using (var response = MakeGetRequest(uri))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadReports(rs);
                }
            }
        }
        public async Task<IReadOnlyList<Report>> GetAppReportsAsync(int appId)
        {
            var uri = _urlHelper.GetAppReportsUri(appId);
            using (var response = await MakeGetRequestAsync(uri).ConfigureAwait(false))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadReports(rs);
                }
            }
        }

        /// <summary>
        /// Used to get data produced by a specific report
        /// </summary>
        /// <param name="reportId">Report id of the desired report</param>
        /// <param name="dataType">"ReportData" or "ChartData" (if not provided, ReportData is used)</param>
        /// <param name="dataFormat">"Raw" or "Formatted" (if not provided, Raw is used)</param>
        [Obsolete("Prefer use of async method")]
        public ReportData GetReportData(int reportId, ReportDataType? dataType = null, DataFormat? dataFormat = null)
        {
            var uri = _urlHelper.GetReportDataUri(reportId, dataType, dataFormat);
            using (var response = MakeGetRequest(uri))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadReportData(rs);
                }
            }
        }
        public async Task<ReportData> GetReportDataAsync(int reportId, ReportDataType? dataType = null, DataFormat? dataFormat = null)
        {
            var uri = _urlHelper.GetReportDataUri(reportId, dataType, dataFormat);
            using (var response = await MakeGetRequestAsync(uri).ConfigureAwait(false))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadReportData(rs);
                }
            }
        }

        /// <summary>
        /// Used to get data for multiple records
        /// </summary>
        /// <param name="appId">App id of the desired records</param>
        /// <param name="filter">e.g., "not (38 gt 10 or 38 lt 5) and 37 gt datetime'2014-03-01T00:00:00.0000000'" (intersected with recordIds - if not provided, all records (or those matching recordIds) are returned)</param>
        /// <param name="recordIds">List of recordIds (intersected with filter - if not provided, all records (or those matching the filter) are returned)</param>
        /// <param name="fieldIds">List of fieldIds to include in the output (if not provided, all fields are returned)</param>
        /// <param name="dataFormat">"Raw" or "Formatted" (if not provided, Raw is used)</param>
        [Obsolete("Prefer use of async method")]
        public IReadOnlyList<ResultRecord> GetAppRecords(int appId, string filter = null, IReadOnlyList<int> recordIds = null, IReadOnlyList<int> fieldIds = null, DataFormat? dataFormat = null)
        {
            var uri = _urlHelper.GetAppRecordsUri(appId, filter, recordIds, fieldIds, dataFormat);
            using (var response = MakeGetRequest(uri))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadRecords(rs);
                }
            }
        }
        public async Task<IReadOnlyList<ResultRecord>> GetAppRecordsAsync(int appId, string filter = null, IReadOnlyList<int> recordIds = null, IReadOnlyList<int> fieldIds = null, DataFormat? dataFormat = null)
        {
            var uri = _urlHelper.GetAppRecordsUri(appId, filter, recordIds, fieldIds, dataFormat);
            using (var response = await MakeGetRequestAsync(uri).ConfigureAwait(false))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadRecords(rs);
                }
            }
        }

        [Obsolete("Prefer use of async method")]
        public ResultRecord GetAppRecord(int appId, int recordId, IReadOnlyList<int> fieldIds = null, DataFormat? dataFormat = null)
        {
            var uri = _urlHelper.GetAppRecordUri(appId, recordId, fieldIds, dataFormat);
            using (var response = MakeGetRequest(uri))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadRecord(rs);
                }
            }
        }
        public async Task<ResultRecord> GetAppRecordAsync(int appId, int recordId, IReadOnlyList<int> fieldIds = null, DataFormat? dataFormat = null)
        {
            var uri = _urlHelper.GetAppRecordUri(appId, recordId, fieldIds, dataFormat);
            using (var response = await MakeGetRequestAsync(uri).ConfigureAwait(false))
            {
                using (var rs = response.GetResponseStream())
                {
                    return JsonHelper.LoadRecord(rs);
                }
            }
        }

        [Obsolete("Prefer use of async method")]
        public DeleteResult DeleteAppRecord(int appId, int recordId)
        {
            var uri = _urlHelper.GetDeleteAppRecordUri(appId, recordId);
            using (var response = MakeRequestWithoutBody(uri, "DELETE"))
            {
                var result = new DeleteResult();
                if (response.Headers.AllKeys.Contains("Location"))
                {
                    result.Location = response.Headers["Location"];
                }
                return result;
            }
        }
        public async Task<DeleteResult> DeleteAppRecordAsync(int appId, int recordId)
        {
            var uri = _urlHelper.GetDeleteAppRecordUri(appId, recordId);
            using (var response = await MakeRequestWithoutBodyAsync(uri, "DELETE").ConfigureAwait(false))
            {
                var result = new DeleteResult();
                if (response.Headers.AllKeys.Contains("Location"))
                {
                    result.Location = response.Headers["Location"];
                }
                return result;
            }
        }

        [Obsolete("Prefer use of async method")]
        public AddEditResult CreateAppRecord(int appId, FieldAddEditContainer fieldValues)
        {
            var recordJson = fieldValues.Serialize();
            var uri = _urlHelper.GetCreateAppRecordUri(appId);
            const string method = "POST";
            using (var response = MakeRequestWithJsonBody(uri, method, recordJson))
            {
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return CreateSuccessfulAddEditResult(response);
                }
                throw CreateResponseException(uri, method, response);
            }
        }
        public async Task<AddEditResult> CreateAppRecordAsync(int appId, FieldAddEditContainer fieldValues)
        {
            var recordJson = fieldValues.Serialize();
            var uri = _urlHelper.GetCreateAppRecordUri(appId);
            const string method = "POST";
            using (var response = await MakeRequestWithJsonBodyAsync(uri, method, recordJson).ConfigureAwait(false))
            {
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return CreateSuccessfulAddEditResult(response);
                }
                throw CreateResponseException(uri, method, response);
            }
        }

        [Obsolete("Prefer use of async method")]
        public AddEditResult UpdateAppRecord(int appId, int recordId, FieldAddEditContainer fieldValues)
        {
            var recordJson = fieldValues.Serialize();
            var uri = _urlHelper.GetUpdateAppRecordUri(appId, recordId);
            const string method = "PUT";
            using (var response = MakeRequestWithJsonBody(uri, method, recordJson))
            {
                if (IsSuccessfulNonRedirectRequest(response))
                {
                    return CreateSuccessfulAddEditResult(response);
                }
                throw CreateResponseException(uri, method, response);
            }
        }
        public async Task<AddEditResult> UpdateAppRecordAsync(int appId, int recordId, FieldAddEditContainer fieldValues)
        {
            var recordJson = fieldValues.Serialize();
            var uri = _urlHelper.GetUpdateAppRecordUri(appId, recordId);
            const string method = "PUT";            
            using (var response = await MakeRequestWithJsonBodyAsync(uri, method, recordJson).ConfigureAwait(false))
            {
                if (IsSuccessfulNonRedirectRequest(response))
                {
                    return CreateSuccessfulAddEditResult(response);
                }
                throw CreateResponseException(uri, method, response);
            }            
        }

        [Obsolete("Prefer use of async method")]
        public FileResult GetFileFromRecord(int appId, int recordId, int fieldId, int fileId)
        {
            var uri = _urlHelper.GetFileFromRecordUri(appId, recordId, fieldId, fileId);
            using (var response = MakeGetRequest(uri))
            {
                long contentLength = 0;
                if (response.Headers.AllKeys.Contains("X-FileSize"))
                {
                    var fileSizeString = response.Headers["X-FileSize"];
                    long fileSize;
                    if (long.TryParse(fileSizeString, out fileSize))
                    {
                        contentLength = fileSize;
                    }
                }
                if (contentLength == 0)
                {
                    // will be -1 if Content-Length header is not present (e.g., Transfer-Encoding is chunked)
                    contentLength = response.ContentLength;
                }
                var result = new FileResult
                {
                    FileName = response.Headers["Content-Disposition"].Replace("attachment; filename=", "").Replace("\"", ""),
                    ContentType = response.ContentType,
                    ContentLength = contentLength,
                };
                using (var rs = response.GetResponseStream())
                {
                    rs?.CopyTo(result.Stream);
                }
                var streamLength = result.Stream.Length;
                if (contentLength <= 0)
                {
                    result.ContentLength = streamLength;
                }
                else if (contentLength != streamLength)
                {
                    throw new ApplicationException($"Expected {contentLength} bytes, but received {streamLength} bytes");
                }
                return result;
            }
        }
        public async Task<FileResult> GetFileFromRecordAsync(int appId, int recordId, int fieldId, int fileId)
        {
            var uri = _urlHelper.GetFileFromRecordUri(appId, recordId, fieldId, fileId);
            using (var response = await MakeGetRequestAsync(uri).ConfigureAwait(false))
            {
                long contentLength = 0;
                if (response.Headers.AllKeys.Contains("X-FileSize"))
                {
                    var fileSizeString = response.Headers["X-FileSize"];
                    long fileSize;
                    if (long.TryParse(fileSizeString, out fileSize))
                    {
                        contentLength = fileSize;
                    }
                }
                if (contentLength == 0)
                {
                    // will be -1 if Content-Length header is not present (e.g., Transfer-Encoding is chunked)
                    contentLength = response.ContentLength;
                }
                var result = new FileResult
                {
                    FileName = response.Headers["Content-Disposition"].Replace("attachment; filename=", "").Replace("\"", ""),
                    ContentType = response.ContentType,
                    ContentLength = contentLength,
                };
                using (var rs = response.GetResponseStream())
                {
                    if (rs != null)
                    {
                        await rs.CopyToAsync(result.Stream).ConfigureAwait(false);
                    }
                }
                var streamLength = result.Stream.Length;
                if (contentLength <= 0)
                {
                    result.ContentLength = streamLength;
                }
                else if (contentLength != streamLength)
                {
                    throw new ApplicationException($"Expected {contentLength} bytes, but received {streamLength} bytes");
                }
                return result;
            }
        }


        [Obsolete("Prefer use of async method")]
        public AddEditResult AddFileToRecord(int appId, int recordId, int fieldId, string filePath, string contentType, string fileNotes = null)
        {
            if (!File.Exists(filePath))
            {
                throw new ApplicationException($"File not found: {filePath}");
            }
            var fileName = Path.GetFileName(filePath);
            var modifiedTime = File.GetLastWriteTime(filePath);
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // call the other version
                return AddFileToRecord(appId, recordId, fieldId, fileStream, fileName, contentType, modifiedTime, fileNotes);
            }
        }
        public async Task<AddEditResult> AddFileToRecordAsync(int appId, int recordId, int fieldId, string filePath, string contentType, string fileNotes = null)
        {
            if (!File.Exists(filePath))
            {
                throw new ApplicationException($"File not found: {filePath}");
            }
            var fileName = Path.GetFileName(filePath);
            var modifiedTime = File.GetLastWriteTime(filePath);
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // call the other version
                return await AddFileToRecordAsync(appId, recordId, fieldId, fileStream, fileName, contentType, modifiedTime, fileNotes).ConfigureAwait(false);
            }
        }

        [Obsolete("Prefer use of async method")]
        public AddEditResult AddFileToRecord(int appId, int recordId, int fieldId, Stream fileStream, string fileName, string contentType, DateTime? modifiedTime = null, string fileNotes = null)
        {
            var uri = _urlHelper.GetAddFileToRecordUri(appId, recordId, fieldId, fileName, modifiedTime, fileNotes);
            const string method = "POST";
            using (var response = MakeRequestWithStreamBody(uri, method, fileStream, contentType))
            {
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return CreateSuccessfulAddEditResult(response);
                }
                throw CreateResponseException(uri, method, response);
            }
        }
        public async Task<AddEditResult> AddFileToRecordAsync(int appId, int recordId, int fieldId, Stream fileStream, string fileName, string contentType, DateTime? modifiedTime = null, string fileNotes = null)
        {
            var uri = _urlHelper.GetAddFileToRecordUri(appId, recordId, fieldId, fileName, modifiedTime, fileNotes);
            const string method = "POST";
            using (var response = await MakeRequestWithStreamBodyAsync(uri, method, fileStream, contentType).ConfigureAwait(false))
            {
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return CreateSuccessfulAddEditResult(response);
                }
                throw CreateResponseException(uri, method, response);
            }
        }

        private AddEditResult CreateSuccessfulAddEditResult(HttpWebResponse response)
        {
            var result = new AddEditResult();
            if (response.Headers.AllKeys.Contains("OnspringCreatedId"))
            {
                var idString = response.Headers["OnspringCreatedId"];
                int id;
                if (int.TryParse(idString, out id))
                {
                    result.CreatedId = id;
                }
            }
            if (response.Headers.AllKeys.Contains("Location"))
            {
                result.Location = response.Headers["Location"];
            }
            if (response.ContentLength > 0)
            {
                using (var rs = response.GetResponseStream())
                {
                    result.Warnings = JsonHelper.LoadWarnings(rs);
                }
            }
            return result;
        }

        /// <summary>
        /// Checks if given HttpWebResponse has a status code less than 400
        /// </summary>
        private static bool IsSuccessfulRequest(HttpWebResponse response)
        {
            return GetResponseStatusCode(response) < 400;
        }

        /// <summary>
        /// Checks if given HttpWebResponse has a status code less than 300
        /// </summary>
        private static bool IsSuccessfulNonRedirectRequest(HttpWebResponse response)
        {
            return GetResponseStatusCode(response) < 300;
        }

        private static int GetResponseStatusCode(HttpWebResponse response)
        {
            return (int)response.StatusCode;
        }

        [Obsolete]
        private HttpWebResponse MakeGetRequest(Uri uri)
        {
            return MakeRequestWithoutBody(uri, "GET");
        }
        private async Task<HttpWebResponse> MakeGetRequestAsync(Uri uri)
        {
            return await MakeRequestWithoutBodyAsync(uri, "GET").ConfigureAwait(false);
        }

        [Obsolete]
        private HttpWebResponse MakeRequestWithoutBody(Uri uri, string method)
        {
            var request = InitRequest(uri);
            request.Method = method;

            HttpWebResponse response;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = HandleWebException(ex, uri, method);
            }
            if (IsSuccessfulNonRedirectRequest(response))
            {
                return response;
            }
            throw CreateResponseException(uri, method, response);
        }
        private async Task<HttpWebResponse> MakeRequestWithoutBodyAsync(Uri uri, string method)
        {
            var request = InitRequest(uri);
            request.Method = method;

            HttpWebResponse response;
            try
            {
                response = await request.GetResponseAsync().ConfigureAwait(false) as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = HandleWebException(ex, uri, method);
            }
            if (IsSuccessfulNonRedirectRequest(response))
            {
                return response;
            }
            throw CreateResponseException(uri, method, response);
        }

        [Obsolete]
        private HttpWebResponse MakeRequestWithJsonBody(Uri uri, string method, string body)
        {
            var request = InitRequest(uri);
            request.Method = method;
            request.ContentType = "application/json;charset=utf-8";
            var data = new UTF8Encoding().GetBytes(body);
            request.ContentLength = data.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }

            HttpWebResponse response;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = HandleWebException(ex, uri, method);
            }
            return response;
        }
        private async Task<HttpWebResponse> MakeRequestWithJsonBodyAsync(Uri uri, string method, string body)
        {
            var request = InitRequest(uri);
            request.Method = method;
            request.ContentType = "application/json;charset=utf-8";
            var data = new UTF8Encoding().GetBytes(body);
            request.ContentLength = data.Length;
            using (var requestStream = await request.GetRequestStreamAsync().ConfigureAwait(false))
            {
                await requestStream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
            }

            HttpWebResponse response;
            try
            {
                response = await request.GetResponseAsync().ConfigureAwait(false) as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = HandleWebException(ex, uri, method);
            }
            return response;
        }

        [Obsolete]
        private HttpWebResponse MakeRequestWithStreamBody(Uri uri, string method, Stream fileStream, string contentType)
        {
            var request = InitRequest(uri);
            request.Method = method;
            request.ContentType = contentType;
            request.ContentLength = fileStream.Length;
            using (var requestStream = request.GetRequestStream())
            {
                fileStream.CopyTo(requestStream);
            }

            HttpWebResponse response;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = HandleWebException(ex, uri, method);
            }
            return response;
        }
        private async Task<HttpWebResponse> MakeRequestWithStreamBodyAsync(Uri uri, string method, Stream fileStream, string contentType)
        {
            var request = InitRequest(uri);
            request.Method = method;
            request.ContentType = contentType;
            request.ContentLength = fileStream.Length;
            using (var requestStream = await request.GetRequestStreamAsync().ConfigureAwait(false))
            {
                await fileStream.CopyToAsync(requestStream).ConfigureAwait(false);
            }

            HttpWebResponse response;
            try
            {
                response = await request.GetResponseAsync().ConfigureAwait(false) as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = HandleWebException(ex, uri, method);
            }
            return response;
        }

        private HttpWebResponse HandleWebException(WebException ex, Uri uri, string method)
        {
            var result = ex.Response as HttpWebResponse;
            if (result == null)
            {
                // e.g., timeout
                var message = $"Request to {method} '{uri}' failed ({ex.Message}). ";
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    message += "\r\n" + innerException.Message;
                    innerException = innerException.InnerException;
                }
                throw new ApplicationException(message);
            }
            return result;
        }

        /// <summary>
        /// Initializes an instance of a HttpWebRequest with uri and api key
        /// </summary>
        private HttpWebRequest InitRequest(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Proxy = null;
            request.Headers.Add("X-ApiKey", _apiKey);
            return request;
        }

        private ApplicationException CreateResponseException(Uri uri, string method, HttpWebResponse response)
        {
            var message = $"Request to {method} '{uri}' failed ({GetResponseStatusCode(response)}). ";
            if (response.ContentLength > 0)
            {
                using (var rs = response.GetResponseStream())
                {
                    var errors = JsonHelper.LoadErrors(rs);
                    if (errors.Any())
                    {
                        message += string.Join("\r\n", errors);
                    }
                }
            }
            return new ApplicationException(message);
        }

    }
}
