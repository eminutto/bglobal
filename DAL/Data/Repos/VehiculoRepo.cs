using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data.Interfaces;
using DAL.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Repos
{
    public class VehiculoRepo : IVehiculo
    {
        private readonly VehiculoDbContext _ctx;
        private readonly ITitular _titular;
        private readonly IMarca _marca;
        private readonly IEmail _email;

        public VehiculoRepo(VehiculoDbContext ctx, ITitular tit, IMarca mar, IEmail em)
        {
            _ctx = ctx;
            _titular = tit;
            _marca = mar;
            _email = em;
        }

        public async Task AddVehiculoAsync(Vehiculo v, Marca m)
        {
            var marca = await _marca.GetMarcaAsync(m.NombreMarca);
            v.MarcaId = marca.Id;
            await _ctx.Vehiculos.AddAsync(v);
        }

        public async Task<bool> CheckifVehiculoExistAsync(Vehiculo v)
        {

            if (await _ctx.Vehiculos.AnyAsync(l => l.Patente.ToLower().Equals(v.Patente.ToLower())
            ) == true)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Vehiculo>> GetVehiculosAsync()
        {
            var vehiculos = _ctx.Vehiculos
                .Include(t => t.Marca)
                .Include(v => v.TitularesVehiculos)
                    .ThenInclude(p => p.Titular)
                    .ThenInclude(m => m.Emails)
                .AsQueryable();


            return await vehiculos.ToListAsync();
        }

        public async Task<Vehiculo> GetVehiculoAsync(int id)
        {
            return await _ctx.Vehiculos.FindAsync(id);
        }

        public async Task<bool> AddVehiculoCumpletoAsync(Vehiculo v, Marca m, Titular t, Email e)
        {
            if (await _titular.CheckTitularExistAsync(t) == false)
            {
                await _titular.AddTitularVehiculoAsync(t);
                await _ctx.SaveChangesAsync();
            }

            if (!string.IsNullOrEmpty(e.DireccionEmail))
            {
                if (await _email.CheckifEmailExist(e) == false)
                {
                    await _email.AddEmailAsync(e, t);
                    await _ctx.SaveChangesAsync();
                }
            }

            
            if (await _marca.CheckifMarcaExistAsync(m) == false)
            {
                await _marca.AddMarcaAsync(m);
                await _ctx.SaveChangesAsync();
            }
            

            if (await CheckifVehiculoExistAsync(v) == false)
            {
                await AddVehiculoAsync(v, m);
                await _ctx.SaveChangesAsync();
            }



            var titularVehiculo = await _titular.GetTitularVehiculoAsync(t.Nombre, t.Apellido);

            var tv = new Titular_Vehiculo()
            {
                TitularId = titularVehiculo.Id,
                VehiculoId = v.Id,
            };

            await _ctx.TitularesVehiculos.AddAsync(tv);

            return true;

        }
    }
}
