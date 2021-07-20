using System;
using Newtonsoft.Json;

namespace Bglobal.Models
{
    public class TitularViewModel
    {
        public TitularViewModel()
        {
        }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }
    }
}
