import React, { FC } from 'react';

interface Forecast {
  date: string;
  temperature: number;
  temperatureUnit: string;
  shortForecast: string;
  icon: string;
}
export interface ForecastListProps {
  forecasts: Forecast[];
}
export const ForecastList: FC<ForecastListProps> = ({ forecasts }) => {
  return (
    <div className="space-y-4">
      {forecasts.map((forecast) => (
        <div key={forecast.date} className="flex items-center bg-gray-800 p-4 rounded-lg">
          <img className="mr-4" src={forecast.icon} alt="Weather icon" />
          <div>
            <div>
              <strong>Fecha:</strong> {new Date(forecast.date).toLocaleDateString()}
            </div>
            <div>
              <strong>Temperatura:</strong> {forecast.temperature} {forecast.temperatureUnit}
            </div>
            <div>
              <strong>Pronóstico:</strong> {forecast.shortForecast}
            </div>
          </div>
        </div>
      ))}
    </div>
  );
};
