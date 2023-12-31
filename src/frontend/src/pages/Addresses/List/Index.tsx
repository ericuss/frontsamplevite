import { useAddressess } from '@pages/Addresses/hooks';
import './index.css';
import { useNavigate } from 'react-router-dom';
import { FC } from 'react';

export const Addresses: FC = () => {
  const navigate = useNavigate();
  const { data, error, isLoading } = useAddressess().getAddressess();

  if (isLoading) return <div>loading...</div>
  if (error || data == null) return <div>failed to load</div>

  const handleRedirect = (id: string) => {
    return navigate({
      pathname: `/addresses/${id}`
    });
  }

  const handleRedirectToEdit = (id: string) => {
    return navigate({
      pathname: `/addresses/${id}/update`
    });
  }
  // render data
  return <div>
    <h2>Locations</h2>
    <ul>
      {data.map(x => <li key={x.id}>  <span onClick={() => handleRedirect(x.id)}>{x.city} - {x.street}</span > <button onClick={() => handleRedirectToEdit(x.id)}>edit</button></li>)}
    </ul>
  </div>;
}