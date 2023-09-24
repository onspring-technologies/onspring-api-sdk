using Onspring.API.SDK.Interfaces.Fluent;
using System;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to delete a list value.
    /// </summary>
    /// <inheritdoc/>
    public class DeleteListValueRequestBuilder :
        IDeleteListValueRequestBuilder,
        IDeleteListValueInListRequestBuilder,
        IDeleteListValueWithIdRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int ListId { get; private set; }
        public Guid Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteListValueRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
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