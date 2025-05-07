using Amazon;
using Amazon.Runtime;
using Amazon.SecretsManager;
using Amazon.SimpleSystemsManagement;
using DotNetEnv;
using Repositories;
using SPI_Enrollment_Service.service.create;

var builder = WebApplication.CreateBuilder(args);

// Cargar archivo .env
Env.Load();

var region = RegionEndpoint.GetBySystemName(Environment.GetEnvironmentVariable("AWS_REGION"));
var credentials = new BasicAWSCredentials(
    Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID"),
    Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY")
);

// Configurar AWS Clients con credenciales del .env
builder.Services.AddSingleton<IAmazonSecretsManager>(
    sp => new AmazonSecretsManagerClient(credentials, region));

builder.Services.AddSingleton<IAmazonSimpleSystemsManagement>(
    sp => new AmazonSimpleSystemsManagementClient(credentials, region));

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IRedEnrollmentService, RedEnrollmentServiceImpl>();
builder.Services.AddSingleton<SecretManagerRepository>();
builder.Services.AddSingleton<ParameterStoreRepository>();

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