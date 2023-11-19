import useSWR from 'swr';
import { fetcher } from '@core/http';
import { Response as AddressesResponse } from './List/dtos';
import { Address } from './Details/dtos';

export const urlBase = 'https://rickandmortyapi.com/api/location';

export function useAddresses() {
    const { data, error, isLoading, mutate } = useSWR<AddressesResponse>(urlBase, fetcher)

    return {
        data,
        isLoading,
        hasError: error,
        mutate
    }
}

export function useAddress(id: string) {
    const { data, error, isLoading } = useSWR<Address>(`${urlBase}/${id}`, fetcher)

    return {
        data,
        isLoading,
        hasError: error
    }
}