using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Onspring.API.SDK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;

namespace Onspring.API.SDK.Tests.TestServer.Controllers
{
    [ApiController, Route("[controller]")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Just a test controller. Not an API that gets shipped.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Just a test controller. Not an API that gets shipped.")]
    public class FieldsController : ControllerBase
    {
        [HttpGet("id/{fieldId}")]
        public IActionResult GetById(int fieldId)
        {
            var fields = GetTestFields();
            return Ok(fields.First());
        }

        [HttpPost("batch-get")]
        public IActionResult GetBatchById([FromBody, MinLength(1)] int[] fieldIds)
        {
            var getFieldsResponse = new
            {
                Items = GetTestFields()
            };

            return Ok(getFieldsResponse);
        }

        [HttpGet("appId/{appId}")]
        public IActionResult GetByAppId(int appId, [FromQuery] PagingRequest pagingRequest = null)
        {
            pagingRequest ??= new PagingRequest();

            var items = GetTestFields();
            var getResponse = new
            {
                Items = items.Take(pagingRequest.PageSize).ToList(),
                PageNumber = pagingRequest.PageNumber,
                TotalPages = 1,
                TotalRecords = pagingRequest.PageSize > items.Count ? items.Count : pagingRequest.PageSize,
            };

            return Ok(getResponse);
        }

        private static List<object> GetTestFields()
        {
            return new List<object>
            {
                new
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = true,
                    IsUnique  = true,
                    Name = "Regular field",
                    Status = "Enabled",
                    Type = "Text",
                },
                new
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = true,
                    IsUnique  = false,
                    Name = "List field",
                    Status = "Enabled",
                    Type = "List",
                    Multiplicity = "MultiSelect",
                    Values = new List<object>
                    {
                        new
                        {
                            Color = "#ffffff",
                            Id = Guid.NewGuid(),
                            Name = "First List Item",
                            NumericValue = 1m,
                            SortOrder = 1,
                        },
                        new
                        {
                            Color = "#ffffff",
                            Id = Guid.NewGuid(),
                            Name = "Second List Item",
                            NumericValue = 2m,
                            SortOrder = 2,
                        },
                    },
                },
                new
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = false,
                    IsUnique  = false,
                    Name = "List Formula Field",
                    Status = "Enabled",
                    Type = "Formula",
                    OutputType = "List",
                    Values = new List<object>
                    {
                        new
                        {
                            Color = "#ffffff",
                            Id = Guid.NewGuid(),
                            Name = "List Value",
                            NumericValue = 1m,
                            SortOrder = 1,
                        },
                    },
                },
                new
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = false,
                    IsUnique  = false,
                    Name = "Date/Time Formula Field",
                    Status = "Enabled",
                    Type = "Formula",
                    OutputType = "DateAndTime",
                    Values = new List<object>(),
                },
                new
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = false,
                    IsUnique  = false,
                    Name = "Numeric Formula Field",
                    Status = "Enabled",
                    Type = "Formula",
                    OutputType = "Numeric",
                    Values = new List<object>(),
                },
                new
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = false,
                    IsUnique  = false,
                    Name = "Text Formula Field",
                    Status = "Enabled",
                    Type = "Formula",
                    OutputType = "Text",
                    Values = new List<object>(),
                },
                new
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = true,
                    IsUnique  = false,
                    Name = "List field",
                    Status = "Enabled",
                    Type = "Reference",
                    Multiplicity = "SingleSelect",
                }
            };
        }
    }
}
