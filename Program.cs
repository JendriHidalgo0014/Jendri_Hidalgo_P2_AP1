using Jendri_Hidalgo_P2_AP1.Components;
using Jendri_Hidalgo_P2_AP1.Services;  
using Jendri_Hidalgo_P2_AP1.DAL;
using Jendri_Hidalgo_P2_AP1.Models;
using BlazorBootstrap;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Obtenemos el constructor para usarlo en el contexto.
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

builder.Services.AddDbContextFactory<Context>(options => options.UseSqlServer(ConStr));
builder.Services.AddBlazorBootstrap();

//Inyeccion del service.
builder.Services.AddScoped<CiudadesService>();
builder.Services.AddScoped<EncuestaService>();
builder.Services.AddScoped<CiudadesDetalleService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

