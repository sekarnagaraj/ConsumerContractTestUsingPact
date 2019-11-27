using System;
using System.Collections.Generic;
using System.Text;
using PactNet;
using PactNet.Mocks.MockHttpService;

namespace ContractTests.Consumer
{
    public class ConsumerPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort => 1234;
        public string MockProviderServiceBaseUri => $"http://localhost:{MockServerPort}";
        public ConsumerPact()
        {
            PactConfig config = new PactConfig {
                PactDir = @"",
                LogDir = @""
            };
            PactBuilder = new PactBuilder(config);
            PactBuilder
                .ServiceConsumer("ConsumerShowRoomApi")
                .HasPactWith("MicroServiceShowRoomApi");

            MockProviderService = PactBuilder.MockService(MockServerPort);
            MockProviderService.Start();            
        }
        public void Dispose()
        {
            PactBuilder.Build();
        }
    }
}
