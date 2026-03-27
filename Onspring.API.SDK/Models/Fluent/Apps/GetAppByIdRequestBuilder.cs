using Onspring.API.SDK.Interfaces.Fluent;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve an app by ID.
    /// </summary>
    /// <inheritdoc/>
    public class GetAppByIdRequestBuilder : IGetAppByIdRequestBuilder
    {
        private readonly IOnspringClient _client;

        public int AppId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAppByIdRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The client used to send the request.</param>
        /// <param name="appId">The ID of the app to retrieve.</param>
        internal GetAppByIdRequestBuilder(IOnspringClient client, int appId)
        {
            _client = client;
            AppId = appId;
        }

        public async Task<ApiResponse<App>> SendAsync()
        {
            return await _client.GetAppAsync(AppId);
        }
    }
}