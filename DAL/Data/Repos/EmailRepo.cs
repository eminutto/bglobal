using System;
using System.Threading.Tasks;
using DAL.Data.Interfaces;
using DAL.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Repos
{
    public class EmailRepo : IEmail
    {
        private readonly VehiculoDbContext _ctx;
        private readonly ITitular _titular;

        public EmailRepo(VehiculoDbContext ctx, ITitular tit)
        {
            _ctx = ctx;
            _titular = tit;
        }

        public async Task<bool> AddEmailAsync(Email email, Titular t)
        {
            if (await _titular.CheckTitularExistAsync(t) ==  true)
            {
                var titular = await _titular.GetTitularVehiculoAsync(t.Nombre, t.Apellido);

                if (await CheckifEmailExist(email) == false)
                {
                    var e = new Email()
                    {
                        DireccionEmail = email.DireccionEmail,
                        TitularId = titular.Id
                    };

                    await _ctx.Emails.AddAsync(e);

                    return true;
                }

                return false;

            }

            throw new ArgumentException("No existe el titular del email");
        }

        public async Task<bool> CheckifEmailExist(Email e)
        {
            if (await _ctx.Emails.AnyAsync(q => q.DireccionEmail.ToLower().Equals(e.DireccionEmail.ToLower()) == true))
            {
                return true;
            }

            return false;
        }
    }
}
