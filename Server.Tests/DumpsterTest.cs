using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace Server.Tests
{
    public class DumpsterTest
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper output;
        public DumpsterTest(ITestOutputHelper output)
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
            this.output = output;
        }

        [Fact]
        public async Task Unauthorized_Access()
        {
            var url = "http://localhost:4200/dumpster";
            var response = await _client.GetAsync(url);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
         }
    }
}
