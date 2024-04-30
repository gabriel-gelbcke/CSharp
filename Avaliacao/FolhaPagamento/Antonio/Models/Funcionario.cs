public class Funcionario{

    public Funcionario()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Funcionario(string nome, string cpf){
        Nome = nome;
        Cpf = cpf;
        Id = Guid.NewGuid().ToString();
    }
    
    public string? Nome {get; set;}
    public string? Cpf {get; set;}
    public string? Id {get; set;}
}