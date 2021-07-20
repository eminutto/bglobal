using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entidades
{
    public class Titular_Vehiculo
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Vehiculo")]
        public int VehiculoId { get; set; }
        [ForeignKey("Titular")]
        public int TitularId { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }
        public virtual Titular Titular { get; set; }
    }
}
