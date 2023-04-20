using holaMundoMVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EscuelaContext>(options => options.UseInMemoryDatabase(databaseName: "MyDB"));

// Crear una instancia del contexto de la base de datos
using (var context = builder.Services.BuildServiceProvider().GetService<EscuelaContext>())
{
	try
	{
		// Inicializar los datos en el contexto
		context.Database.EnsureCreated();
	}
	catch (Exception ex)
	{
		throw;
	}
};
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Escuela}/{action=Index}/{id?}");

app.Run();
