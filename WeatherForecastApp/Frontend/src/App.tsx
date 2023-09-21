import React, { FC, Suspense } from 'react';
import useForecast from './hooks/useForecast';
import useStore from './store/useStore';
import { ForecastList } from './ForecastList';
import { SearchBar } from './SearchBar';

const App: FC = () => {
  const address = useStore(s => s.address);
  const { forecast, loading, error, fetchForecast } = useForecast();

  const handleRefresh = () => {
    fetchForecast(address);
  };

  return (
    <div className="min-h-screen bg-gray-900 text-white mb-4">
      <header className="bg-gray-800 p-4">
        <h1 className="text-3xl font-bold">Weather App</h1>
      </header>
      <main className="p-4">
        <SearchBar handleRefresh={handleRefresh} />
        {loading ? (
          <div className="loader"></div>
        ) : error ? (
          <p>Error: {error.message}</p>
        ) : (
          <ForecastList forecasts={forecast} />
        )}
      </main>
    </div>
  );
}

export default App;
