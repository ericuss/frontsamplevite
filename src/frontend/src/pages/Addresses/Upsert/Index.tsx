import { useAddress, urlBase, useAddresses } from '@pages/Addresses/hooks';
import { Navigate, useParams } from 'react-router-dom';
import { useForm, SubmitHandler } from "react-hook-form"
import { FC } from 'react';


import './index.css';

type Inputs = {
  name: string
  type: string
  dimension: string
}

export const UpsertAddress: FC = () => {
  const { id } = useParams();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Inputs>();

  const onSubmit: SubmitHandler<Inputs> = (data) => {
    console.log(data); 
    mutate();
  }

  if (id == null) return <Navigate to="/" replace={true} />
  const { data, hasError, isLoading } = useAddress(id);
  const { mutate } = useAddresses();

  if (hasError || data == null) return <div>failed to load</div>
  if (isLoading) return <div>loading...</div>

  // render data
  return (<div>
    <h2>Locations</h2>

    {/* "handleSubmit" will validate your inputs before invoking "onSubmit" */}
    <form onSubmit={handleSubmit(onSubmit)}>
      <div>
        <label>name</label>
        {/* register your input into the hook by invoking the "register" function */}
        <input value={data.name} {...register("name", { required: true })} />
        {errors.name && <span>This field is required</span>}
      </div>
      <div>
        <label>type</label>
        {/* register your input into the hook by invoking the "register" function */}
        <input value={data.type} {...register("type", { required: true })} />
        {errors.type && <span>This field is required</span>}
      </div>
      <div>
        <label>dimension</label>
        {/* register your input into the hook by invoking the "register" function */}
        <input value={data.dimension} {...register("dimension", { required: true })} />
        {errors.dimension && <span>This field is required</span>}
      </div>

      <input type="submit" />
    </form>

  </div>);
}