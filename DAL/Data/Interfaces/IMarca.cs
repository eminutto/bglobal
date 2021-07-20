using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entidades;

namespace DAL.Data.Interfaces
{
    public interface IMarca
    {
        public Task<bool> AddMarcaAsync(Marca m);
        public Task<Marca> GetMarcaAsync(string marca);
        public Task<List<Marca>> GetMarcasAsync();
        public Task<bool> CheckifMarcaExistAsync(Marca m);
    }
}
