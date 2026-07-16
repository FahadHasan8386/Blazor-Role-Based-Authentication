import joblib
from pathlib import Path

import pandas as pd
from sklearn.linear_model import LinearRegression

ROOT = Path(__file__).resolve().parents[1]
DATASET_PATH = ROOT / "Dataset" / "demo_air_quality.csv"
MODEL_PATH = ROOT / "Models" / "temperature_humidity_model.joblib"
MODEL_PATH.parent.mkdir(parents=True, exist_ok=True)


def train_and_save_model():
    data = pd.read_csv(DATASET_PATH)
    features = data[["temperature", "humidity"]]
    target = data["air_quality_index"]

    model = LinearRegression()
    model.fit(features, target)

    payload = {
        "model": model,
        "feature_columns": ["temperature", "humidity"],
    }
    joblib.dump(payload, MODEL_PATH)
    print(f"Model trained and saved to {MODEL_PATH}")


if __name__ == "__main__":
    train_and_save_model()
