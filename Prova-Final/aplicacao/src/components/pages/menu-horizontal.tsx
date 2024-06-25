import React, { useState, useEffect } from 'react';
import TarefaListar from './tarefa/listar-tarefas';
import { BrowserRouter, Route, Routes, Link, Navigate } from 'react-router-dom';

function MenuHorizontal() {
    return(
    <div>
        <nav>
            <a href="/pages/tarefa/listar">Listar Tarefas</a><br />
            <a href="/pages/tarefa/cadastrar">Cadastrar Tarefa</a><br />
            <a href="/pages/tarefa/alterar">Alterar Tarefa</a><br />
            <a href="/pages/tarefa/naoconcluidas">Listar Tarefas Não Concluidas</a><br />
            <a href="/pages/tarefa/concluidas">Listar Tarefas Concluidas</a>
        </nav>
    </div>
    );
}

export default MenuHorizontal;