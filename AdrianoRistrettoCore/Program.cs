using AdrianoRistrettoCore.Repository;
using AdrianoRistrettoCore.Services;

var builder = WebApplication.CreateBuilder(args);
var AllowAllOrigins = "AllowAll";

// Add services to the container.
builder.Services.Configure<DataBaseSettings>(
    builder.Configuration.GetSection("AdrianoRistrettoDB"));

builder.Services.AddSingleton<ContratoService>();
builder.Services.AddSingleton<EmpresaService>();
builder.Services.AddSingleton<FuncionarioService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAllOrigins, builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowAllOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
