using System.Threading.Tasks;
using DAL.Data;
using DAL.Data.Repos;
using DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bglobal.UnitTests
{
    [TestClass]
    public class TitularTests
    {
        
        [TestMethod]
        public async Task Should_AddTitularToDB_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<VehiculoDbContext>()
            .UseInMemoryDatabase(databaseName: "VehiculosBDD")
            .Options;

            var titular = new Titular() { Apellido = "Jimenez", Nombre = "Jorge" };

            // Use a clean instance of the context to run the test
            using (var context = new VehiculoDbContext(options))
            {
                var mockRepo = new TitularVehiculoRepo(context);

                await mockRepo.AddTitularVehiculoAsync(titular);

                var result = await context.SaveChangesAsync();

                Assert.AreEqual(result, 1);
            }
        }
    }
}
