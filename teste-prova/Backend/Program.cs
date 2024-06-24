using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

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

/// Create
app.MapPost("/api/usuario/cadastrar", ([FromBody] Usuario usuario, [FromServices] AppDbContext banco) =>
{
    Usuario? usuarioBuscaNome = banco.Usuarios.FirstOrDefault(f => f.Nome == usuario.Nome); 
    Usuario? usuarioBuscaCpf = banco.Usuarios.FirstOrDefault(u => u.Cpf == usuario.Cpf);

    if(usuarioBuscaNome == null && usuarioBuscaCpf == null){
        
        banco.Usuarios.Add(usuario);
        banco.SaveChanges();
        return Results.Created($"/usuario/buscar/{usuario.Id}", usuario);

    }else if(usuarioBuscaNome != null){
        return Results.BadRequest("Já existe um usuario cadastrado com esse nome!"); 
    }
    return Results.BadRequest("Já existe um usuario cadastrado com esse cpf!"); 

});

/// Read
app.MapGet("/api/usuario/listar", (AppDbContext context) =>
{
    var usuarios = context.Usuarios.ToList();
    return Results.Ok(usuarios);
});

/// Update
app.MapPut("/api/usuario/alterar/{id}", async ([FromRoute] string id, [FromBody] Usuario usuarioAtualizado, [FromServices] AppDbContext context) =>
{
    var usuarioBusca = await context.Usuarios.FindAsync(id);

    if (usuarioBusca == null)
    {
        return Results.NotFound("Usuario não encontrado");
    }

    usuarioBusca.Nome = usuarioAtualizado.Nome;
    usuarioBusca.Cpf = usuarioAtualizado.Cpf;

    await context.SaveChangesAsync();

    return Results.Ok(usuarioBusca);
});

/// Delete
app.MapDelete("/api/usuario/deletar/{id}", ([FromRoute] string Id, [FromServices] AppDbContext context) => 
{
    Usuario? usuarioBusca = context.Usuarios.FirstOrDefault(u => u.Id == Id);

    if(usuarioBusca != null){
        context.Usuarios.Remove(usuarioBusca);
        context.SaveChanges();
        return Results.Created($"/usuarios/buscar/{Id}", usuarioBusca);
    }
    return Results.BadRequest("Usuario não encontrado!"); 
});

app.Run();