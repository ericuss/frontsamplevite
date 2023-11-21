import {
  Route,
  Routes,
} from "react-router-dom";

import { Addressess, Address, UpsertAddress } from '@pages/Addressess/Index';
import { Home } from "@pages/Home/Index";

export function RouterComponent() {
  return (
    <Routes>
      <Route path="/" >
        <Route index element={<Home />} />
        <Route path='addressess' >
          <Route index element={<Addressess />} />
          <Route path=':id' >
            <Route index element={<Address />} />
            <Route path="update" element={<UpsertAddress />} />
          </Route>
        </Route>
      </Route>
    </Routes>
  )
}
