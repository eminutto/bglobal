using System;
using ApiConsumer.Entidades;
using Newtonsoft.Json;
using RestSharp;

namespace ApiConsumer
{
    public class ApiRest
    {
        
        public static ApiResponseModel MakeCall(int perPage = 6)
        {
            var client = new RestClient($"https://reqres.in/api/users?per_page={perPage}");

            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            //request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var response = client.Execute<ApiResponseModel>(request);

            var apiResponse = JsonConvert.DeserializeObject<ApiResponseModel>(response.Content);

            return apiResponse;
        }
    }
}
