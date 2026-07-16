using System.Globalization;

namespace AtmoSync.AI;

public sealed class PredictionResult
{
    public double Temperature { get; init; }
    public double Humidity { get; init; }
    public double PredictedAirQualityIndex { get; init; }
    public string RiskLevel { get; init; } = string.Empty;
}

public interface IAirQualityPredictor
{
    PredictionResult Predict(double temperature, double humidity);
}

public sealed class DemoAirQualityPredictor : IAirQualityPredictor
{
    public PredictionResult Predict(double temperature, double humidity)
    {
        var normalizedTemp = temperature;
        var normalizedHumidity = humidity;

        var predicted = (0.95 * normalizedTemp) + (0.85 * normalizedHumidity) + 12.0;

        var riskLevel = predicted >= 85
            ? "High risk"
            : predicted >= 65
                ? "Moderate risk"
                : "Low risk";

        return new PredictionResult
        {
            Temperature = temperature,
            Humidity = humidity,
            PredictedAirQualityIndex = Math.Round(predicted, 2),
            RiskLevel = riskLevel
        };
    }
}
