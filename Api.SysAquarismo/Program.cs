using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Infrastructure.Data;
using Api.SysAquarismo.Infrastructure.Data.Repository;
using Microsoft.Extensions.PlatformAbstractions;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
    string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
    string caminhoDocumentacao = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");
    c.IncludeXmlComments(caminhoDocumentacao);

    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Api SysAquarismo",
        Version = "v1",
        Description = "Api responsavel pelo gerenciamento do Sistema SysAquarismo",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact 
        {
            Email = "yuri09.moyses@gmail.com",
            Name = "Yuri Moyses da Silva",
            Url = new Uri("https://www.linkedin.com//in/yuri-moys%C3%A9s-541451176/")
        }
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPeixeRepository, PeixeRepository>();
builder.Services.AddTransient<IContext, Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api SysAquarismo v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
