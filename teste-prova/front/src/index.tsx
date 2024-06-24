import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import Test from './Test';
import ListaUsuarios from './Components/ListaUsuarios';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <App />
    <Test />
    <ListaUsuarios />
  </React.StrictMode>
);