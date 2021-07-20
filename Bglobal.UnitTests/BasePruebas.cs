using System;
using DAL.Data;
using DAL.Data.Interfaces;
using DAL.Data.Repos;
using Microsoft.EntityFrameworkCore;

namespace Bglobal.UnitTests
{
    public class BasePruebas
    {
        protected static VehiculoDbContext ConfigureContext(string dbname)
        {
            var options = new DbContextOptionsBuilder<VehiculoDbContext>()
            .UseInMemoryDatabase(databaseName: dbname)
            .Options;

            var context = new VehiculoDbContext(options);

            return context;
        }

        protected ITitular ConfigureTitularInterface(VehiculoDbContext context)
        {
            var config = new TitularVehiculoRepo(context);

            return config;
        }

        protected IMarca ConfigureMarcaInterface(VehiculoDbContext context)
        {
            var config = new MarcaRepo(context);

            return config;
        }

        protected IEmail ConfigureEmailInterface(VehiculoDbContext context)
        {
            var config = new EmailRepo(context, ConfigureTitularInterface(context));

            return config;
        }

        protected IVehiculo ConfigureVehiculoInterface(VehiculoDbContext context)
        {
            var config = new VehiculoRepo(context, ConfigureTitularInterface(context), ConfigureMarcaInterface(context),
                ConfigureEmailInterface(context));

            return config;
        }
        
    }
}
