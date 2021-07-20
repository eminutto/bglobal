using System;
using System.Threading.Tasks;
using DAL.Entidades;

namespace DAL.Data.Interfaces
{
    public interface ITitular
    {
        public Task<Titular> GetTitularVehiculoAsync(string nombre, string apellido);
        public Task<bool> AddTitularVehiculoAsync(Titular titular);
        public Task<bool> CheckTitularExistAsync(Titular titular);
    }
}
