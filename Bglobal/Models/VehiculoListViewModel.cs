using System;
using System.Collections.Generic;
using DAL.Entidades;

namespace Bglobal.Models
{
    public class VehiculoListViewModel
    {
        
        public List<Vehiculo> Vehiculos { get; set; }
        public List<Marca> Marcas { get; set; }
        public List<Titular> Titulares { get; set; }
    }
}
