import { useAddressess } from '@pages/Addresses/hooks';
import { Navigate, useParams } from 'react-router-dom';

import './index.css';
import { FC } from 'react';

export const Address: FC = () => {
  const { id } = useParams();
  
  if (id == null) return <Navigate to="/" replace={true}/>
  const { data, error, isLoading } = useAddressess().getAddress(id);

  if (error || data == null) return <div>failed to load</div>
  if (isLoading) return <div>loading...</div>

  // render data
  return (<div>
    <h2>Locations</h2>
    <div>
      <label>Street</label>
      <span>{data.street}</span>
    </div>
    <div>
      <label>City</label>
      <span>{data.city}</span>
    </div>
  </div>);
}