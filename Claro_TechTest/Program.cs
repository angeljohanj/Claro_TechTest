using Claro_TechTest.Dependencies;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection().UseAuthorization();

app.MapControllers();

app.Run();
