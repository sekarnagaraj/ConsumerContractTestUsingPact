using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using PactNet.Infrastructure.Outputters;

namespace ContractTests.CustomOutput
{
    public class CustomOutputer : IOutput
    {
        private readonly ITestOutputHelper _output;

        public CustomOutputer(ITestOutputHelper output)
        {
            _output = output;
        }
        void IOutput.WriteLine(string line)
        {
            _output.WriteLine(line);
        }
    }
}
