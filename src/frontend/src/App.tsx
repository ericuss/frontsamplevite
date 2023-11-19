import { RouterComponent } from './routes';

import './App.css'
import { BrowserRouter } from 'react-router-dom';
import React from 'react';

function App() {

  return (
    <BrowserRouter>
      <div className='container'>
        <React.Suspense fallback={<div>loading ...</div>}>
          <RouterComponent />
          {/* <Outlet /> */}
        </React.Suspense>
      </div>
    </BrowserRouter>
  )
}

export default App
