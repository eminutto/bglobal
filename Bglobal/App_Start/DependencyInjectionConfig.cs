using System;
using DAL.Data.Interfaces;
using DAL.Data.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace Bglobal.App_Start
{
    public class DependencyInjectionConfig
    {
        public DependencyInjectionConfig()
        {
        }

        public static void AddScope(IServiceCollection services)
        {
            services.AddTransient<IEmail, EmailRepo>();
            services.AddTransient<IVehiculo, VehiculoRepo>();
            services.AddTransient<IMarca, MarcaRepo>();
            services.AddTransient<ITitular, TitularVehiculoRepo>();
        }
    }
}
