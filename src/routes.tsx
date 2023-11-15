import {
  BrowserRouter as Router,
  Route,
  Routes,
  Link,
} from "react-router-dom";

import { Addresses } from '@pages/Addresses/Index';

export function RouterComponent() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Addresses />} />
      </Routes>
    </Router>
  )
}
