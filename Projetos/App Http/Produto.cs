public class Produto
{

     public Produto(string nome, string descricao, string preco)
     {
          Nome = nome;
          Descricao = descricao;
          Preco = preco;
          CriadoEm = DateTime.Now;
     }

     public string? Nome {get; set;}

     public string? Descricao {get; set;}

     public string? Preco {get; set;}

     public DateTime CriadoEm {get; set;}

}