using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IConnectionRequestBuilder
    {
        Task<bool> SendAsync();
    }
}