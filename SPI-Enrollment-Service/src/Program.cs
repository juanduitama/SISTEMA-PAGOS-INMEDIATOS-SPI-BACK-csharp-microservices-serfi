
using application.interfaces;
using application.Services.create;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Cargar archivo .env
Env.Load();



// Configurar AWS Clients con credenciales del .env

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddEnvironmentVariables();


builder.Services.AddSingleton<IRedEnrollmentService, RedEnrollmentServiceImpl>();

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