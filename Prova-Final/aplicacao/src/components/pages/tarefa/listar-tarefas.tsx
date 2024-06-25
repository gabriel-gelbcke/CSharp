import React, { useState, useEffect } from 'react';
import { Tarefa } from '../../../models/tarefa';
import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';

function TarefaListar() {
    const [tarefas, setTarefas] = useState<Tarefa[]>([]);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        console.log("Executar algo ao carregar o componente...");
        carregarDados();
    }, []);

    const carregarDados = async () => {
        try {
            const resposta = await fetch("http://localhost:5000/tarefas/listar");
            if (!resposta.ok) {
                throw new Error('Erro na resposta da API');
            }
            const dados = await resposta.json();
            setTarefas(dados);
        } catch (erro) {
            console.error("Deu erro!", erro);
            setError("Erro ao carregar dados");
        }
    };

    return (
        <div>
            <br /><br />
            {error && <p style={{ color: 'red' }}>{error}</p>}

            <table>
            <thead>
                      <tr className='tabela'>
                        <th scope="col">ID</th>
                        <th scope="col">TITULO</th>
                        <th scope="col">DESCRIÇÃO</th>
                        <th scope="col">CRIADO EM</th>
                        <th scope="col">CATEGORIA</th>
                        <th scope="col">CATEGORIA ID</th>
                        <th scope="col">STATUS</th>
                      </tr>
                      
                    </thead>


            {tarefas.map((tarefa) => 
                    <tbody>
                      <tr className='tabela' key={tarefa.tarefaId}>
                        <td>{tarefa.tarefaId}</td>
                        <td>{tarefa.titulo}</td>
                        <td>{tarefa.descricao}</td>
                        <td>{tarefa.criadoEm}</td>
                        <td>{tarefa.categoria?.nome}</td>
                        <td>{tarefa.categoriaId}</td>
                        <td>{tarefa.status}</td>
                        
                        </tr>
                    </tbody>
                    )}
                    </table>
        </div>
    );
}

export default TarefaListar;