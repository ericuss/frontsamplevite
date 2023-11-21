import useSWR from 'swr';

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

export function useAddressess() {

    const update = (id: string, address: UpsertAddressDto) => {
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(address)
        };

        return fetch(`${urlBase}/${id}`, requestOptions);
    };

    const getAddress = (id: string) => useSWR<AddressDto>(`${urlBase}/${id}`);
    const getAddressess = () => useSWR<AddressDto[]>(urlBase);

    return {
        getAddress,
        getAddressess,
        update
    }
}