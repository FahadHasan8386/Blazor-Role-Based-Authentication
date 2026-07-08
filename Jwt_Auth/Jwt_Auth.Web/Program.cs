using Blazored.LocalStorage;
using Jwt_Auth.Web;
using Jwt_Auth.Web.Authentication;
using Jwt_Auth.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


// Local Storage
builder.Services.AddBlazoredLocalStorage();


// Authorization
builder.Services.AddAuthorizationCore();


// Authentication State Provider
builder.Services.AddScoped<CustomAuthenticationStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthenticationStateProvider>());


// HttpClient with JWT Handler
builder.Services.AddScoped<ApiAuthenticationHeaderHandler>();

builder.Services.AddScoped(sp =>
{
    var handler =
        sp.GetRequiredService<ApiAuthenticationHeaderHandler>();

    handler.InnerHandler = new HttpClientHandler();

    return new HttpClient(handler)
    {
        BaseAddress = new Uri("https://localhost:7076/")
    };
});


// Services
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<MQ136Service>();


await builder.Build().RunAsync();