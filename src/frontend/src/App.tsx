import React from 'react';
import { RouterComponent } from './routes';
import { BrowserRouter } from 'react-router-dom';
import { fetcher } from '@core/http';

import './App.css'
import { SWRConfig } from 'swr';

function App() {

  return (
    <BrowserRouter>
      <div className='container'>
        <React.Suspense fallback={<div>loading ...</div>}>
          <SWRConfig value={{ fetcher }}>
            <RouterComponent />
            {/* <Outlet /> */}
          </SWRConfig>
        </React.Suspense>
      </div>
    </BrowserRouter>
  )
}

export default App
