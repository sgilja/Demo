using Core.Common.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IFolderService, FolderService>();

            return services;
        }
    }
}
