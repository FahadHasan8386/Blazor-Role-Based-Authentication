
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PredictionController : ControllerBase
{
    private readonly IAirQualityPredictor _predictor;

    public PredictionController(IAirQualityPredictor predictor)
    {
        _predictor = predictor;
    }

    [HttpPost]
    public IActionResult Predict([FromBody] PredictionRequest request)
    {
        if (request.Temperature < -50 || request.Temperature > 100 || request.Humidity < 0 || request.Humidity > 100)
        {
            return BadRequest("Temperature must be between -50 and 100 and humidity between 0 and 100.");
        }

        var result = _predictor.Predict(request.Temperature, request.Humidity);
        return Ok(result);
    }
}

public sealed class PredictionRequest
{
    public double Temperature { get; set; }
    public double Humidity { get; set; }
}
