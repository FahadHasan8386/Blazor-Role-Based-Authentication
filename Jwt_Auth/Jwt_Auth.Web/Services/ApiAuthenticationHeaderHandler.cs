namespace Jwt_Auth.Web.Services
{
    public class ApiAuthenticationHeaderHandler : DelegatingHandler
    {
        private readonly TokenService _tokenService;

        public ApiAuthenticationHeaderHandler(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var token = await _tokenService.GetAccessTokenAsync();

            if(!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
