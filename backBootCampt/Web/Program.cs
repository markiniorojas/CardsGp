using Web.Service_Extensions;
using Web.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddDataBase(builder.Configuration);
builder.Services.AddProjectDependencies();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddCorsPolicy(builder.Configuration);

// Aquí registras tus servicios de dominio
builder.Services.AddRepositories(); // ? Esto incluye PlayerService, RoundService, etc.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PoliticaCors");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
