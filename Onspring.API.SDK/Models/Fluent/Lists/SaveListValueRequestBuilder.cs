using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class SaveListValueRequestBuilder :
        ISaveListValueRequestBuilder,
        ISaveListValueInListRequestBuilder,
        ISaveListValueWithIdRequestBuilder,
        ISaveListValueWithNameRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int ListId { get; private set; }
        public Guid? Id { get; private set; }
        public string Name { get; private set; }
        public decimal? NumericValue { get; private set; }
        public string Color { get; private set; }

        internal SaveListValueRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public ISaveListValueInListRequestBuilder InList(int listId)
        {
            ListId = listId;
            return this;
        }

        public ISaveListValueWithIdRequestBuilder WithId(Guid? id)
        {
            Id = id;
            return this;
        }

        public ISaveListValueWithNameRequestBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public ISaveListValueWithNameRequestBuilder WithColor(string color)
        {
            Color = color;
            return this;
        }

        public ISaveListValueWithNameRequestBuilder WithNumericValue(decimal value)
        {
            NumericValue = value;
            return this;
        }

        public async Task<ApiResponse<SaveListItemResponse>> SendAsync()
        {
            return await _client.SaveListItemAsync(
                new SaveListItemRequest
                {
                    ListId = ListId,
                    Id = Id,
                    Name = Name,
                    NumericValue = NumericValue,
                    Color = Color,
                }
            );
        }
    }
}