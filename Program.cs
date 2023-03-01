using FastEndpoints.Swagger;
using FastEndpoints;
using API_4BIO.Data;
using API_4BIO.Data.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
builder.Services.AddDbContext<ApplicationDB>();
builder.Services.AddScoped<IClientManager, ClientManager>();
builder.Services.AddScoped<IDataMocker, DataMocker>();


var app = builder.Build();


app.UseDefaultExceptionHandler();
app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();

