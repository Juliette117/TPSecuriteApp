using System.Text.Json;
using Duende.IdentityModel.Client;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityServer.Services
{
    public class TokenService : ITokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TokenService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }
        public async Task<TokenResponse> GenerateTokenAsync(IdentityUser user, string password)
        {
            var tokenEndpoint = _configuration["IdentityServer:TokenEndpoint"];
            if (string.IsNullOrEmpty(tokenEndpoint))
            {
                throw new InvalidOperationException("TokenEndPoint n'est pas correctement configuré dans appsetting.json");
            }

            var tokenRequest = new Dictionary<string, string>
            {
                { "client_id", _configuration["IdentityServer:ClientId"] },
                { "grant_type", "password" },
                { "username", user.Email },
                { "password", password },
                { "scope", _configuration["IdentityServer:Scopes"] }

            };

            var response = await _httpClient.PostAsync(tokenEndpoint, new FormUrlEncodedContent(tokenRequest));
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            { 
              throw new InvalidOperationException($"Fail {responseContent}");  
            }

            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true

            });

            return tokenResponse;
        }
    }
}
