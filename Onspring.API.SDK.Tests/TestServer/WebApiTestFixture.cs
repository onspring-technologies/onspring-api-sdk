using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace Onspring.API.SDK.Tests.TestServer
{
    /// <summary>
    /// Fixture used to extend the <see cref="WebApplicationFactory{TEntryPoint}"/>.
    /// </summary>
    /// <remarks>
    /// Typical use of the <see cref="WebApplicationFactory{TEntryPoint}"/> includes an application
    /// project with its own startup and program files. Since we're in a unit test project, we
    /// don't have a program file, so we need to override how the builder is created to account for that.
    /// </remarks>
    [ExcludeFromCodeCoverage]
    internal class WebApiTestFixture : WebApplicationFactory<Startup>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiTestFixture"/>.
        /// </summary>
        public WebApiTestFixture()
        {
        }

        /// <summary>
        /// Creates the host builder manually.
        /// </summary>
        /// <returns></returns>
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(builder =>
            {
                builder.UseStartup<Startup>();
            });
        }
    }
}
