import React, { FC } from 'react';
import useStore from './store/useStore';

export interface SearchBarProps {
  handleRefresh: () => void;
}

export const SearchBar: FC<SearchBarProps> = ({ handleRefresh }) => {
  const address = useStore((state) => state.address);
  const setAddress = useStore((state) => state.setAddress);

  return (
    <div className="flex items-center bg-gray-800 p-4 rounded-lg mb-4">
      <input
        className="flex-grow bg-gray-700 p-2 rounded-lg mr-4"
        value={address}
        onChange={(e) => setAddress(e.target.value)}
        placeholder="Enter an address" />
      <button
        className="bg-blue-500 text-white p-2 rounded-lg"
        onClick={handleRefresh}
      >
        Search
      </button>
    </div>
  );
};
