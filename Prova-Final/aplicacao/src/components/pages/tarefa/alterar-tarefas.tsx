import React, { useState, useEffect } from 'react';
import { Tarefa } from '../../../models/tarefa';
import { BrowserRouter, Route, Routes, Link } from 'react-router-dom';

function AlterarTarefa() {
    const [error, setError] = useState<string | null>(null);
    const [idTarefa, setidTarefa] = useState<string>(''); 

    useEffect(() => {
        console.log("Executar algo ao carregar o componente...");
    }, []);

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = event.target;
        if (name === 'idTarefa') {
            setidTarefa(value);
        }
    };

    const editarDados = async () => {
        try {
            const url = `http://localhost:5000/tarefas/alterar/${idTarefa}`;
            const resposta = await fetch(url, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
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

            <input placeholder="idTarefa" type="text" id="idTarefa" name="idTarefa" value={idTarefa} onChange={handleInputChange} />
            <button onClick={editarDados}>Editar</button>
        </div>
    );
}

export default AlterarTarefa;