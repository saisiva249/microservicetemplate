using MediatR;
using Onion.Library.Application.Feat_Product.Services;
using Onion.Library.Application.Mapper;
using Onion.Library.Domain.Feat_Product.Interfaces.Persistence;
using Onion.Library.Domain.Feat_Product.Interfaces.Service;
using Onion.Library.Domain.Interfaces.Persistence;
using Onion.Library.SPI.Persistence;

namespace Onion.Api.Extensions
{
    public static class ConfigServices
    {
        public static IServiceCollection AddDIConfigurations(this IServiceCollection services)
        {
            AddServicesDI(services);
            AddRepositoryDI(services);
            AddMediatRDI(services);
            AddMapperDI(services);
            return services;
        }

        private static IServiceCollection AddMediatRDI(IServiceCollection services)
        {
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            return services;
        }

        private static IServiceCollection AddMapperDI(IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile(new EntityMapper()));
            return services;
        }

        private static IServiceCollection AddServicesDI(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            return services;
        }

        private static IServiceCollection AddRepositoryDI(IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            return services;
        }
    }
}
