using System.Collections;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDataContext>();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Adicione esta linha para usar a política de CORS

app.UseAuthorization();

app.MapControllers(); // Certifique-se de que este middleware está presente


app.MapGet("/", () => "Prova A1");

//ENDPOINTS DE CATEGORIA
//GET: http://localhost:5273/categoria/listar
app.MapGet("/categoria/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Categorias.Any())
    {
        return Results.Ok(ctx.Categorias.ToList());
    }
    return Results.NotFound("Nenhuma categoria encontrada");
});

//POST: http://localhost:5273/categoria/cadastrar
app.MapPost("/categoria/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Categoria categoria) =>
{
    ctx.Categorias.Add(categoria);
    ctx.SaveChanges();
    return Results.Created("", categoria);
});

//ENDPOINTS DE TAREFA
//GET: http://localhost:5273/tarefas/listar
app.MapGet("/tarefas/listar", ([FromServices] AppDataContext ctx) =>
{
    // if (ctx.Tarefas.Any())
    // {
    //     return Results.Ok(ctx.Tarefas.ToList());
    // }
    // return Results.NotFound("Nenhuma tarefa encontrada");
    var tarefas = ctx.Tarefas.ToList();

    ArrayList tarefasList = [];

    foreach (Tarefa taf in tarefas)
    {
        Categoria? categoria = ctx.Categorias.Find(taf.CategoriaId);

        taf.Categoria = categoria;

        tarefasList.Add(taf);
    }

    if (tarefasList.Count >= 1)
    {
        return Results.Ok(tarefasList);
    }
    return Results.NotFound("Nenhuma tarefa encontrada!");

});

//POST: http://localhost:5273/tarefas/cadastrar
app.MapPost("/tarefas/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Tarefa tarefa) =>
{
    Categoria? categoria = ctx.Categorias.Find(tarefa.CategoriaId);
    if (categoria == null)
    {
        return Results.NotFound("Categoria não encontrada");
    }
    tarefa.Categoria = categoria;
    tarefa.Status = "Concluida";
    ctx.Tarefas.Add(tarefa);
    ctx.SaveChanges();
    return Results.Created("", tarefa);
});

//PUT: http://localhost:5273/tarefas/alterar/{id}
app.MapPut("/tarefas/alterar/{id}", async ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    var tarefaBusca = await ctx.Tarefas.FindAsync(id);

    if (tarefaBusca == null)
    {
        return Results.NotFound("Tarefa não encontrada");
    }

    if (tarefaBusca.Status == "Em andamento")
    {
        tarefaBusca.Status = "Concluida";
    }else{
        tarefaBusca.Status = "Em andamento";
    }

    await ctx.SaveChangesAsync();

    return Results.Ok(tarefaBusca);
});

//GET: http://localhost:5273/tarefas/naoconcluidas
app.MapGet("/tarefas/naoconcluidas", ([FromServices] AppDataContext ctx) =>
{
    var tarefas = ctx.Tarefas.ToList();

    ArrayList tarefasNaoConcluidas = [];

    foreach (Tarefa taf in tarefas)
    {
        if (taf.Status == "Não iniciada" || taf.Status == "Em andamento")
        {
            Categoria? categoria = ctx.Categorias.Find(taf.CategoriaId);

            taf.Categoria = categoria;

            tarefasNaoConcluidas.Add(taf);
        }
    }

    if (tarefasNaoConcluidas.Count >= 1)
    {
        return Results.Ok(tarefasNaoConcluidas);
    }
    return Results.NotFound("Nenhuma não concluida encontrada!");

});

//GET: http://localhost:5273/tarefas/concluidas
app.MapGet("/tarefas/concluidas", ([FromServices] AppDataContext ctx) =>
{
    var tarefas = ctx.Tarefas.ToList();

    ArrayList tarefasConcluidas = [];

    foreach (Tarefa taf in tarefas)
    {
        if (taf.Status == "Concluida")
        {
            Categoria? categoria = ctx.Categorias.Find(taf.CategoriaId);

            taf.Categoria = categoria;

            tarefasConcluidas.Add(taf);
        }
    }

    if (tarefasConcluidas.Count >= 1)
    {
        return Results.Ok(tarefasConcluidas);
    }
    return Results.NotFound("Nenhuma concluida encontrada!");
});

app.Run();
