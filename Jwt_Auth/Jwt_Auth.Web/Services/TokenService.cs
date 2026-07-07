using Blazored.LocalStorage;

namespace Jwt_Auth.Web.Services
{
    public class TokenService
    {
        private readonly ILocalStorageService _localStorage;

        private const string AccessTokenKey = "accessToken";
        private const string RefreshTokenKey = "refreshToken";

        public TokenService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        //Save token 
        public async Task SaveTokensAsync(string accessToken , string refreshToken)
        {
            await _localStorage.SetItemAsync(AccessTokenKey, accessToken);
            await _localStorage.SetItemAsync(RefreshTokenKey, refreshToken);
        }

        //Get Access Token
        public async Task<string?> GetAccessTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>(AccessTokenKey);
        }
        // Get Refresh Token
        public async Task<string?> GetRefreshTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>(RefreshTokenKey);
        }

        //check Login
        public async Task<bool> IsAuthenticatedAsync()
        {
            var token  = await GetAccessTokenAsync();

            return !string.IsNullOrWhiteSpace(token);
        }

        ///Logout 
        public async Task RemoveTokensAsync()
        {
            await _localStorage.RemoveItemAsync(AccessTokenKey);
            await _localStorage.RemoveItemAsync(RefreshTokenKey);
        }
    }
}
