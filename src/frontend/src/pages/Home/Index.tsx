import { FC } from 'react';
import { NavLink } from 'react-router-dom';

import './index.css';

export const Home: FC = () => {
  // render data
  return <div>
    <h2>Home</h2>
    <NavLink to='/addressess'>Addressess</NavLink>
  </div>;
}