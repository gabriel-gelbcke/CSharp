import React, { useState, useEffect } from 'react';
import { Tarefa } from '../../../models/tarefa';
import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';

function CadastrarTarefa() {
    const [error, setError] = useState<string | null>(null);
    const [titulo, setTitulo] = useState<string>(''); 
    const [descricao, setDescricao] = useState<string>(''); 
    const [categoriaId, setCategoriaId] = useState<string>(''); 

    useEffect(() => {
        console.log("Executar algo ao carregar o componente...");
    }, []);

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        if (name === 'titulo') {
            setTitulo(value);
        } else if (name === 'descricao') {
            setDescricao(value);
        } else if (name === 'categoriaId') {
            setCategoriaId(value);
        }
    };

    const enviarDados = async () => {
        try {
            const url = `http://localhost:5000/tarefas/cadastrar`;
            const corpoRequisicao = {
                titulo: titulo,
                descricao: descricao,
                categoriaId: categoriaId
                
            };
            const resposta = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(corpoRequisicao)
            });

            if (!resposta.ok) {
                throw new Error('Erro ao enviar dados');
            }

            setError('Dados enviados com sucesso!');
            console.log('Dados enviados com sucesso!');
        } catch (erro) {
            console.error("Erro ao enviar dados:", erro);
            setError("Erro ao enviar dados");
        }
    };

    return (
        <div>
            <br /><br />
            {error && <p style={{ color: 'red' }}>{error}</p>}

            <input placeholder="titulo" type="text" id="titulo" name="titulo" value={titulo} onChange={handleInputChange} />
            <input placeholder="descricao" type="text" id="descricao" name="descricao" value={descricao} onChange={handleInputChange} />
            <input placeholder="categoriaId" type="text" id="categoriaId" name="categoriaId" value={categoriaId} onChange={handleInputChange} />
            <button onClick={enviarDados}>Cadastrar</button>
        </div>
    );
}

export default CadastrarTarefa;