using System;
using System.Collections.Generic;
using System.Text;
using ContractTests.Consumer;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;
using ShowRoomApi.Models;
using ContractTests.Mock;
using PactNet;
using PactNet.Infrastructure.Outputters;
using Xunit.Abstractions;
using ContractTests.CustomOutput;

namespace ContractTests.Test
{
    public class ProviderTest  
    {
        private readonly ITestOutputHelper outPut;

        public ProviderTest(ITestOutputHelper output)
        {
            outPut = output;
        }

        [Fact]
        public void EnsureProviderApiHonorsPactWithConsumer()
        {
            var config = new PactVerifierConfig()
            {
                Verbose = true,
                PublishVerificationResults = true,
                ProviderVersion = "1.0.0",
                Outputters = new List<IOutput>
                {
                    new CustomOutputer(outPut)       
                }
            };
            new PactVerifier(config)
                .ServiceProvider("MicroServiceShowRoomApi", "http://localhost:8001")
                .HonoursPactWith("ConsumerShowRoomApi")
                .PactUri(@"C:\Users\sekar.nagaraj\source\repos\ShowRoomApi\ContractTests\pacts\consumershowroomapi-microserviceshowroomapi.json")
                .Verify();
        }

    }
}
