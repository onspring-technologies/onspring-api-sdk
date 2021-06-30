using Microsoft.AspNetCore.Mvc;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.TestServer.Controllers
{
    [ApiController, Route("[controller]")]
    [ExcludeFromCodeCoverage]
    public class FilesController : ControllerBase
    {
        [HttpGet("recordId/{recordId}/fieldId/{fieldId}/fileId/{fileId}")]
        public IActionResult GetFileMetadata(int recordId, int fieldId, int fileId)
        {
            var getResponse = new GetFileInfoResponse();
            return Ok(getResponse);
        }

        [HttpGet("recordId/{recordId}/fieldId/{fieldId}/fileId/{fileId}/file")]
        public IActionResult GetFile(int recordId, int fieldId, int fileId)
        {
            var path = TestHelper.GetDefaultImagePath();

            var fileStream = System.IO.File.OpenRead(path);
            return File(fileStream, "image/png");
        }

        [HttpPost]
        public IActionResult SaveFile([FromForm, Required] SaveFileRequest request)
        {
            return Created("", new CreatedWithIdResponse<int>(new Random().Next()));
        }

        [HttpDelete("recordId/{recordId}/fieldId/{fieldId}/fileId/{fileId}")]
        public IActionResult Delete(int recordId, int fieldId, int fileId)
        {
            return NoContent();
        }
    }
}
