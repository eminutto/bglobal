using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entidades
{
    public class Vehiculo
    {
        

        [Key]
        public int Id { get; set; }
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "El modelo es requerido.")]
        [Column(TypeName = "nvarchar(100)")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "La patente del vehiculo es requerida.")]
        [StringLength(8, ErrorMessage = "La patente no podra tener mas de 8 caracteres.")]
        [Column(TypeName = "nvarchar(8)")]
        public string Patente { get; set; }
        [Required(ErrorMessage = "La cantidad de puertas debe ser un valor entre 2 y 5 ")]
        [Range(2, 5)]
        public int CantPuertas { get; set; }


        public virtual Marca Marca { get; set; }
        public virtual ICollection<Titular_Vehiculo> TitularesVehiculos { get; set; }
    }
}
