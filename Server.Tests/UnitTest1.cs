using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server.Tests
{
    public class UnitTest1
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper output;
        public UnitTest1(ITestOutputHelper output)
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
            this.output = output;
        }

        [Fact]
        public async Task Test1()
        {
           var response = await _client.GetAsync("http://localhost:5000/dumpster");           
            var temp = await response.Content.ReadAsStringAsync();
            output.WriteLine("This is output from {0}", temp);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Dumpster[] dumpsters = JsonSerializer.Deserialize<Dumpster[]>(temp, options);
            foreach (var d in dumpsters)
            {
                output.WriteLine("Fullness:{0} ", d.Fullness);
            }
           
        }
    }
}
