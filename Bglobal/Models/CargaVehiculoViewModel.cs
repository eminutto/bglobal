using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApiConsumer.Entidades;
using DAL.Entidades;

namespace Bglobal.Models
{
    public class CargaVehiculoViewModel
    {
        public CargaVehiculoViewModel()
        {
        }

        [Required(ErrorMessage = "El nombre completo del titular del vehiculo es requerido.")]
        public string NombreCompleto { get; set; }
        
        public Vehiculo Vehiculo { get; set; }
        public Email Email { get; set; }
        public Marca Marca { get; set; }
        public List<TitularModel> Titulares { get; set; }
        public List<Marca> Marcas { get; set; }



    }
}
