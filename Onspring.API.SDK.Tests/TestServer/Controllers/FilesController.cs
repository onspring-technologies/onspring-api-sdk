﻿using Microsoft.AspNetCore.Mvc;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.Tests.Infrastructure.Helpers;
using Onspring.API.SDK.Tests.TestServer.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.TestServer.Controllers
{
    [ApiController, Route("[controller]")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Just a test controller. Not an API that gets shipped.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Just a test controller. Not an API that gets shipped.")]
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
            return File(fileStream, "image/png", "Test file name.png");
        }

        [HttpPost]
        public IActionResult SaveFile([FromForm, Required] ApiSaveFileRequest request)
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
