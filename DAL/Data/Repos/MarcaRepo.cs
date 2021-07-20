using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data.Interfaces;
using DAL.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Repos
{
    public class MarcaRepo : IMarca
    {
        private readonly VehiculoDbContext _ctx;

        public MarcaRepo(VehiculoDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Marca> GetMarcaAsync(string marca)
        {
            return await _ctx.Marcas.FirstOrDefaultAsync(t => t.NombreMarca.ToLower().Equals(marca.ToLower()));
        }

        public async Task<bool> AddMarcaAsync(Marca m)
        {
            if (await CheckifMarcaExistAsync(m) == false)
            {
                await _ctx.Marcas.AddAsync(m);

                return true;
            }

            return false;
        }

        public async Task<List<Marca>> GetMarcasAsync()
        {
            return await _ctx.Marcas.ToListAsync();
        }

        public async Task<bool> CheckifMarcaExistAsync(Marca m)
        {
            
            if (await _ctx.Marcas.AnyAsync(o => o.NombreMarca.ToLower().Equals(m.NombreMarca.ToLower()) == true))
            {
                return true;
            }

            return false;
        }
    }
}
