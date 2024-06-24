public class Usuario{

    public Usuario()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Usuario(string nome, string cpf){
        Nome = nome;
        Cpf = cpf;
        Id = Guid.NewGuid().ToString();
    }
    
    public string? Nome {get; set;}
    public string? Cpf {get; set;}
    public string? Id {get; set;}
}