using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace APIApp.Client
{
    public static class AppServiceExtensions
    {
        public static AxerrioAPIAOLAPIApp Create(this IAppServiceClient client)
        {
            return new AxerrioAPIAOLAPIApp(client.CreateHandler());
        }

        public static AxerrioAPIAOLAPIApp Create(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new AxerrioAPIAOLAPIApp(client.CreateHandler(handlers));
        }

        public static AxerrioAPIAOLAPIApp Create(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new AxerrioAPIAOLAPIApp(uri, client.CreateHandler(handlers));
        }

        public static AxerrioAPIAOLAPIApp Create(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new AxerrioAPIAOLAPIApp(rootHandler, client.CreateHandler(handlers));
        }
    }
}
