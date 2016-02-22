using System;
using System.Collections.Generic;
using System.Linq;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.Helpers
{
    public sealed class UrlHelper
    {
        private readonly Uri _baseUri;

        /// <summary>
        /// baseUrl is assumed to include the api version - e.g., https://api.onspring.com/v1
        /// </summary>
        public UrlHelper(string baseUrl)
        {
            _baseUri = new Uri(baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/");
        }

        public Uri PingUri
        {
            get
            {
                var builder = new UriBuilder(_baseUri);
                builder.Path += "ping";
                return builder.Uri;
            }
        }

        public Uri AllAppsUri
        {
            get
            {
                var builder = new UriBuilder(_baseUri);
                builder.Path += "apps";
                return builder.Uri;
            }
        }

        /// <summary>
        /// Used to get information for a single field using its id
        /// </summary>
        public Uri GetAppFieldUri(int fieldId)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path += "fields/" + fieldId;
            return builder.Uri;
        }

        /// <summary>
        /// Used to get information for all fields in an app
        /// </summary>
        public Uri GetAppFieldsUri(int appId)
        {
            var builder = new UriBuilder(_baseUri);
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
            var builder = new UriBuilder(_baseUri);
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
            var builder = new UriBuilder(_baseUri);
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
            var builder = new UriBuilder(_baseUri);
            builder.Path += "records/" + appId;
            return builder.Uri;
        }

        public Uri GetUpdateAppRecordUri(int appId, int recordId)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path += $"records/{appId}/{recordId}";
            return builder.Uri;
        }

        public Uri GetDeleteAppRecordUri(int appId, int recordId)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path += $"records/{appId}/{recordId}";
            return builder.Uri;
        }

        /// <summary>
        /// Used to get a list of all reports in an app
        /// </summary>
        public Uri GetAppReportsUri(int appId)
        {
            var builder = new UriBuilder(_baseUri);
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
            var builder = new UriBuilder(_baseUri);
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
