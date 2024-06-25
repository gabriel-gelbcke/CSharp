import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import MenuHorizontal from './components/pages/menu-horizontal';
import TarefaListar from './components/pages/tarefa/listar-tarefas';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <MenuHorizontal/>
    <App />
  </React.StrictMode>
);