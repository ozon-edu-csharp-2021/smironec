using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        private const string MessageTemplate = "HTTP Response {RequestPath}{ResponseHeaders}";
                                               
        
        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                if (context.Response.ContentType != "application/grpc")
                {
                    var builder = new StringBuilder(Environment.NewLine);
                    foreach (var (key, value) in context.Response.Headers)
                    {
                        builder.AppendLine($"{key}:{value}");
                    }

                    _logger.LogInformation(MessageTemplate, context.Request.Path, builder.ToString());
                }
            }
        }
    }
}