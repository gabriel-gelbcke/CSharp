using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapGet("/api/funcionario/listar", ([FromServices] AppDbContext banco) =>
{
    if (banco.Funcionarios.Any())
    {
        return Results.Ok(banco.Funcionarios.ToList());
    }
    return Results.NotFound("Não existem usuarios na tabela");

});

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDbContext banco) =>
{
    Funcionario? funcionarioBuscaNome = banco.Funcionarios.FirstOrDefault(f => f.Nome == funcionario.Nome); 
    Funcionario? funcionarioBuscaCpf = banco.Funcionarios.FirstOrDefault(u => u.Cpf == funcionario.Cpf);

    if(funcionarioBuscaNome == null && funcionarioBuscaCpf == null){
        
        banco.Funcionarios.Add(funcionario);
        banco.SaveChanges();
        return Results.Created($"/usuario/buscar/{funcionario.Id}", funcionario);

    }else if(funcionarioBuscaNome != null){
        return Results.BadRequest("Já existe um funcionario cadastrado com esse nome!"); 
    }
    return Results.BadRequest("Já existe um funcionario cadastrado com esse cpf!"); 

});

app.MapPost("/api/folha/cadastrar/", ([FromBody] FolhaPagamento folhaPagamento, [FromServices] AppDbContext banco) =>
{
    FolhaPagamento? folhaBuscaId = banco.FolhaPagamentos.FirstOrDefault(f => f.Id == folhaPagamento.Id); 

    if(folhaBuscaId == null){
        
        banco.FolhaPagamentos.Add(folhaPagamento);
        banco.SaveChanges();
        return Results.Created($"/usuario/buscar/{folhaPagamento.Id}", folhaPagamento);
    }
    return Results.BadRequest(404); 
});

app.MapGet("/api/folha/listar", ([FromServices] AppDbContext banco) => 
{

    if (banco.FolhaPagamentos.Any())
    {
        return Results.Ok(banco.FolhaPagamentos.ToList());
    }
    return Results.NotFound("Não existem usuarios na tabela");
    
});

app.Run();
