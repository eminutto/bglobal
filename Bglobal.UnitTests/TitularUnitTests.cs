using System;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Data.Repos;
using DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bglobal.UnitTests
{
    [TestClass]
    public class TitularUnitTests : BasePruebas
    {

        [TestMethod]
        public async Task Should_AddTitularToDB_ReturnsTrue()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConfigureContext(dbName);

            await ConfigureTitularInterface(context).AddTitularVehiculoAsync(new Titular
            {
                Apellido = "Perez",
                Nombre = "Jorge"
            });

            await context.SaveChangesAsync();

            var result = await ConfigureTitularInterface(context).CheckTitularExistAsync(new Titular { Nombre = "Martin", Apellido = "Perez" });
            var result2 = await ConfigureTitularInterface(context).CheckTitularExistAsync(new Titular { Nombre = "Jorge", Apellido = "Perez" });

            Assert.AreEqual(false, result);
            Assert.AreEqual(true, result2);

        }
    }
}
