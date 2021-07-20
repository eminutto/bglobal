using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DAL.Entidades
{
    public class Titular
    {
        public Titular()
        {
        }

        [Key]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        [Column(TypeName = "nvarchar(200)")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        [Column(TypeName = "nvarchar(200)")]
        public string Apellido { get; set; }

        public virtual ICollection<Titular_Vehiculo> TitularesVehiculos { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
    }
}
