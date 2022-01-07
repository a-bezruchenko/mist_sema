using Microsoft.EntityFrameworkCore;
using mist_sema.Controllers;
using mist_sema.Model;
using mist_sema.Validators;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = "Filename=db.sqlite";

builder.Services.AddControllersWithViews();
builder.Services
    .AddScoped<IComponentRepository, ComponentRepository>()
    .AddScoped<IConfigurationRepository, TestConfigurationRepository>()
    .AddScoped<IValidator, ComponentsCountValidator>()
    .AddScoped<IValidator, TotalPowerValidator>()
    .AddScoped<IValidator, MemoryCompatabilityValidator>()
    .AddScoped<IValidator, ProcessorCompatabilityValidator>()
    .AddScoped<IControllerUtils, ControllerUtils>()
    .AddDbContext<ComponentContext>(options => { options.UseSqlite($"Data Source=data.db"); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();