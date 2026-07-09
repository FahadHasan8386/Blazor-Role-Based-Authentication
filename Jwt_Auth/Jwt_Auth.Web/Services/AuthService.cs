using Jwt_Auth.Shared.Models;
using Jwt_Auth.Web.Authentication;
using System.Net.Http.Json;

namespace Jwt_Auth.Web.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly TokenService _tokenService;
        private readonly CustomAuthenticationStateProvider _authProvider;

        public AuthService(
            HttpClient http,
            TokenService tokenService,
            CustomAuthenticationStateProvider authProvider)
        {
            _http = http;
            _tokenService = tokenService;
            _authProvider = authProvider;
        }
        public async Task<bool> Register(UserDto user)
        {
            var response = await _http.PostAsJsonAsync("api/Auth/register",user);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Login(UserDto dto)
        {
            var result = await _http.PostAsJsonAsync("api/Auth/login", dto);

            if(!result.IsSuccessStatusCode)
            {
                return false;
            }

            var token = await result.Content.ReadFromJsonAsync<TokenResponseDto>();

            if(token == null)
            {
                return false;
            }

            await _tokenService.SaveTokensAsync(token.AccessToken, token.RefreshToken);

            await _authProvider.NotifyUserAuthentication(token.AccessToken);

            return true;
        }

        public async Task Logout()
        {
            var accessToken = await _tokenService.GetAccessTokenAsync();

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                _http.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        accessToken);

                await _http.PostAsync("api/Auth/logout", null);
            }

            await _tokenService.RemoveTokensAsync();

            _authProvider.NotifyUserLogout();
        }
    }
}
