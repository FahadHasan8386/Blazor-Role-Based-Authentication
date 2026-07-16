from fastapi import FastAPI
from pydantic import BaseModel

from Prediction.predict import predict

app = FastAPI(title="AtmoSync AI Prediction API")


class PredictionRequest(BaseModel):
    temperature: float
    humidity: float


class PredictionResponse(BaseModel):
    temperature: float
    humidity: float
    predicted_air_quality_index: float
    risk_level: str


@app.get("/")
def health_check():
    return {"status": "ok", "message": "AtmoSync AI prediction service is running"}


@app.post("/predict", response_model=PredictionResponse)
def predict_endpoint(request: PredictionRequest):
    result = predict(request.temperature, request.humidity)
    return result
