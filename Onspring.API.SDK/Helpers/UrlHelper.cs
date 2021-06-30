#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Extensions;
using Onspring.API.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Onspring.API.SDK.Helpers
{
    public sealed class UrlHelper
    {
        /// <summary>
        /// Gets the path to the ping endpoint.
        /// </summary>
        /// <returns></returns>
        public static string GetPingPath()
        {
            return "/ping";
        }

        /// <summary>
        /// Gets the path for getting apps.
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public static string GetAppsPath(PagingRequest pagingRequest = null)
        {
            var path = "/apps";

            if (pagingRequest != null)
            {
                path += $"?{pagingRequest.ToQueryStringParams()}";
            }

            return path;
        }

        /// <summary>
        /// Gets the path for getting an app by its identifier.
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public static string GetAppByIdPath(int appId)
        {
            return $"/apps/id/{appId}";
        }

        /// <summary>
        /// Gets the path for getting a batch of apps.
        /// </summary>
        /// <returns></returns>
        public static string GetAppsBatchPath()
        {
            return "/apps/batch-get";
        }

        /// <summary>
        /// Gets the path for getting a field by its identifier.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        public static string GetFieldByIdPath(int fieldId)
        {
            return $"/fields/id/{fieldId}";
        }

        /// <summary>
        /// Gets the path for getting a batch of fields.
        /// </summary>
        /// <returns></returns>
        public static string GetFieldsBatchPath()
        {
            return "/fields/batch-get";
        }

        /// <summary>
        /// Gets the path for getting fields for the <paramref name="appId"/>.
        /// </summary>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        public static string GetFieldsByAppIdPath(int appId, PagingRequest pagingRequest = null)
        {
            var path = $"/fields/appId/{appId}";

            if (pagingRequest != null)
            {
                path += $"?{pagingRequest.ToQueryStringParams()}";
            }

            return path;
        }

        /// <summary>
        /// Gets the path to get a file's information.
        /// </summary>
        /// <returns></returns>
        public static string GetFileInfoPath(int recordId, int fieldId, int fileId)
        {
            return $"/files/recordId/{recordId}/fieldId/{fieldId}/fileId/{fileId}";
        }

        /// <summary>
        /// Gets the path to get a file.
        /// </summary>
        /// <returns></returns>
        public static string GetFilePath(int recordId, int fieldId, int fileId)
        {
            return $"/files/recordId/{recordId}/fieldId/{fieldId}/fileId/{fileId}/file";
        }

        /// <summary>
        /// Gets the path for saving a file.
        /// </summary>
        /// <returns></returns>
        public static string GetSaveFilePath()
        {
            return "/files";
        }

        /// <summary>
        /// Gets the path to delete a file.
        /// </summary>
        /// <returns></returns>
        public static string GetDeleteFilePath(int recordId, int fieldId, int fileId)
        {
            return $"/files/recordId/{recordId}/fieldId/{fieldId}/fileId/{fileId}";
        }

        /// <summary>
        /// Gets the path for adding an item to a list.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public static string GetSaveListItemPath(int listId)
        {
            return $"/id/{listId}/items";
        }

        /// <summary>
        /// Gets the path for removing an item from a list.
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static string GetDeleteListItemPath(int listId, Guid itemId)
        {
            return $"/id/{listId}/itemId/{itemId}";
        }

        /// <summary>
        /// Gets the path for getting records for a given app.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="fieldIds"></param>
        /// <param name="dataFormat"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public static string GetRecordsByAppIdPath(int appId, List<int> fieldIds, DataFormat dataFormat, PagingRequest pagingRequest = null)
        {
            var path = $"/records/appId/{appId}?dataFormat={dataFormat}";

            if (fieldIds != null && fieldIds.Any())
            {
                var fields = string.Join(",", fieldIds);
                path += $"&fieldIds={WebUtility.UrlEncode(fields)}";
            }

            if (pagingRequest != null)
            {
                path += $"&{pagingRequest.ToQueryStringParams()}";
            }

            return path;
        }

        /// <summary>
        /// Gets the path for getting a record by its identifier.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="recordId"></param>
        /// <param name="fieldIds"></param>
        /// <param name="dataFormat"></param>
        /// <returns></returns>
        public static string GetRecordByIdPath(int appId, int recordId, List<int> fieldIds, DataFormat dataFormat)
        {
            var path = $"/records/appId/{appId}/recordId/{recordId}?dataFormat={dataFormat}";

            if (fieldIds != null && fieldIds.Any())
            {
                var fields = string.Join(",", fieldIds);
                path += $"&fieldIds={HttpUtility.UrlEncode(fields)}";
            }

            return path;
        }

        /// <summary>
        /// Gets the path for getting a batch of records.
        /// </summary>
        /// <returns></returns>
        public static string GetRecordsBatchPath()
        {
            return "/records/batch-get";
        }

        /// <summary>
        /// Gets the path for querying records.
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public static string GetQueryRecordsPath(PagingRequest pagingRequest = null)
        {
            return $"/records/query?{pagingRequest.ToQueryStringParams()}";
        }

        /// <summary>
        /// Gets the path for saving a record.
        /// </summary>
        /// <returns></returns>
        public static string GetSaveRecordPath()
        {
            return "/records/";
        }

        /// <summary>
        /// Gets the path for deleting a record.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public static string GetDeleteRecordPath(int appId, int recordId)
        {
            return $"/records/appId/{appId}/recordId/{recordId}";
        }

        /// <summary>
        /// Gets the path for deleting a batch of records.
        /// </summary>
        /// <returns></returns>
        public static string GetBatchDeleteRecordsPath()
        {
            return $"/records/batch-delete";
        }

        /// <summary>
        /// Gets the path for getting a report by its identifier.
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns></returns>
        public static string GetReportByIdPath(int reportId)
        {
            return $"/reports/id/{reportId}";
        }

        /// <summary>
        /// Gets the path for getting a report for the <paramref name="appId"/>.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public static string GetReportByAppIdPath(int appId, PagingRequest pagingRequest = null)
        {
            var path = $"/reports/appId/{appId}";

            if (pagingRequest != null)
            {
                path += $"?{pagingRequest.ToQueryStringParams()}";
            }

            return path;
        }



        /// <summary>
        /// baseUrl is assumed to include the api version - e.g., https://api.onspring.com/v1
        /// </summary>
        public UrlHelper(string baseUrl)
        {
            BaseUri = new Uri(baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/");
        }

        public Uri BaseUri { get; }

        public Uri PingUri
        {
            get
            {
                var builder = new UriBuilder(BaseUri);
                builder.Path += "ping";
                return builder.Uri;
            }
        }

        public Uri AllAppsUri
        {
            get
            {
                var builder = new UriBuilder(BaseUri);
                builder.Path += "apps";
                return builder.Uri;
            }
        }

        /// <summary>
        /// Used to get information for a single field using its id
        /// </summary>
        public Uri GetAppFieldUri(int fieldId)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += "fields/" + fieldId;
            return builder.Uri;
        }

        /// <summary>
        /// Used to get information for all fields in an app
        /// </summary>
        public Uri GetAppFieldsUri(int appId)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += "fields";
            builder.Query = "appId=" + appId;
            return builder.Uri;
        }

        /// <summary>
        /// Used to get data for multiple records
        /// </summary>
        /// <param name="appId">App id of the desired records</param>
        /// <param name="filter">e.g., "not (38 gt 10 or 38 lt 5) and 37 gt datetime'2014-03-01T00:00:00.0000000'" (intersected with recordIds - if not provided, all records (or those matching recordIds) are returned)</param>
        /// <param name="recordIds">List of recordIds (intersected with filter - if not provided, all records (or those matching the filter) are returned)</param>
        /// <param name="fieldIds">List of fieldIds to include in the output (if not provided, all fields are returned)</param>
        /// <param name="dataFormat">"Raw" or "Formatted" (if not provided, Raw is used)</param>
        public Uri GetAppRecordsUri(int appId, string filter = null, IReadOnlyList<int> recordIds = null, IReadOnlyList<int> fieldIds = null, DataFormat? dataFormat = null)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += "records/" + appId;
            var queryBuilder = new QueryBuilder();
            if (!string.IsNullOrEmpty(filter))
            {
                queryBuilder.Add("$filter", filter);
            }
            if (recordIds != null && recordIds.Any())
            {
                queryBuilder.Add("recordIds", string.Join(",", recordIds));
            }
            if (fieldIds != null && fieldIds.Any())
            {
                queryBuilder.Add("fieldIds", string.Join(",", fieldIds));
            }
            if (dataFormat != null)
            {
                queryBuilder.Add("dataFormat", dataFormat);
            }
            builder.Query = queryBuilder.ToString();
            return builder.Uri;
        }

        /// <summary>
        /// Used to get data for a specific record
        /// </summary>
        /// <param name="appId">App id of the desired record</param>
        /// <param name="recordId">Record id of the desired record</param>
        /// <param name="fieldIds">List of fieldIds to include in the output (if not provided, all fields are returned)</param>
        /// <param name="dataFormat">"Raw" or "Formatted" (if not provided, Raw is used)</param>
        public Uri GetAppRecordUri(int appId, int recordId, IReadOnlyList<int> fieldIds = null, DataFormat? dataFormat = null)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += $"records/{appId}/{recordId}";
            var queryBuilder = new QueryBuilder();
            if (fieldIds != null && fieldIds.Any())
            {
                queryBuilder.Add("fieldIds", string.Join(",", fieldIds));
            }
            if (dataFormat != null)
            {
                queryBuilder.Add("dataFormat", dataFormat);
            }
            builder.Query = queryBuilder.ToString();
            return builder.Uri;
        }

        public Uri GetCreateAppRecordUri(int appId)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += "records/" + appId;
            return builder.Uri;
        }

        public Uri GetUpdateAppRecordUri(int appId, int recordId)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += $"records/{appId}/{recordId}";
            return builder.Uri;
        }

        public Uri GetDeleteAppRecordUri(int appId, int recordId)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += $"records/{appId}/{recordId}";
            return builder.Uri;
        }

        /// <summary>
        /// Used to get a list of all reports in an app
        /// </summary>
        public Uri GetAppReportsUri(int appId)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += "reports";
            builder.Query = "appId=" + appId;
            return builder.Uri;
        }

        /// <summary>
        /// Used to get data produced by a specific report
        /// </summary>
        /// <param name="reportId">Report id of the desired report</param>
        /// <param name="dataType">"ReportData" or "ChartData" (if not provided, ReportData is used)</param>
        /// <param name="dataFormat">"Raw" or "Formatted" (if not provided, Raw is used)</param>
        public Uri GetReportDataUri(int reportId, ReportDataType? dataType = null, DataFormat? dataFormat = null)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += $"reports/{reportId}";
            var queryBuilder = new QueryBuilder();
            if (dataType != null)
            {
                queryBuilder.Add("dataType", dataType);
            }
            if (dataFormat != null)
            {
                queryBuilder.Add("dataFormat", dataFormat);
            }
            builder.Query = queryBuilder.ToString();
            return builder.Uri;
        }

        public Uri GetFileFromRecordUri(int appId, int recordId, int fieldId, int fileId)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += $"files/{appId}/{recordId}/{fieldId}";
            builder.Query = "fileId=" + fileId;
            return builder.Uri;
        }

        public Uri GetAddFileToRecordUri(int appId, int recordId, int fieldId, string fileName,
            DateTime? modifiedTime = null, string fileNotes = null)
        {
            var builder = new UriBuilder(BaseUri);
            builder.Path += $"files/{appId}/{recordId}/{fieldId}";
            var queryBuilder = new QueryBuilder();
            queryBuilder.Add("fileName", fileName);
            if (modifiedTime != null)
            {
                queryBuilder.Add("modifiedTime", modifiedTime.Value.ToUniversalTime().ToString("u"));
            }
            if (fileNotes != null)
            {
                queryBuilder.Add("fileNotes", fileNotes);
            }
            builder.Query = queryBuilder.ToString();
            return builder.Uri;
        }

        private class QueryBuilder
        {
            private readonly List<string> _segments = new List<string>();

            public void Add(string key, object value)
            {
                _segments.Add($"{key}={value}");
            }

            public override string ToString()
            {
                return string.Join("&", _segments);
            }

        }

    }
}
