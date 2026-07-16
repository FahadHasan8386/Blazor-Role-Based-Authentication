import json
from pathlib import Path

import joblib
import pandas as pd

ROOT = Path(__file__).resolve().parents[1]
MODEL_PATH = ROOT / "Models" / "temperature_humidity_model.joblib"


def load_model():
    if not MODEL_PATH.exists():
        raise FileNotFoundError(
            f"Model not found at {MODEL_PATH}. Train it first with Training/train_model.py"
        )
    return joblib.load(MODEL_PATH)


def predict(temperature: float, humidity: float):
    payload = load_model()
    model = payload["model"]
    feature_columns = payload["feature_columns"]

    frame = pd.DataFrame([[temperature, humidity]], columns=feature_columns)
    prediction = model.predict(frame)[0]

    risk_level = "High risk" if prediction >= 85 else "Moderate risk" if prediction >= 65 else "Low risk"

    return {
        "temperature": temperature,
        "humidity": humidity,
        "predicted_air_quality_index": round(float(prediction), 2),
        "risk_level": risk_level,
    }


def predict_from_json(payload: str):
    data = json.loads(payload)
    return predict(data["temperature"], data["humidity"])


if __name__ == "__main__":
    import argparse

    parser = argparse.ArgumentParser(description="Predict air-quality index from temperature and humidity")
    parser.add_argument("--temperature", type=float, required=True)
    parser.add_argument("--humidity", type=float, required=True)
    args = parser.parse_args()

    print(json.dumps(predict(args.temperature, args.humidity), indent=2))
