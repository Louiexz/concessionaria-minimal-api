using API.Controller;
using API.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var userSession = new UserSession();

new UserController(app, userSession);
new CarController(app, userSession);

// Configure o pipeline de requisição HTTP.app.UseSwagger();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
        c.RoutePrefix = ""; // <- opcional, se quiser que carregue em `/`
    });
}

app.UseHttpsRedirection();

app.Run();
