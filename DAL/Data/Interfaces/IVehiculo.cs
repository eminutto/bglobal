using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entidades;

namespace DAL.Data.Interfaces
{
    public interface IVehiculo
    {
        public Task AddVehiculoAsync(Vehiculo v, Marca m);
        public Task<bool> AddVehiculoCumpletoAsync(Vehiculo v, Marca m, Titular t, Email e);
        public Task<bool> CheckifVehiculoExistAsync(Vehiculo v);
        public Task<Vehiculo> GetVehiculoAsync(int id);
        public Task<List<Vehiculo>> GetVehiculosAsync();
    }
}
