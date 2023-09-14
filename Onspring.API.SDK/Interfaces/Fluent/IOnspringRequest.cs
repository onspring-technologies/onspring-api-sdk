using System;
using System.Threading.Tasks;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IOnspringRequest
    {
        IGetRecordsRequestBuilder ToGetRecords();
    }
}