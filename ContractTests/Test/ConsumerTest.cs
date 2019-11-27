using System;
using System.Collections.Generic;
using System.Text;
using ContractTests.Consumer;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;
using ShowRoomApi.Models;
using ContractTests.Mock;

namespace ContractTests.Test
{
    public class ConsumerTest : IClassFixture<ConsumerPact>
    {
        private IMockProviderService _mockProviderService;
        private string _mockProviderServiceBaseUri;

        public ConsumerTest(ConsumerPact data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderService.ClearInteractions();
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;            
        }

        [Fact]
        public void GetVechicleDetails_VerifyIfReturns()
        {
            string vechicleName = "Benz";
            _mockProviderService
                .Given("Search for a specific details: "+ vechicleName)
                .UponReceiving("a Get Request to retrieve "+ vechicleName +"details")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,                    
                    Path = $"/Microservice/GetSpecificModel/"+vechicleName,
                    Headers = new Dictionary<string, object>
                    {
                        {"Accept","application/json" }
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,                  
                    Headers = new Dictionary<string, object>
                    {
                        {"Content-Type","application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        vechicleId = 1,
                        vechicleName = vechicleName,
                        price = 200000.00
                    }
                });

            var consumer = new MockClient(_mockProviderServiceBaseUri);

            //Act
            var result = consumer.GetSpecificModel(vechicleName);

            //Assert
            Assert.Equal(vechicleName, result.VechicleName);

            _mockProviderService.VerifyInteractions();
        }
    }
}
