import React, { useEffect, useState } from 'react';
import { Usuario } from '../Models/Usuario';

const ListaUsuarios: React.FC = () => {
    const [usuarios, setUsuarios] = useState<Usuario[]>([]);

    useEffect(() => {
        carregarDados();
    }, []);

    const carregarDados = async () => {
        try {
            const resposta = await fetch("http://localhost:5005/api/usuario/listar");
            if (!resposta.ok) {
                throw new Error('Erro na resposta da API');
            }
            const dados = await resposta.json();
            setUsuarios(dados);
        } catch (erro) {
            console.error("Deu erro!", erro);
            // setError("Erro ao carregar dados");
        }
    };

    return (
        <div>
            <h1>Lista de Produtos</h1>
            <table className='tabela'>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Cpf</th>
                    </tr>
                </thead>
                <tbody>
                    {usuarios.map(usuario => (
                        <tr key={usuario.id}>
                            <td>{usuario.id} a</td>
                            <td>{usuario.nome}</td>
                            <td>{usuario.cpf}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default ListaUsuarios;