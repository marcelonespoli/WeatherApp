namespace Wheather.Proxy.Domain.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> Get(string uri);        
    }
}
