using FastEndpoints.Swagger;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();



var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();

