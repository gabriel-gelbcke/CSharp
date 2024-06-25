import { Categoria } from "./categoria";

export interface Tarefa{
    tarefaId?: string;
    titulo?: string;
    descricao?: string;
    criadoEm?: string;
    categoria?: Categoria;
    categoriaId?: string;
    status?: string;
}