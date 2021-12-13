using Microsoft.AspNetCore.Mvc;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.TestServer.Controllers
{
    [ApiController, Route("[controller]")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Just a test controller. Not an API that gets shipped.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Just a test controller. Not an API that gets shipped.")]
    public class ReportsController : ControllerBase
    {
        [HttpGet("id/{reportId}")]
        public IActionResult GetById(int reportId, [FromQuery] DataFormat apiDataFormat = DataFormat.Raw, [FromQuery] ReportDataType dataType = ReportDataType.ReportData)
        {
            var report = new ReportData
            {
                Columns = new List<string>
                {
                    "Id",
                    "Name",
                    "Description"
                },
                Rows = new List<ReportDataRow>()
            };

            if (dataType == ReportDataType.ChartData)
            {
                report.Rows.Add(new ReportDataRow
                {
                    RecordId = 1,
                    Cells = new List<object>
                    {
                        "1",
                        "Test Name 1",
                        "Test description 1"
                    }
                });

                report.Rows.Add(new ReportDataRow
                {
                    RecordId = 2,
                    Cells = new List<object>
                    {
                        "2",
                        "Test Name 2",
                        "Test description 2"
                    }
                });
            }
            else
            {
                report.Rows.Add(new ReportDataRow
                {
                    RecordId = 1,
                    Cells = new List<object> { "1" }
                });

                report.Rows.Add(new ReportDataRow
                {
                    RecordId = 2,
                    Cells = new List<object> { "2" }
                });
            }
            return Ok(report);
        }

        [HttpGet("appId/{appId}")]
        public IActionResult GetByAppId(int appId, [FromQuery] PagingRequest pagingRequest = null)
        {
            pagingRequest ??= new PagingRequest();

            var report = new Report
            {
                AppId = appId,
                Description = "Test description",
                Id = 1,
                Name = "Test name",
            };

            var apiResponse = new GetReportsForAppResponse
            {
                Items = new List<Report> { report },
                TotalRecords = 1,
                TotalPages = 1,
                PageNumber = pagingRequest.PageNumber > 0 ? pagingRequest.PageNumber : 1,
            };
            return Ok(apiResponse);
        }
    }
}
