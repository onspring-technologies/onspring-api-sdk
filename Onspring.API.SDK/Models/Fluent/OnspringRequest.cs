namespace Onspring.API.SDK.Models.Fluent
{
  public class OnspringRequest
  {
    private readonly IOnspringClient _client;
    internal OnspringRequest(IOnspringClient client)
    {
      _client = client;
    }
  }
}