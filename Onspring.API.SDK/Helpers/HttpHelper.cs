using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
        public bool CanConnect()
        {
            var uri = _urlHelper.PingUri;
            using (var response = MakeGetRequest(uri))
            {
                return IsSuccessfulRequest(response);
            }
        }

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

        /// <summary>
        /// Used to get data produced by a specific report
        /// </summary>
        /// <param name="reportId">Report id of the desired report</param>
        /// <param name="dataType">"ReportData" or "ChartData" (if not provided, ReportData is used)</param>
        /// <param name="dataFormat">"Raw" or "Formatted" (if not provided, Raw is used)</param>
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

        /// <summary>
        /// Used to get data for multiple records
        /// </summary>
        /// <param name="appId">App id of the desired records</param>
        /// <param name="filter">e.g., "not (38 gt 10 or 38 lt 5) and 37 gt datetime'2014-03-01T00:00:00.0000000'" (intersected with recordIds - if not provided, all records (or those matching recordIds) are returned)</param>
        /// <param name="recordIds">List of recordIds (intersected with filter - if not provided, all records (or those matching the filter) are returned)</param>
        /// <param name="fieldIds">List of fieldIds to include in the output (if not provided, all fields are returned)</param>
        /// <param name="dataFormat">"Raw" or "Formatted" (if not provided, Raw is used)</param>
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

        public AddEditResult CreateAppRecord(int appId, FieldAddEditContainer fieldValues)
        {
            var recordJson = fieldValues.Serialize();
            var uri = _urlHelper.GetCreateAppRecordUri(appId);
            const string method = "POST";
            using (var response = MakeRequestWithBody(uri, method, recordJson))
            {
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return CreateSuccessfulAddEditResult(response);
                }
                throw CreateResponseException(uri, method, response);
            }
        }

        public AddEditResult UpdateAppRecord(int appId, int recordId, FieldAddEditContainer fieldValues)
        {
            var recordJson = fieldValues.Serialize();
            var uri = _urlHelper.GetUpdateAppRecordUri(appId, recordId);
            const string method = "PUT";
            using (var response = MakeRequestWithBody(uri, method, recordJson))
            {
                if (IsSuccessfulNonRedirectRequest(response))
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
                int recordId;
                if (int.TryParse(idString, out recordId))
                {
                    result.CreatedId = recordId;
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

        private HttpWebResponse MakeGetRequest(Uri uri)
        {
            return MakeRequestWithoutBody(uri, "GET");
        }

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
                response = ex.Response as HttpWebResponse;
            }
            if (IsSuccessfulNonRedirectRequest(response))
            {
                return response;
            }
            throw CreateResponseException(uri, method, response);
        }

        private HttpWebResponse MakeRequestWithBody(Uri uri, string method, string body)
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
                response = ex.Response as HttpWebResponse;
            }
            return response;
        }

        /// <summary>
        /// Initializes an instance of a HttpWebRequest with uri and api key
        /// </summary>
        private HttpWebRequest InitRequest(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
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
