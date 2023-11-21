import { describe, it, expect, vi } from 'vitest';
import { render } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';

import { Home } from './Index';



describe('Home', () => {

  it('Render Home component', () => {
    /**... */
    const wrapper = render(<MemoryRouter><Home /></MemoryRouter>);

    expect(wrapper).toBeTruthy();

    expect(
      wrapper.container.querySelector('h2')?.textContent,
      "Home text not found"
    ).toBe('Home');
    const anchor = wrapper.container.querySelector('a');
    expect(anchor).toBeTruthy();
    expect(
      anchor?.textContent,
      "Anchor text Addressess not found"
    ).toBe('Addressess');
    expect(
      anchor?.href,
      "Anchor link to /addressess not found"
    ).toBe('http://localhost:3000/addressess');
  });
});