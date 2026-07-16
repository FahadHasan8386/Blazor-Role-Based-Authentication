using System.Net.Http.Json;

namespace Jwt_Auth.Web.Services;

public sealed class PredictionService
{
    private readonly HttpClient _http;

    public PredictionService(HttpClient http)
    {
        _http = http;
    }

    public async Task<PredictionResponse?> PredictAsync(double temperature, double humidity)
    {
        var response = await _http.PostAsJsonAsync("api/Prediction", new
        {
            temperature,
            humidity
        });

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<PredictionResponse>();
    }
}

public sealed class PredictionResponse
{
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double PredictedAirQualityIndex { get; set; }
    public string RiskLevel { get; set; } = string.Empty;
}
