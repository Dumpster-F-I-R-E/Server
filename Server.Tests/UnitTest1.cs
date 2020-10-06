using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Server.Tests
{
    public class UnitTest1
    {
        private readonly HttpClient _client;

        public UnitTest1()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();

        }

        [Fact]
        public async Task Test1()
        {
            var response = await _client.GetAsync("http://localhost:5000/dumpster");
            Console.WriteLine(response.ToString());
        }
    }
}
