using Microsoft.AspNetCore.Mvc;
using Onspring.API.SDK.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.TestServer.Controllers
{
    [ApiController, Route("[controller]")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Just a test controller. Not an API that gets shipped.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Just a test controller. Not an API that gets shipped.")]
    public class ListsController : ControllerBase
    {
        [HttpPut("id/{listId}/items")]
        public IActionResult SaveListItem(int listId, [FromBody] SaveListItemRequest saveRequest)
        {
            var itemId = saveRequest.Id.HasValue == false ? Guid.NewGuid() : saveRequest.Id.Value;
            var apiResponse = new SaveListItemResponse(itemId);
            return Ok(apiResponse);
        }

        [HttpDelete("id/{listId}/itemId/{itemId}")]
        public IActionResult RemoveItemFromList(int listId, Guid itemId)
        {
            return Ok();
        }
    }
}
