using CLINICA_UH.CapaModelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexión a SQL Server
var connectionString = builder.Configuration.GetConnectionString("ClinicaDB");
builder.Services.AddDbContext<ClinicaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
