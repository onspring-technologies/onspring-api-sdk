using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface ISaveListValueWithNameRequestBuilder
    {
        int ListId { get; }
        Guid? Id { get; }
        string Name { get; }
        ISaveListValueWithNameRequestBuilder WithColor(string color);
        ISaveListValueWithNameRequestBuilder WithNumericValue(decimal value);
        Task<ApiResponse<SaveListItemResponse>> SendAsync();
    }
}