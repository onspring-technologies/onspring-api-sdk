using Microsoft.AspNetCore.Mvc;
using Onspring.API.SDK.Models;
using System;
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
            var getFieldsResponse = new GetFieldsResponse
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
            var getResponse = new GetPagedFieldsResponse
            {
                Items = items.Take(pagingRequest.PageSize).ToList(),
                PageNumber = pagingRequest.PageNumber,
                TotalPages = 1,
                TotalRecords = pagingRequest.PageSize > items.Count ? items.Count : pagingRequest.PageSize,
            };

            return Ok(getResponse);
        }

        private static List<Field> GetTestFields()
        {
            return new List<Field>
            {
                new Field
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = true,
                    IsUnique  = true,
                    Name = "Regular field",
                    Status = Enums.FieldStatus.Enabled,
                    Type = Enums.FieldType.Text,
                },
                new ListField
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = true,
                    IsUnique  = false,
                    Name = "List field",
                    Status = Enums.FieldStatus.Enabled,
                    Type = Enums.FieldType.List,
                    Multiplicity = Enums.Multiplicity.MultiSelect,
                    Values = new List<ListValue>
                    {
                        new ListValue
                        {
                            Color = "#ffffff",
                            Id = Guid.NewGuid(),
                            Name = "First List Item",
                            NumericValue = 1m,
                            SortOrder = 1,
                        },
                        new ListValue
                        {
                            Color = "#ffffff",
                            Id = Guid.NewGuid(),
                            Name = "Second List Item",
                            NumericValue = 2m,
                            SortOrder = 2,
                        },
                    },
                },
                new FormulaField
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = true,
                    IsUnique  = false,
                    Name = "List field",
                    Status = Enums.FieldStatus.Enabled,
                    Type = Enums.FieldType.Formula,
                    OutputType = Enums.FormulaOutputType.Date,
                    Values = new List<ListValue>
                    {
                        new ListValue
                        {
                            Color = "#ffffff",
                            Id = Guid.NewGuid(),
                            Name = "First Formula",
                            NumericValue = 1m,
                            SortOrder = 1,
                        },
                    },
                },
                new ReferenceField
                {
                    AppId = 1,
                    Id = 1,
                    IsRequired = true,
                    IsUnique  = false,
                    Name = "List field",
                    Status = Enums.FieldStatus.Enabled,
                    Type = Enums.FieldType.Reference,
                    Multiplicity = Enums.Multiplicity.SingleSelect,
                }
            };
        }
    }
}
