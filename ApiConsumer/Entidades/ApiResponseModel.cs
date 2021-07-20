using System;
using System.Collections.Generic;
using DAL.Entidades;
using Newtonsoft.Json;

namespace ApiConsumer.Entidades
{
    public class ApiResponseModel
    {
        public ApiResponseModel()
        {
        }

        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty(PropertyName = "data")]
        public List<TitularModel> Data { get; set; }
    }
}
