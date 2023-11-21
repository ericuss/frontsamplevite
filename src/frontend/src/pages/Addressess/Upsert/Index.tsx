import { useAddressess, UpsertAddressDto } from '@pages/Addresses/hooks';
import { Navigate, useParams } from 'react-router-dom';
import { useForm, SubmitHandler } from "react-hook-form"
import { FC } from 'react';


import './index.css';

export const UpsertAddress: FC = () => {
  const { id } = useParams();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<UpsertAddressDto>();

  if (id == null) return <Navigate to="/" replace={true} />
  const hook = useAddressess();
  const { data, error, isLoading } = hook.getAddress(id);
  const { mutate } = hook.getAddressess();

  const onSubmit: SubmitHandler<UpsertAddressDto> = (data) => {
    console.log(data);
    const result = hook.update(id, data);
    result
      .then(x => {
        console.log('success', x);
        mutate();
      })
      .catch(x => {
        console.log('error', x);
        mutate();
      })
  }

  if (isLoading) return <div>loading...</div>
  if (error || data == null) return <div>failed to load</div>

  // render data
  return (<div>
    <h2>Locations</h2>

    {/* "handleSubmit" will validate your inputs before invoking "onSubmit" */}
    <form onSubmit={handleSubmit(onSubmit)}>
      <div>
        <label>Street</label>
        {/* register your input into the hook by invoking the "register" function */}
        <input defaultValue={data.street} {...register('street', { required: true })} />
        {errors.street && <span>This field is required</span>}
      </div>
      <div>
        <label>City</label>
        {/* register your input into the hook by invoking the "register" function */}
        <input defaultValue={data.city} {...register('city', { required: true })} />
        {errors.city && <span>This field is required</span>}
      </div>

      <input type="submit" />
    </form>

  </div>);
}