using System;
using System.Threading.Tasks;
using DAL.Data.Interfaces;
using DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Data.Repos
{
    public class TitularVehiculoRepo : ITitular
    {
        private readonly VehiculoDbContext _ctx;
        private readonly ILogger _logger;

        public TitularVehiculoRepo(VehiculoDbContext ctx)
        {
            _ctx = ctx;
            //_logger = logger;
        }

        public async Task<string> AddTitularVehiculoAsync(Titular titular)
        {
            if (await CheckTitularExistAsync(titular) == false)
            {
                await _ctx.Titulares.AddAsync(titular);

                return "Added";

                //_logger.LogInformation("Added");
            }

            return "Not Added";

            //_logger.LogInformation("Not Added");
        }

        public async Task<bool> CheckTitularExistAsync(Titular titular)
        {
            if (await _ctx.Titulares.AnyAsync(t => t.Apellido.ToLower().Equals(titular.Apellido.ToLower())
            && t.Nombre.ToLower().Equals(titular.Nombre.ToLower())) == true)
            {
                return true;
            }

            return false;
        }

        public async Task<Titular> GetTitularVehiculoAsync(string nombre, string apellido)
        {
            return await _ctx.Titulares.FirstOrDefaultAsync(t => t.Nombre.ToLower().Equals(nombre.ToLower())
                && t.Apellido.ToLower().Equals(apellido.ToLower()));
        }
    }
}
