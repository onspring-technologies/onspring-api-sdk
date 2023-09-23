using System;
using System.IO;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IAddFileWithModifiedDateRequestBuilder
    {
        int RecordId { get; }
        int FieldId { get; }
        string Name { get; }
        Stream FileStream { get; }
        string Type { get; }
        string Notes { get; }
        DateTime? ModifiedDate { get; }
        Task<ApiResponse<CreatedWithIdResponse<int>>> SendAsync();
    }
}