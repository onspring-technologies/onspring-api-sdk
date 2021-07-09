using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Onspring.API.SDK.Tests.Infrastructure.Helpers
{
    [ExcludeFromCodeCoverage]
    internal static class TestHelper
    {
        public static string GetDefaultImagePath()
        {
            var files = Directory.GetFiles(AppContext.BaseDirectory, "Onspring-Logo.png", SearchOption.AllDirectories);

            var filePath = files.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new InvalidOperationException("No image found.");
            }
            return filePath;
        }
    }
}
