using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Server.Authentication;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Server.Tests
{
   public class AuthenticateTest : BaseTest
   {
      
        public AuthenticateTest(ITestOutputHelper o) : base(o)
        {
           
        }

        [Fact]
        public async Task login_fail()
        {
            var url = "http://localhost:4200/api/authenticate/login";

            dynamic user = new ExpandoObject();
            user.username = "234dfas";
            user.password = "sdfsdfsdf";

            string json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, data);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        }

        [Fact]
        public async Task login_pass()
        {
            var url = "http://localhost:4200/api/authenticate/login";

            dynamic user = new ExpandoObject();
            user.username = "user";
            user.password = "Password@123";

            string json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, data);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task login_token()
        {
            var url = "http://localhost:4200/api/authenticate/login";

            dynamic user = new ExpandoObject();
            user.username = "user";
            user.password = "Password@123";

            string json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, data);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var temp = await response.Content.ReadAsStringAsync();
            var expConverter = new ExpandoObjectConverter();
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(temp, expConverter);
            Assert.False(string.IsNullOrEmpty(obj.token));
         
        }

        [Fact]
        public async Task register()
        {
            var url = "http://localhost:4200/api/authenticate/register";

           
            using (var scope = appFactory.Services.CreateScope())
            {
                //Resolve ASP .NET Core Identity with DI help
                var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));
                dynamic user = new ExpandoObject();
                user.username = "user122";
                user.password = "Password@123";
                user.email = "sdfs@gmail.com";

                var account = await userManager.FindByNameAsync(user.username);
                if (account != null)
                {
                    await userManager.DeleteAsync(account);
                }

                string json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(url, data);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                account = await userManager.FindByNameAsync(user.username);
                Assert.NotNull(account);
                // do you things here
            }
            
           
            
        }


    }
}
