// Middleware/ServiceLoggerMiddleware.cs
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SpaceResearchManagementSystem.Middleware
{
    public class ServiceLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ServiceLoggerMiddleware> _logger;

        public ServiceLoggerMiddleware(RequestDelegate next, ILogger<ServiceLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var services = context.RequestServices.GetService<IServiceProvider>();
            var serviceDescriptors = services.GetType()
                .GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(IServiceCollection<>));

            // Log all registered services
            _logger.LogInformation("Registered Services:");
            foreach (var service in services.GetServices<object>())
            {
                _logger.LogInformation(service.GetType().FullName);
            }

            await _next(context);
        }
    }

    internal interface IServiceCollection<T>
    {
    }
}
