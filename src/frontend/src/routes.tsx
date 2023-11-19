import {
  Route,
  Routes,
} from "react-router-dom";

import { Addresses, Address, UpsertAddress } from '@pages/Addresses/Index';
import { Home } from "@pages/Home/Index";

export function RouterComponent() {
  return (
    <Routes>
      <Route path="/" >
        <Route index element={<Home />} />
        <Route path='addresses' >
          <Route index element={<Addresses />} />
          <Route path=':id' >
            <Route index element={<Address />} />
            <Route path="update" element={<UpsertAddress />} />
          </Route>
        </Route>
      </Route>
    </Routes>
  )
}
