using Onspring.API.SDK.Models;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IPagedRequestBuilder
    {
        IGetPagedAppsRequestBuilder OfApps();
    }
}