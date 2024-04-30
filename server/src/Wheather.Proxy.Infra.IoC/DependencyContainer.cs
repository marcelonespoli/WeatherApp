using Microsoft.Extensions.DependencyInjection;
using Wheather.Proxy.Domain.Interfaces;
using Wheather.Proxy.Infra.Http;

namespace Wheather.Proxy.Infra.IoC
{
    public class DependencyContainer
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IHttpClientService, HttpClientService>();
        }
    }
}