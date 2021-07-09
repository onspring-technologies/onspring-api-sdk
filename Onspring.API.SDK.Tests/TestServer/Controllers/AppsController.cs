using Microsoft.AspNetCore.Mvc;
using Onspring.API.SDK.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Onspring.API.SDK.Tests.TestServer.Controllers
{
    [ApiController, Route("[controller]")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Just a test controller. Not an API that gets shipped.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Just a test controller. Not an API that gets shipped.")]
    public class AppsController : ControllerBase
    {
        public AppsController()
        {
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PagingRequest pagingRequest = null)
        {
            pagingRequest ??= new PagingRequest();
            var response = new GetPagedAppsResponse
            {
                PageNumber = pagingRequest.PageNumber,
                TotalPages = 1,
                TotalRecords = 2,
                Items = new List<App>
                {
                    GetAppForTest(1),
                    GetAppForTest(2),
                }
            };

            return Ok(response);
        }

        [HttpGet("id/{appId}")]
        public IActionResult GetById(int appId)
        {
            if (appId == 401)
            {
                return Unauthorized();
            }
            else if (appId == 403)
            {
                return StatusCode(403, new MessageResponse("Not allowed to view app."));
            }
            else if (appId == 404)
            {
                return NotFound(new MessageResponse("No app found."));
            }

            var app = GetAppForTest(appId);
            return Ok(app);
        }

        [HttpPost("batch-get")]
        public IActionResult GetBatchById([FromBody, MinLength(1)] int[] appIds)
        {
            if (appIds.Any(appId => appId == 401))
            {
                return Unauthorized();
            }
            else if (appIds.Any(appId => appId == 403))
            {
                return StatusCode(403, new MessageResponse("Not allowed to view app(s)."));
            }

            var apps = appIds.Select(GetAppForTest);

            var response = new GetAppsResponse();
            response.Items.AddRange(apps);

            return Ok(response);
        }

        private static App GetAppForTest(int appId)
        {
            return new App
            {
                Href = "https://localhost",
                Id = appId,
                Name = $"Test app {appId}",
            };
        }
    }
}
