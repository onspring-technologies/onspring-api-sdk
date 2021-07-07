using Microsoft.AspNetCore.Mvc;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure;
using System;
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
            var record = TestDataFactory.GetFullyFilledOutRecord(appId, 1);
            var getResponse = new GetPagedRecordsResponse
            {
            };

            getResponse.Items.Add(record);

            return Ok(getResponse);
        }

        [HttpGet("appId/{appId}/recordId/{recordId}")]
        public IActionResult GetById(int appId, int recordId, [FromQuery] string fieldIds = null, [FromQuery] DataFormat dataFormat = DataFormat.Raw)
        {
            var apiRecord = TestDataFactory.GetFullyFilledOutRecord(appId, recordId);
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
