using System;
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
    public class VehiculoUnitTests
    {
        [TestMethod]
        public async Task Should_AddTitularToDB_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<VehiculoDbContext>()
            .UseInMemoryDatabase(databaseName: "VehiculosBDD")
            .Options;

            var vehiculo = new Vehiculo() { CantPuertas = 4, Patente = "QQAAQ" };

            // Use a clean instance of the context to run the test
            using (var context = new VehiculoDbContext(options))
            {
                var mockRepo = new Mock<VehiculoRepo>(context);

                //var mockRepo = new VehiculoRepo(context);

                var mockDb = new VehiculoDbContext(options);

                var test = mockRepo.Setup(x => x.AddVehiculoAsync(vehiculo, new Marca { NombreMarca = "Smart" }));

                var result = await context.SaveChangesAsync();

                Assert.AreEqual(result, 1);
            }
        }
    }
}
