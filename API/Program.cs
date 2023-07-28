using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

//Configuration for the HTTP Request Pipeline
app.UseCors
(
    builder => builder.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:4200")
);
app.MapControllers();

app.Run();
