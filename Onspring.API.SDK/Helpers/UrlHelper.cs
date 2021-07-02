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
    /// <summary>
    /// Helper class used to get URL values from a single location.
    /// </summary>
    public class UrlHelper
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
            var path = $"/apps?{pagingRequest.ToQueryStringParams()}";

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
        /// <param name="appId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public static string GetFieldsByAppIdPath(int appId, PagingRequest pagingRequest = null)
        {
            var path = $"/fields/appId/{appId}?{pagingRequest.ToQueryStringParams()}";

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
            return $"/lists/id/{listId}/items";
        }

        /// <summary>
        /// Gets the path for removing an item from a list.
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static string GetDeleteListItemPath(int listId, Guid itemId)
        {
            return $"/lists/id/{listId}/itemId/{itemId}";
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
            var path = $"/reports/appId/{appId}?{pagingRequest.ToQueryStringParams()}";

            return path;
        }
    }
}
