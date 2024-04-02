using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

List<Produto> produtos =
[
    new Produto("Celular", "Android", "500"),
    new Produto("Celular2", "IOS", "600"),
    new Produto("Celular3", "Android", "700"),
    new Produto("Celular4", "IOS", "800")
];

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/cadastrar/{nome}/{descricao}/{preco}",
(string nome, string descricao, string preco) =>
{
    Produto produto2 = new Produto(nome, descricao, preco);

    produto2.Nome = nome;
    produto2.Descricao = descricao;
    produto2.Preco = preco;

    produtos.Add(produto2);

    Console.WriteLine(nome);
    Console.WriteLine(descricao);
    Console.WriteLine(preco);

    return Results.Created("", produto2);
});

app.MapDelete("/api/produto/deletar/{nome}", (string nome) =>
{

    var produtoParaDeletar = produtos.FirstOrDefault(p => p.Nome == nome);

    produtos.Remove(produtoParaDeletar);

    return Results.Ok("Deletado");
});

app.MapPut("/api/produto/alterar/{nome}", (string nome, Produto novoProduto) =>
{

    var produtoParaAlterar = produtos.FirstOrDefault(p => p.Nome == nome);

    produtoParaAlterar.Nome = novoProduto.Nome;


    return Results.Ok("Alterado");
});

app.MapGet("/produto/listar", () => produtos);

app.UseHttpsRedirection();

app.Run();

