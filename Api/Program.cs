using Microsoft.Extensions.DependencyInjection;
using Abstractions;
using DynamoDB;
using Amazon.DynamoDBv2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDataConnectionSettingsFactory<AmazonDynamoDBConfig>, LocalDynamoDBConnectionSettingsFactory>();
builder.Services.AddScoped<IDataClientFactory<AmazonDynamoDBClient>, DynamoDBClientFactory>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
