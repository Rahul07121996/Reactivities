using API.DTO;
using Azure.Core;
using System.Net;
using System.Text.Json;

namespace API.GlobalException
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate request;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionHandlingMiddleware(RequestDelegate request, ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment env)
        {
            this.request = request;
            this.logger = logger;
            this.env = env;
        }
      
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await request(context);
            }
            catch (Exception ex)
            { 
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "An unexpected error occurred.");

                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json  = JsonSerializer.Serialize(response, option);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
