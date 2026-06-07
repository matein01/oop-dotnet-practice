using BibliotecaWebApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ConexionDB>(sp =>
{
  var connectionString = builder.Configuration.GetConnectionString("BibliotecaDB");
  return new ConexionDB(connectionString);
});

builder.Services.AddScoped<PublicacionRepositorio>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();