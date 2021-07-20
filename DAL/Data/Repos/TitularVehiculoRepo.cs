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

        public TitularVehiculoRepo(VehiculoDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> AddTitularVehiculoAsync(Titular titular)
        {
            if (await CheckTitularExistAsync(titular) == false)
            {
                await _ctx.Titulares.AddAsync(titular);

                return true;
            }

            return false;

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
