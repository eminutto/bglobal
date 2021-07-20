using System;
using System.Threading.Tasks;
using DAL.Entidades;

namespace DAL.Data.Interfaces
{
    public interface IEmail
    {
        public Task<bool> AddEmailAsync(Email email, Titular titular);
        public Task<bool> CheckifEmailExist(Email e);
    }
}
