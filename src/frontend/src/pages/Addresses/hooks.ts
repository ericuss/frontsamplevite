import useSWR from 'swr';
import { fetcher } from '@core/http';

export const urlBase = '/api/v1/addressess';

export interface AddressDto {
    id: string;
    street: string;
    city: string;
}

export interface UpsertAddressDto {
    street: string;
    city: string;
}

export function useAddresses() {
    const { data, error, isLoading, mutate } = useSWR<AddressDto[]>(urlBase, fetcher)

    return {
        data,
        isLoading,
        hasError: error,
        mutate
    }
}

export function useAddress(id: string) {
    const { data, error, isLoading } = useSWR<AddressDto>(`${urlBase}/${id}`, fetcher);

    const update = (id: string, address: UpsertAddressDto) => {
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(address)
        };

        return fetch(`${urlBase}/${id}`, requestOptions);
    };

    return {
        data,
        isLoading,
        hasError: error,
        update
    }
}