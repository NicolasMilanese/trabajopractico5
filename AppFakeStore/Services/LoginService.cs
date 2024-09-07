using AppFakeStore.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using AppFakeStore.Utils;
using System.Text;
using System.Net.Http.Json;

namespace AppFakeStore.Services
{
    public class LoginService : ILoginService
    {
        HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public LoginService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(Constants.ApiDataServer)
            };
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetTokenAsync(string username, string password)
        {
            var loginData = new
            {
                username = username,
                password = password
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(loginData),
                Encoding.UTF8, "application/json");

            var response = await client.PostAsync(Constants.LoginEndPoint, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonSerializer.Deserialize<Login>(result, options);
                return loginResponse?.token;
            }

            return null;
        }
    }
}