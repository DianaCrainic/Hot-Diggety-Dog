using Application.Features.OrderFeatures.Services;
using Application.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationDI
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IOrdersService), typeof(OrdersService));
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
