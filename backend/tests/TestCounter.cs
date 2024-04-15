using Microsoft.AspNetCore.Mvc;
using Xunit;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using Moq;
using Company.Function;

namespace tests
{
    public class TestCounter
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async Task Http_trigger_should_return_known_string()
        {
            // Setup the Counter and Request
            var counter = new Company.Function.Counter { Id = "1", Count = 2 };

            // Create an HttpRequest instance for the test
            var request = TestFactory.CreateHttpRequest();

            // Create a mock for IAsyncCollector<Counter>
            var mockCollector = new Mock<IAsyncCollector<Counter>>();

            // Call the function
            var response = await Company.Function.GetResumeCounter.Run(request, counter, mockCollector.Object, logger);
            
            // Deserialize the response content to access the updated counter
            var content = await response.Content.ReadAsStringAsync();
            var updatedCounter = JsonConvert.DeserializeObject<Company.Function.Counter>(content);

            // Assert the incremented value
            Assert.Equal(3, updatedCounter.Count);
        }

    }
}