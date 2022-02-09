using APIRegioes.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<RegioesRepository>();

builder.Services.AddMiniProfiler(options =>
    options.RouteBasePath = "/profiler");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Rotas possíveis com a configuração do MiniProfiler:
    // /profiler/results -- Última operação
    // /profiler/results-index -- Listagem de todas as operações
    // /profiler/results?id={Guid Profiler}
    app.UseMiniProfiler();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();