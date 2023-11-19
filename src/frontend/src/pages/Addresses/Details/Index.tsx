import { useAddress } from '@pages/Addresses/hooks';
import { Navigate, useParams } from 'react-router-dom';

import './index.css';
import { FC } from 'react';

export const Address: FC = () => {
  const { id } = useParams();
  
  if (id == null) return <Navigate to="/" replace={true}/>
  const { data, hasError, isLoading } = useAddress(id);

  if (hasError || data == null) return <div>failed to load</div>
  if (isLoading) return <div>loading...</div>

  // render data
  return (<div>
    <h2>Locations</h2>
    <div>
      <label>name</label>
      <span>{data.name}</span>
    </div>
    <div>
      <label>type</label>
      <span>{data.type}</span>
    </div>
    <div>
      <label>dimension</label>
      <span>{data.dimension}</span>
    </div>
  </div>);
}