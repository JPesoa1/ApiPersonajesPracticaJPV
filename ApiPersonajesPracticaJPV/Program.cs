using ApiPersonajesPracticaJPV.Data;
using ApiPersonajesPracticaJPV.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connnectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RespositoryPersonaje>();
builder.Services.AddDbContext<PersonajeContext>
    (x => x.UseSqlServer(connnectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Crud Personajes",
        Description = "HOLA",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI( x=>
{
    x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api crud Personajes");
    x.RoutePrefix = "";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
