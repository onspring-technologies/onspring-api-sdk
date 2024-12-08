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

        public static List<GetPagedAppsResponse> GetPagesOfApps(int totalApps, int pageSize)
        {
            var pages = new List<GetPagedAppsResponse>();
            var totalPages = (int)Math.Ceiling((double)totalApps / pageSize);

            for (var i = 1; i <= totalPages; i++)
            {
                var page = new GetPagedAppsResponse
                {
                    PageNumber = i,
                    TotalPages = totalPages,
                    TotalRecords = totalApps,
                    Items = []
                };

                for (var j = 1; j <= pageSize; j++)
                {
                    var app = new App
                    {
                        Id = (i - 1) * pageSize + j,
                        Name = "App"
                    };

                    page.Items.Add(app);
                }

                pages.Add(page);
            }

            return pages;
        }
    }
}
