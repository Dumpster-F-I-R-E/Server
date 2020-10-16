using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit.Abstractions;
using Xunit;
using Xunit.Abstractions;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Server.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Server.Tests
{
    public partial class BaseTest
    {
        protected HttpClient _client;
        protected WebApplicationFactory<Startup> appFactory;
        protected ITestOutputHelper output;
        public BaseTest(ITestOutputHelper output)
        {
            appFactory = new WebApplicationFactory<Startup>();           
            _client = appFactory.CreateClient();
            this.output = output;
        }


        //[Fact]
        //public async Task Test1()
        //{
        //    var response = await _client.GetAsync("http://localhost:5000/dumpster");
        //    var temp = await response.Content.ReadAsStringAsync();
        //    output.WriteLine("This is output from {0}", temp);
        //    var options = new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true,
        //    };
        //    Dumpster[] dumpsters = JsonSerializer.Deserialize<Dumpster[]>(temp, options);
        //    foreach (var d in dumpsters)
        //    {
        //        output.WriteLine("Fullness:{0} ", d.Fullness);
        //    }

        //}
    }
}
