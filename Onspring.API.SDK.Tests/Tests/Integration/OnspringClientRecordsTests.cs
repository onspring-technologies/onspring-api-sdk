using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests.Integration
{
    [TestClass, ExcludeFromCodeCoverage]
    public class OnspringClientRecordsTests
    {
        private const int _appIdWithRecords = 1;
        private const int _fieldId = 1;

        private static OnspringClient _apiClient;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var testConfiguration = TestConfiguration.LoadFromContext(testContext);
            var httpClient = HttpClientFactory.GetHttpClient(testConfiguration);

            _apiClient = new OnspringClient(testConfiguration.ApiKey, httpClient);
        }

        [TestMethod]
        public async Task GetRecordsByApp()
        {
            var getRequest = new GetRecordsByAppRequest(_appIdWithRecords);
            var getResponse = await _apiClient.GetRecordsForAppAsync(getRequest);
            AssertHelper.AssertSuccess(getResponse);
        }

        [TestMethod]
        public async Task CrudAsync()
        {
            // Prepare initial record.
            var record = TestDataFactory.GetFullyFilledOutRecord(_appIdWithRecords, default);

            // Insert
            var insertResponse = await _apiClient.SaveRecordAsync(record); // Used for single delete
            var secondInsertResponse = await _apiClient.SaveRecordAsync(record); // Used for batch delete
            AssertHelper.AssertSuccess(insertResponse);

            // Update
            record.RecordId = insertResponse.Value.Id;
            UpdateRecordFields(record);

            var updateResponse = await _apiClient.SaveRecordAsync(record);
            AssertHelper.AssertSuccess(updateResponse);

            // Reads
            // Get by ID
            var getRequest = new GetRecordRequest(_appIdWithRecords, insertResponse.Value.Id)
            {
                FieldIds = { _fieldId },
            };
            var getResponse = await _apiClient.GetRecordAsync(getRequest);
            AssertHelper.AssertSuccess(getResponse);
            AssertHelper.AssertCasting(getResponse.Value);

            // Get batch
            var getBatchRequest = new GetRecordsRequest
            {
                AppId = _appIdWithRecords,
                RecordIds = { insertResponse.Value.Id, secondInsertResponse.Value.Id },
                FieldIds = { _fieldId },
            };
            var batchGetResponse = await _apiClient.GetRecordsAsync(getBatchRequest);
            AssertHelper.AssertSuccess(batchGetResponse);
            AssertHelper.AssertCasting(batchGetResponse.Value.Items);

            // Get by app
            var pagingRequest = new PagingRequest(1, 10);
            var getByAppRequest = new GetRecordsByAppRequest(_appIdWithRecords, pagingRequest)
            {
                FieldIds = { _fieldId },
            };
            var getByAppResponse = await _apiClient.GetRecordsForAppAsync(getByAppRequest);
            AssertHelper.AssertSuccess(getByAppResponse);
            AssertHelper.AssertCasting(getByAppResponse.Value.Items);

            // Query
            var queryRequest = new QueryRecordsRequest
            {
                AppId = _appIdWithRecords,
            };
            var queryResponse = await _apiClient.QueryRecordsAsync(queryRequest);
            AssertHelper.AssertSuccess(queryResponse);
            AssertHelper.AssertCasting(queryResponse.Value.Items);

            // Delete
            // Single delete
            var deleteResponse = await _apiClient.DeleteRecordAsync(_appIdWithRecords, insertResponse.Value.Id);
            AssertHelper.AssertSuccess(deleteResponse);

            // Batch delete
            var batchDeleteRequest = new DeleteRecordsRequest(_appIdWithRecords, new[] { secondInsertResponse.Value.Id });
            var batchDeleteResponse = await _apiClient.DeleteRecordsAsync(batchDeleteRequest);
            AssertHelper.AssertSuccess(batchDeleteResponse);
        }

        private static void UpdateRecordFields(ResultRecord record)
        {
            var random = new Random();
            foreach (var field in record.FieldData)
            {
                switch (field.Type)
                {
                    case Enums.ResultValueType.String:
                        field.SetString("My new string value.");
                        break;
                    case Enums.ResultValueType.Integer:
                        field.SetInteger(random.Next());
                        break;
                    case Enums.ResultValueType.Decimal:
                        field.SetDecimal(random.Next());
                        break;
                    case Enums.ResultValueType.Date:
                        field.SetNullableDateTime(DateTime.UtcNow);
                        break;
                    case Enums.ResultValueType.TimeSpan:
                        field.SetTimeSpanData(new TimeSpanData
                        {
                            Increment = Enums.TimeSpanIncrement.Days,
                        });
                        break;
                    case Enums.ResultValueType.Guid:
                        field.SetNullableGuid(Guid.NewGuid());
                        break;
                    case Enums.ResultValueType.StringList:
                        field.SetStringList(new List<string> { Guid.NewGuid().ToString() });
                        break;
                    case Enums.ResultValueType.IntegerList:
                        field.SetIntegerList(new List<int> { random.Next(), random.Next(), random.Next(), });
                        break;
                    case Enums.ResultValueType.GuidList:
                        field.SetGuidList(new List<Guid> { Guid.NewGuid() });
                        break;
                    case Enums.ResultValueType.AttachmentList:
                        field.SetAttachmentList(new List<AttachmentFile>
                        {
                            new AttachmentFile
                            {
                                FileId = 1,
                                FileName = "Update attachment list file name",
                                Notes = "Updated notes."
                            }
                        });
                        break;
                    case Enums.ResultValueType.ScoringGroupList:
                        field.SetScoringGroupList(new List<ScoringGroup>
                        {
                            new ScoringGroup
                            {
                                ListValueId = Guid.NewGuid(),
                                MaximumScore = 1m,
                                Name = "Updated test scoring group",
                                Score = 1m,
                            }
                        });
                        break;
                    case Enums.ResultValueType.FileList:
                        field.SetFileList(new List<int> { random.Next(), random.Next(), random.Next(), });
                        break;
                    default:
                        break;
                }
            }
        }
    }
}