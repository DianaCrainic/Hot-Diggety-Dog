using Application.Features.OrderFeatures;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationDI
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IOrdersService), typeof(OrdersService));
        }
    }
}
