using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.TestServer.Controllers
{
    [ApiController, Route("[controller]")]
    [ExcludeFromCodeCoverage]
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Just a test controller. Not an API that gets shipped.")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Just a test controller. Not an API that gets shipped.")]
    public class ErrorResponseController : ControllerBase
    {
        [HttpGet("non-json-unauthorized")]
        public IActionResult NonJsonUnauthorized()
        {
            var htmlContent = "<html><body>Unauthorized</body></html>";
            return new ContentResult
            {
                Content = htmlContent,
                ContentType = "text/html; charset=utf-8",
                StatusCode = 401
            };
        }

        [HttpGet("non-json-forbidden")]
        public IActionResult NonJsonForbidden()
        {
            var htmlContent = "<html><body>Forbidden</body></html>";
            return new ContentResult
            {
                Content = htmlContent,
                ContentType = "text/html; charset=utf-8",
                StatusCode = 403
            };
        }

        [HttpGet("non-json-not-found")]
        public IActionResult NonJsonNotFound()
        {
            var htmlContent = "<html><body>Not Found</body></html>";
            return new ContentResult
            {
                Content = htmlContent,
                ContentType = "text/html; charset=utf-8",
                StatusCode = 404
            };
        }
    }
}
