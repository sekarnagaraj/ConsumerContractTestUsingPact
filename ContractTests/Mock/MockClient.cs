using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using ShowRoomApi.Models;
using Newtonsoft.Json;

namespace ContractTests.Mock
{
    //Real HttpClient Guys
    class MockClient
    {
        private readonly HttpClient _client;
        public MockClient(string baseUri = null)
        {
            _client = new HttpClient
                {
                    BaseAddress = new Uri(baseUri ?? "https://localhost:8001")
                };
        }

        public MarutiShowRoomModels GetSpecificModel(string name)
        {
            string reasonPhrase;

            var request = new HttpRequestMessage(HttpMethod.Get, $"/Microservice/GetSpecificModel/"+name);
            request.Headers.Add("Accept", "application/json");
            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;
            reasonPhrase = response.Result.ReasonPhrase;

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !string.IsNullOrEmpty(content) ? 
                    JsonConvert.DeserializeObject<MarutiShowRoomModels>(content) 
                    : null;
            }
            throw new Exception(reasonPhrase);
        }
    }
}
