import { NavLink } from 'react-router-dom';

import './index.css';
import { FC } from 'react';

export const Home: FC = () => {
  // render data
  return <div>
    <h2>Home</h2>
    <NavLink to='/addresses'>Addresses</NavLink>
  </div>;
}