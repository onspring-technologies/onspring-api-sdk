using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.Infrastructure.Http;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Tests.Tests
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
            var getResponse = await _apiClient.GetRecordsByAppAsync(getRequest);
            AssertHelper.AssertSuccess(getResponse);
        }

        [TestMethod]
        public void Crud()
        {
            var record = GetTestRecord();

            // Insert
            var saveRequest = new SaveRecordRequest
            {
                AppId = _appIdWithRecords,
            };

            var insertResponse = _apiClient.SaveRecord(saveRequest); // Used for single delete
            var secondInsertResponse = _apiClient.SaveRecord(saveRequest); // Used for batch delete
            AssertHelper.AssertSuccess(insertResponse);

            // Update
            saveRequest.RecordId = insertResponse.Value.Id;
            var updateResponse = _apiClient.SaveRecord(saveRequest);
            AssertHelper.AssertSuccess(updateResponse);

            // Reads
            // Get by ID
            var getRequest = new GetRecordRequest(_appIdWithRecords, insertResponse.Value.Id)
            {
                FieldIds = { _fieldId }
            };
            var getResponse = _apiClient.GetRecord(getRequest);
            AssertHelper.AssertSuccess(getResponse);

            // Get batch
            var getBatchRequest = new GetRecordsRequest
            {
                AppId = _appIdWithRecords,
                RecordIds = { insertResponse.Value.Id, secondInsertResponse.Value.Id },
                FieldIds = { _fieldId }
            };
            var batchGetResponse = _apiClient.GetRecords(getBatchRequest);
            AssertHelper.AssertSuccess(batchGetResponse);

            // Get by app
            var pagingRequest = new PagingRequest(1, 10);
            var getByAppRequest = new GetRecordsByAppRequest(_appIdWithRecords, pagingRequest)
            {
                FieldIds = { _fieldId }
            };
            var getByAppResponse = _apiClient.GetRecordsByApp(getByAppRequest);
            AssertHelper.AssertSuccess(getByAppResponse);

            // Query
            var queryRequest = new QueryRecordsRequest
            {
                AppId = _appIdWithRecords,
            };
            var queryResponse = _apiClient.QueryRecords(queryRequest);
            AssertHelper.AssertSuccess(queryResponse);

            // Delete
            // Single delete
            var deleteResponse = _apiClient.DeleteRecord(saveRequest.AppId, insertResponse.Value.Id);
            AssertHelper.AssertSuccess(deleteResponse);

            // Batch delete
            var batchDeleteRequest = new DeleteRecordsRequest(_appIdWithRecords, new[] { secondInsertResponse.Value.Id });
            var batchDeleteResponse = _apiClient.DeleteRecords(batchDeleteRequest);
            AssertHelper.AssertSuccess(batchDeleteResponse);
        }

        [TestMethod]
        public async Task CrudAsync()
        {
            var record = GetTestRecord();

            // Insert
            var saveRequest = new SaveRecordRequest
            {
                AppId = _appIdWithRecords,
            };

            var insertResponse = await _apiClient.SaveRecordAsync(saveRequest); // Used for single delete
            var secondInsertResponse = await _apiClient.SaveRecordAsync(saveRequest); // Used for batch delete
            AssertHelper.AssertSuccess(insertResponse);

            // Update
            saveRequest.RecordId = insertResponse.Value.Id;
            var updateResponse = await _apiClient.SaveRecordAsync(saveRequest);
            AssertHelper.AssertSuccess(updateResponse);

            // Reads
            // Get by ID
            var getRequest = new GetRecordRequest(_appIdWithRecords, insertResponse.Value.Id);
            var getResponse = await _apiClient.GetRecordAsync(getRequest);
            AssertHelper.AssertSuccess(getResponse);
            AssertCasting(getResponse.Value);

            // Get batch
            var getBatchRequest = new GetRecordsRequest
            {
                AppId = _appIdWithRecords,
                RecordIds = { insertResponse.Value.Id, secondInsertResponse.Value.Id },
            };
            var batchGetResponse = await _apiClient.GetRecordsAsync(getBatchRequest);
            AssertHelper.AssertSuccess(batchGetResponse);
            AssertCasting(batchGetResponse.Value.Items);

            // Get by app
            var pagingRequest = new PagingRequest(1, 10);
            var getByAppRequest = new GetRecordsByAppRequest(_appIdWithRecords, pagingRequest);
            var getByAppResponse = _apiClient.GetRecordsByApp(getByAppRequest);
            AssertHelper.AssertSuccess(getByAppResponse);
            AssertCasting(getByAppResponse.Value.Items);

            // Query
            var queryRequest = new QueryRecordsRequest
            {
                AppId = _appIdWithRecords,
            };
            var queryResponse = await _apiClient.QueryRecordsAsync(queryRequest);
            AssertHelper.AssertSuccess(queryResponse);
            AssertCasting(queryResponse.Value.Items);

            // Delete
            // Single delete
            var deleteResponse = await _apiClient.DeleteRecordAsync(saveRequest.AppId, insertResponse.Value.Id);
            AssertHelper.AssertSuccess(deleteResponse);

            // Batch delete
            var batchDeleteRequest = new DeleteRecordsRequest(_appIdWithRecords, new[] { secondInsertResponse.Value.Id });
            var batchDeleteResponse = await _apiClient.DeleteRecordsAsync(batchDeleteRequest);
            AssertHelper.AssertSuccess(batchDeleteResponse);
        }

        private static ResultRecord GetTestRecord()
        {
            return new ResultRecord
            {
            };
        }

        private static void AssertCasting(List<ResultRecord> records)
        {
            foreach (var record in records)
            {
                AssertCasting(record);
            }
        }

        private static void AssertCasting(ResultRecord record)
        {
            if (record == null || record.FieldData.Any() == false)
            {
                return;
            }

            foreach (var field in record.FieldData)
            {
                switch (field.Type)
                {
                    case Enums.ResultValueType.String:
                        var str = field.AsString();
                        break;
                    case Enums.ResultValueType.Integer:
                        var integer = field.AsNullableInteger();
                        break;
                    case Enums.ResultValueType.Decimal:
                        var dec = field.AsNullableDecimal();
                        break;
                    case Enums.ResultValueType.Date:
                        var date = field.AsNullableDateTime();
                        break;
                    case Enums.ResultValueType.TimeSpan:
                        var timeSpan = field.AsTimeSpanData();
                        break;
                    case Enums.ResultValueType.Guid:
                        var guid = field.AsNullableGuid();
                        break;
                    case Enums.ResultValueType.StringList:
                        var stringList = field.AsStringList();
                        break;
                    case Enums.ResultValueType.IntegerList:
                        var intList = field.AsIntegerList();
                        break;
                    case Enums.ResultValueType.GuidList:
                        var guidList = field.AsGuidList();
                        break;
                    case Enums.ResultValueType.AttachmentList:
                        var attachments = field.AsAttachmentList();
                        break;
                    case Enums.ResultValueType.ScoringGroupList:
                        var scoringGroups = field.AsScoringGroupList();
                        break;
                    case Enums.ResultValueType.FileList:
                        var files = field.AsFileList();
                        break;
                    default:
                        Assert.Fail($"Unknown field type for casting: {field.Type}");
                        break;
                }
            }
        }
    }
}
