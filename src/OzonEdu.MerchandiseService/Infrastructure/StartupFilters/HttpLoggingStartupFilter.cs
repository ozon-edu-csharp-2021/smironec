using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Middlewares;

namespace OzonEdu.MerchandiseService.Infrastructure.StartupFilters
{
    public class HttpLoggingStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseWhen(context => context.Request.ContentType != "application/grpc", configuration =>
                {
                    configuration.UseMiddleware<RequestLoggingMiddleware>();
                    configuration.UseMiddleware<ResponseLoggingMiddleware>();
                });
                
                next(app);
            };
        }
    }
}