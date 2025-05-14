

using SPI_Update_Service.Proxy.interfaces;
using SPI_Update_Service.Proxy.update;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar los servicios
builder.Services.AddSingleton<IRedUpdateService, RedUpdateServiceImpl>();

// Configurar logging
builder.Services.AddLogging(options =>
{
    options.AddConsole();
    options.AddDebug();
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();