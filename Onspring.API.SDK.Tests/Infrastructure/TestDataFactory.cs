using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.Infrastructure
{
    [ExcludeFromCodeCoverage]
    internal static class TestDataFactory
    {
        public static ResultRecord GetFullyFilledOutRecord(int appId, int recordId)
        {
            return new ResultRecord
            {
                AppId = appId,
                RecordId = recordId,
                FieldData =
                    {
                        new StringFieldValue(1, "Test string value"),
                        new IntegerFieldValue(2, 123),
                        new DecimalFieldValue(3, 1.2m),
                        new DateFieldValue(4, DateTime.UtcNow.AddDays(-1)),
                        new TimeSpanFieldValue(5, new TimeSpanData { Recurrence = TimeSpanRecurrenceType.None }),
                        new GuidFieldValue(6, Guid.NewGuid()),
                        new StringListFieldValue(7, new List<string> {"Test StringList value" }),
                        new IntegerListFieldValue(8, new List<int> { 321 }),
                        new GuidListFieldValue(9, new List<Guid>{ Guid.NewGuid() }),
                        new AttachmentListFieldValue(10, new List<AttachmentFile>{ new AttachmentFile() }),
                        new ScoringGroupListFieldValue(11, new List<ScoringGroup>{ new ScoringGroup() }),
                        new FileListFieldValue(12, new List<int> { 333 } ),
                    }
            };
        }

        public static List<GetPagedAppsResponse> GetPagesOfApps(int totalApps, int pageSize) => GetPages(
            totalApps,
            pageSize,
            i => new App { Id = i, Name = "App" },
            (pageNumber, totalPages, totalRecords, items) => new GetPagedAppsResponse
            {
                PageNumber = pageNumber,
                TotalPages = totalPages,
                TotalRecords = totalRecords,
                Items = items
            }
        );

        public static List<GetPagedFieldsResponse> GetPagesOfFields(int totalFields, int pageSize) => GetPages(
            totalFields,
            pageSize,
            i => new Field { Id = i, Name = "Field" },
            (pageNumber, totalPages, totalRecords, items) => new GetPagedFieldsResponse
            {
                PageNumber = pageNumber,
                TotalPages = totalPages,
                TotalRecords = totalRecords,
                Items = items
            }
        );

        public static List<GetReportsForAppResponse> GetPagesOfReports(int totalReports, int pageSize) => GetPages(
            totalReports,
            pageSize,
            i => new Report { Id = i, Name = "Report" },
            (pageNumber, totalPages, totalRecords, items) => new GetReportsForAppResponse
            {
                PageNumber = pageNumber,
                TotalPages = totalPages,
                TotalRecords = totalRecords,
                Items = items
            }
        );

        public static List<GetPagedRecordsResponse> GetPagesOfRecords(int totalRecords, int pageSize) => GetPages(
            totalRecords,
            pageSize,
            i => new ResultRecord { RecordId = i },
            (pageNumber, totalPages, totalRecords, items) => new GetPagedRecordsResponse
            {
                PageNumber = pageNumber,
                TotalPages = totalPages,
                TotalRecords = totalRecords,
                Items = items
            }
        );

        public static List<TResponse> GetPages<TItem, TResponse>(
            int totalItems,
            int pageSize,
            Func<int, TItem> createItem,
            Func<int, int, int, List<TItem>, TResponse> createResponse
        ) where TResponse : class
        {
            var pages = new List<TResponse>();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            for (var i = 1; i <= totalPages; i++)
            {
                var items = new List<TItem>();

                for (var j = 1; j <= pageSize; j++)
                {
                    var itemIndex = (i - 1) * pageSize + j;

                    if (itemIndex > totalItems)
                    {
                        break;
                    }

                    items.Add(createItem(itemIndex));
                }

                var response = createResponse(i, totalPages, totalItems, items);
                pages.Add(response);
            }

            return pages;
        }

    }
}
