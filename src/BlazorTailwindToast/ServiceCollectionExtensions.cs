using BlazorTailwindToast.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTailwindToast
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorTailwindToast(this IServiceCollection services)
        {
            return services.AddScoped<IToastService, ToastService>();
        }
    }
}
