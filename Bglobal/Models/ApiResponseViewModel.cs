using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bglobal.Models
{
    public class ApiResponseViewModel
    {
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty(PropertyName = "data")]
        public List<TitularViewModel> Data { get; set; }
    }
}
