import React from 'react';
import logo from './logo.svg';
import { BrowserRouter, Route, Routes, Link, Navigate } from 'react-router-dom';
import TarefaListar from './components/pages/tarefa/listar-tarefas';
import TarefaListarNaoConcluidas from './components/pages/tarefa/listar-tarefas-nao-concluidas';
import TarefaListarConcluidas from './components/pages/tarefa/listar-tarefas-concluidas';
import CadastrarTarefa from './components/pages/tarefa/cadastrar-tarefas';
import AlterarTarefa from './components/pages/tarefa/alterar-tarefas';
import MenuHorizontal from './components/pages/menu-horizontal';


function App() {
  return (
    <BrowserRouter>
    <div className="App">
      
      <Routes>
        <Route path="/pages/tarefa/listar" element={<TarefaListar />} />
        <Route path="/pages/tarefa/naoconcluidas" element={<TarefaListarNaoConcluidas />} />
        <Route path="/pages/tarefa/concluidas" element={<TarefaListarConcluidas />} />
        <Route path="/pages/tarefa/cadastrar" element={<CadastrarTarefa />} />
        <Route path="/pages/tarefa/alterar" element={<AlterarTarefa />} />

        <Route path="*" element={<Navigate to="pages/tarefa/listar" replace />} />
      </Routes>
      
    </div>
    </BrowserRouter>
  );
}

export default App;