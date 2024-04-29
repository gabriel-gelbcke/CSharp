public class User{

    public User(){
        Id = Guid.NewGuid().ToString();
    }

    public User(string nome, string email, string senha){
        Nome = nome;
        Email = email;
        Senha = senha;
        Id = Guid.NewGuid().ToString();
    }

    public string? Id {get; set;}
    public string? Nome {get; set;}

    public string? Email {get; set;}

    public string? Senha {get; set;}
}