using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Data.Repos;
using DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bglobal.UnitTests
{
    [TestClass]
    public class VehiculoUnitTests : BasePruebas
    {
        [TestMethod]
        public async Task Should_AddPruebaToDB_ReturnsTrue()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConfigureContext(dbName);

            var vehiculo = new Vehiculo
            {
                CantPuertas = 3,
                Modelo = "T",
                Patente = "TREWQT"
            };

            var marca = new Marca
            {
                NombreMarca = "Kia"
            };

            await ConfigureMarcaInterface(context).AddMarcaAsync(marca);

            await context.SaveChangesAsync();

            var titular = new Titular
            {
                Apellido = "Martinez",
                Nombre = "Ariel"
            };

            var email = new Email
            {
                DireccionEmail = ""
            };

            await ConfigureVehiculoInterface(context).AddVehiculoCumpletoAsync(vehiculo, marca,
                titular, email);

            await context.SaveChangesAsync();

            var result = await ConfigureVehiculoInterface(context).CheckifVehiculoExistAsync(vehiculo);


            var result2 = await ConfigureVehiculoInterface(context).GetVehiculosAsync();

            Assert.AreEqual(true, result);
            Assert.AreEqual(1, result2.Count);
            Assert.AreEqual(true, result2.FirstOrDefault().TitularesVehiculos.Any(t => t.Titular.Apellido.Equals("Martinez")));


        }
    }
}
