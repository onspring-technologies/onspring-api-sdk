using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetAppByIdRequestBuilder : IGetAppByIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int AppId { get; private set; }

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