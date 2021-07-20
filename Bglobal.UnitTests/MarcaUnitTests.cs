using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bglobal.UnitTests
{
    [TestClass]
    public class MarcaUnitTests : BasePruebas
    {
        [TestMethod]
        public async Task Should_AddPruebaToDB_ReturnsTrue()
        {
            var dbName = Guid.NewGuid().ToString();
            var context = ConfigureContext(dbName);

            await ConfigureMarcaInterface(context).AddMarcaAsync(new Marca
            {
                NombreMarca = "Kia"
            });

            await context.SaveChangesAsync();

            var result = await ConfigureMarcaInterface(context).CheckifMarcaExistAsync(new Marca { NombreMarca = "Kia"});
            var result2 = await ConfigureMarcaInterface(context).GetMarcasAsync();

            Assert.AreEqual(true, result);
            Assert.AreEqual(1, result2.Count);
            Assert.AreEqual("Kia", result2.FirstOrDefault().NombreMarca);


        }
    }
}
