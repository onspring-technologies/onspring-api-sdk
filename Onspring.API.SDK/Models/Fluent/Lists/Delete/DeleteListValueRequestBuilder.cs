using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class DeleteListValueRequestBuilder :
        IDeleteListValueRequestBuilder,
        IDeleteListValueInListRequestBuilder,
        IDeleteListValueWithIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int ListId { get; private set; }
        public Guid Id { get; private set; }


        internal DeleteListValueRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IDeleteListValueInListRequestBuilder InList(int listId)
        {
            ListId = listId;
            return this;
        }

        public IDeleteListValueWithIdRequestBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public async Task<ApiResponse> SendAsync()
        {
            return await _client.DeleteListItemAsync(ListId, Id);
        }
    }
}