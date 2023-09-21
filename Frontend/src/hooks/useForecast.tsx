import axios from 'axios';
import useStore from '../store/useStore';

function useForecast() {
    const { forecast, setForecast, loading, setLoading, error, setError } = useStore();

    const fetchForecast = async (address:string) => {
        setLoading(true);
        try {
            const response = await axios.get(`http://localhost:5036/WeatherForecast/lastdays?Address=${address}`);
            setForecast(response.data.dayForecasts);
            setError(null);
        } catch (err) {
            setError(err);
        } finally {
            setLoading(false);
        }
    };

    return { forecast, loading, error, fetchForecast };
}

export default useForecast;
