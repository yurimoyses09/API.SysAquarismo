using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Infrastructure.Data;
using Api.SysAquarismo.Infrastructure.Data.Repository;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.PlatformAbstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true; // Report API versions in response headers
    options.AssumeDefaultVersionWhenUnspecified = true; // Assume default version when none is specified
    options.DefaultApiVersion = new ApiVersion(2.0); // Set default API version to 1.0
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Use URL segment for versioning
}).AddODataApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // Format the version as "v1", "v2", etc.
    options.SubstituteApiVersionInUrl = true;
}).EnableApiVersionBinding();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => 
{
    string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
    string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
    string caminhoDocumentacao = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");
    c.IncludeXmlComments(caminhoDocumentacao);

    var provider = builder.Services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

    foreach (var description in provider.ApiVersionDescriptions)
    {
        c.SwaggerDoc(description.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = $"Api SysAquarismo {description.ApiVersion}",
            Version = description.ApiVersion.ToString(),
            Description = "Api responsavel pelo gerenciamento do Sistema SysAquarismo",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Email = "yuri09.moyses@gmail.com",
                Name = "Yuri Moyses da Silva",
                Url = new Uri("https://www.linkedin.com//in/yuri-moys%C3%A9s-541451176/")
            }
        });
    }
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IPeixeRepository, PeixeRepository>();
builder.Services.AddTransient<IContext, Context>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
