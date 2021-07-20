using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entidades
{
    public class Marca
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la marca es requerido.")]
        [Column(TypeName = "nvarchar(200)")]
        public string NombreMarca { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
