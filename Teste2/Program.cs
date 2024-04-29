using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/usuario/listar", ([FromServices] AppDbContext banco) => 
{

    if (banco.Users.Any())
    {
        return Results.Ok(banco.Users.ToList());
    }
    return Results.NotFound("Não existem usuarios na tabela");
    
});

app.MapGet("/usuario/buscar/nome/{nome}", ([FromRoute] string nome, [FromServices] AppDbContext banco) => 
{
    User? usuario = banco.Users.FirstOrDefault(u => u.Nome == nome);

    if(usuario == null){
        return Results.BadRequest("Usuário não encontrado!");
    } 
    return Results.Ok(usuario);
    
});

app.MapGet("/usuario/buscar/id/{id}", ([FromRoute] string id, [FromServices] AppDbContext banco) => 
{
    User? usuario = banco.Users.FirstOrDefault(u => u.Id == id);

    if(usuario == null){
        return Results.BadRequest("Usuário não encontrado!");
    } 
    return Results.Ok(usuario);
    
});

app.MapPut("/usuario/atualizar/{nome}", (string nome, User usuarioAtualizado, AppDbContext banco) =>
{
    User? usuario = banco.Users.FirstOrDefault(u => u.Nome == nome);
    if (usuario == null)
    {
        return Results.NotFound("Usuario não encontrado.");
    }

    usuario.Nome = usuarioAtualizado.Nome;
    usuario.Email = usuarioAtualizado.Email;
    usuario.Senha = usuarioAtualizado.Senha;
    banco.SaveChangesAsync();
    return Results.Ok("Usuario atualizado com sucesso.");
});

app.MapPatch("/usuario/atualizar/nome/{nome}/{novoNome}", (string nome, string novoNome, AppDbContext banco) =>
{
    User? usuario = banco.Users.FirstOrDefault(u => u.Nome == nome);
    if (usuario == null)
    {
        return Results.NotFound("Usuario não encontrado.");
    }

    usuario.Nome = novoNome;
    banco.SaveChangesAsync();
    return Results.Ok("Usuario atualizado com sucesso.");
});

app.MapPost("/usuario/cadastrar", ([FromBody] User usuario, [FromServices] AppDbContext banco) => 
{
    User? buscaUserNome = banco.Users.FirstOrDefault(u => u.Nome == usuario.Nome);
    User? buscaUserEmail = banco.Users.FirstOrDefault(u => u.Email == usuario.Email);

    if (buscaUserNome is null && buscaUserEmail is null)
    {
        banco.Users.Add(usuario);
        banco.SaveChanges();
        return Results.Created($"/usuario/buscar/{usuario.Id}", usuario);
    }else if(buscaUserNome != null){
        return Results.BadRequest("Já existe um usuario com o mesmo nome!");
    }
    return Results.BadRequest("Já existe um usuario com o mesmo email!");

});

app.MapPost("/usuario/cadastrar/direto/{nome}/{email}/{senha}", ([FromRoute] string nome, string email, string senha, [FromServices] AppDbContext banco) => 
{
    User? buscaUserNome = banco.Users.FirstOrDefault(u => u.Nome == nome);
    User? buscaUserEmail = banco.Users.FirstOrDefault(u => u.Email == email);

    if (buscaUserNome is null && buscaUserEmail is null)
    {
        User usuario = new(nome, email, senha);
        banco.Users.Add(usuario);
        banco.SaveChanges();
        return Results.Created($"/usuario/buscar/{usuario.Id}", usuario);
    }else if(buscaUserNome != null){
        return Results.BadRequest("Já existe um usuario com o mesmo nome!");
    }
    return Results.BadRequest("Já existe um usuario com o mesmo email!");

});

app.MapDelete("/usuario/deletar/{nome}", ([FromRoute] string nome, [FromServices] AppDbContext banco) => 
{
    User? usuario = banco.Users.FirstOrDefault(u => u.Nome == nome);

    if(usuario != null){

        banco.Users.Remove(usuario);
        banco.SaveChanges();
        return Results.Created($"/usuario/buscar/{usuario.Id}", usuario);
        
    } 
    return Results.BadRequest("Usuário não encontrado!");
    
});

app.MapDelete("/usuario/deletartodos", async ([FromServices] AppDbContext banco) => 
{
    var usuarios = await banco.Users.ToListAsync();

    banco.Users.RemoveRange(usuarios);
    banco.SaveChanges();
    return Results.Ok("Usuários deletados!");
    
});



app.Run();
