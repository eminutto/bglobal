using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bglobal.Models;
using DAL.Data;
using DAL.Data.Interfaces;
using DAL.Entidades;
using ApiConsumer;

namespace Bglobal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VehiculoDbContext _ctx;
        private readonly IVehiculo _vehiculo;
        private readonly ITitular _titular;
        private readonly IMarca _marca;
        private readonly IEmail _email;

        public HomeController(ILogger<HomeController> logger, VehiculoDbContext ctx,
            IVehiculo veh, ITitular tit, IMarca marc, IEmail em)
        {
            _logger = logger;
            _ctx = ctx;
            _vehiculo = veh;
            _titular = tit;
            _marca = marc;
            _email = em;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new VehiculoListViewModel()
            {
                Vehiculos = await _vehiculo.GetVehiculosAsync()
            };
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var apiResponse = ApiRest.MakeCall(12);
            var marcas = await _marca.GetMarcasAsync();

            var model = new CargaVehiculoViewModel()
            {
                Titulares = apiResponse.Data,
                Marcas = marcas
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CargaVehiculoViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                var apiResponse = ApiRest.MakeCall(12);
                var marcas = await _marca.GetMarcasAsync();

                model.Titulares = apiResponse.Data;
                model.Marcas = marcas;

                return View(model);
            }

            var titular = new Titular()
            {
                Nombre = model.NombreCompleto.Split(" ").ElementAt(0),
                Apellido = model.NombreCompleto.Split(" ").ElementAt(1),

            };

            await _vehiculo.AddVehiculoCumpletoAsync(model.Vehiculo, model.Marca, titular, model.Email);

            await _ctx.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        #region Constantes
        [HttpGet]
        public async Task<string> Constantes()
        {
            var marcasList = new List<Marca>()
            {
                new Marca
                {
                    NombreMarca = "Audi"
                },
                new Marca
                {
                    NombreMarca = "Peugeot"
                },
                new Marca
                {
                    NombreMarca = "Ford"
                },
                new Marca
                {
                    NombreMarca = "Chevrolet"
                },
                new Marca
                {
                    NombreMarca = "Smart"
                }

            };

            foreach (var marca in marcasList)
            {
                await _marca.AddMarcaAsync(marca);
            };

            await _ctx.SaveChangesAsync();

            var titularesList = new List<Titular>()
            {
                new Titular
                {
                    Apellido = "Marquez",
                    Nombre = "Esteban"
                },
                new Titular
                {
                    Apellido = "Gaitan",
                    Nombre = "Vanesa"
                },
                new Titular
                {
                    Apellido = "Gomez",
                    Nombre = "Sebastian"
                },
                new Titular
                {
                    Apellido = "Popolo",
                    Nombre = "Marcos"
                },
                new Titular
                {
                    Apellido = "Martinez",
                    Nombre = "Marina"
                }

            };

            foreach (var titular in titularesList)
            {
                await _titular.AddTitularVehiculoAsync(titular);
            }

            await _ctx.SaveChangesAsync();


            return "Ok";
        }

        #endregion


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
