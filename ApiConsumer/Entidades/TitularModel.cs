using System;
using DAL.Entidades;
using Newtonsoft.Json;

namespace ApiConsumer.Entidades
{
    public class TitularModel : Titular
    {
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellido;
            }

        }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        
        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }
    }
}
