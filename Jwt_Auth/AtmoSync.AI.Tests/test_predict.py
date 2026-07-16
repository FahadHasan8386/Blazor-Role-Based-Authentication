import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "AtmoSync.AI"))

from Prediction.predict import predict


def test_predict_returns_expected_shape():
    result = predict(25.0, 55.0)
    assert result["temperature"] == 25.0
    assert result["humidity"] == 55.0
    assert "predicted_air_quality_index" in result
    assert "risk_level" in result
