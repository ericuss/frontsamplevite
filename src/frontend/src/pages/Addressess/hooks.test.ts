import { expect, it, describe, vi, beforeAll, afterAll } from "vitest";
import { renderHook } from '@testing-library/react-hooks'
import { useAddressess } from "./hooks"

describe('useMovies', () => {
    
    const fetchSpy = vi.spyOn(global, 'fetch');
     //Run before all the tests
     beforeAll(() => {
        //Mock the return value of the global fetch function
        const mockResolveValue = { 
            ok: true,
            json: () => new Promise((resolve) => resolve([
                { id: '00001', street: "blablabla 2", city: 'bcn' },
                { id: '00002', street: "calle 2", city: 'bcn' },
                { id: '00003', street: "calle 44", city: 'cornellá' },
            ]))
        };

        fetchSpy.mockReturnValue(mockResolveValue as any);
    });
    
    afterAll(() => {
        fetchSpy.mockRestore();
    });


    it('should fetch addressess', async () => {
        const { result, waitFor } = renderHook(() => useAddressess().getAddressess());
      
        await waitFor(() => {
            expect(result.current.data).toEqual([
                { id: '00001', street: "blablabla 2", city: 'bcn' },
                { id: '00002', street: "calle 2", city: 'bcn' },
                { id: '00003', street: "calle 44", city: 'cornellá' },
            ]);
        }, {
            timeout: 2000
        });
    });
    
});