import { create } from 'zustand'

type State = {
    forecast: any[],
    loading: boolean,
    error: any,
    address: string,
    setForecast: (forecast: any[]) => void,
    setLoading: (loading: boolean) => void,
    setError: (error: any) => void,
    setAddress: (address: string) => void,
};

const useStore = create<State>((set) => ({
    forecast: [],
    loading: false,
    error: null,
    address: '4600 Silver Hill Rd, Washington, DC 20233',
    setForecast: (forecast: any[]) => set({ forecast }),
    setLoading: (loading: boolean) => set({ loading }),
    setError: (error: any) => set({ error }),
    setAddress: (address: string) => set({ address }),
}));

export default useStore;
