using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        private const string MessageTemplate = "HTTP Request {RequestPath}{RequestHeaders}";
                                               
        
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.ContentType != "application/grpc")
            {
                var builder = new StringBuilder(Environment.NewLine);
                foreach (var (key, value) in context.Request.Headers)
                {
                    builder.AppendLine($"{key}:{value}");
                }
            
                _logger.LogInformation(MessageTemplate, context.Request.Path, builder.ToString());
            }
            
            await _next(context);
        }
    }
}