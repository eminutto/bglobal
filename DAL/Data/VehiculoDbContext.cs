using System;
using DAL.Entidades;
using Microsoft.EntityFrameworkCore;
namespace DAL.Data
{
    public class VehiculoDbContext : DbContext
    {
        public VehiculoDbContext(DbContextOptions<VehiculoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Titular> Titulares { get; set; }
        public DbSet<Titular_Vehiculo> TitularesVehiculos { get; set; }
        public DbSet<Email> Emails { get; set; }
    }
}
