using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IDeleteListValueWithIdRequestBuilder
    {
        int ListId { get; }
        Guid Id { get; }
        Task<ApiResponse> SendAsync();
    }
}