using Microsoft.AspNetCore.Mvc;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.TestServer.Controllers
{
    [ApiController, Route("[controller]")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Just a test controller. Not an API that gets shipped.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Just a test controller. Not an API that gets shipped.")]
    public class RecordsController : ControllerBase
    {
        [HttpGet("appId/{appId}")]
        public IActionResult GetByAppId(int appId, [FromQuery] string fieldIds = null, [FromQuery] DataFormat dataFormat = DataFormat.Raw, [FromQuery] PagingRequest pagingRequest = null)
        {
            var records = new[]
            {
                new ResultRecord
                {
                    AppId = appId,
                    RecordId = 1,
                    FieldData =
                    {
                        new StringFieldValue("Test string value"),
                        new IntegerFieldValue(123),
                        new DecimalFieldValue(1.2m),
                        new DateFieldValue(DateTime.UtcNow.AddDays(-1)),
                        new TimeSpanFieldValue(new TimeSpanData()),
                        new GuidFieldValue(Guid.NewGuid()),
                        new StringListFieldValue(new List<string> {"Test StringList value" }),
                        new IntegerListFieldValue(new List<int> { 321 }),
                        new GuidListFieldValue(new List<Guid>{ Guid.NewGuid() }),
                        new AttachmentListFieldValue(new List<AttachmentFile>{ new AttachmentFile() }),
                        new ScoringGroupListFieldValue(new List<ScoringGroup>{ new ScoringGroup() }),
                        new FileListFieldValue(new List<int> { 333 } ),
                    }
                },
            };

            var getResponse = new GetPagedRecordsResponse
            {
            };

            getResponse.Items.AddRange(records);

            return Ok(getResponse);
        }

        [HttpGet("appId/{appId}/recordId/{recordId}")]
        public IActionResult GetById(int appId, int recordId, [FromQuery] string fieldIds = null, [FromQuery] DataFormat dataFormat = DataFormat.Raw)
        {
            var apiRecord = new ResultRecord();
            return Ok(apiRecord);
        }

        [HttpPost("batch-get")]
        public IActionResult GetBatch(GetRecordsRequest request)
        {
            var getResponse = new GetRecordsResponse();
            return Ok(getResponse);
        }

        [HttpPost("Query")]
        public IActionResult QueryRecords(QueryRecordsRequest request, [FromQuery] PagingRequest pagingRequest = null)
        {
            var apiResponse = new GetPagedRecordsResponse();
            return Ok(apiResponse);
        }

        [HttpPut]
        public IActionResult SaveRecord(SaveRecordRequest request)
        {
            var saveResponse = new SaveRecordResponse();

            var isInsert = request.RecordId.HasValue == false;
            if (isInsert)
            {
                saveResponse.Id = new Random().Next();
                return Created("", saveResponse);
            }
            else
            {
                saveResponse.Id = request.RecordId.Value;
                return Ok(saveResponse);
            }
        }

        [HttpDelete("appId/{appId}/recordId/{recordId}")]
        public IActionResult Delete(int appId, int recordId)
        {
            return Ok();
        }

        [HttpPost("batch-delete")]
        public IActionResult DeleteBatch(DeleteRecordsRequest request)
        {
            return Ok();
        }
    }
}
