﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcPacientes.Data;
using MvcPacientes.SeedData;
using MvcPacientes.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcPacientesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcPacientesContext") ?? throw new InvalidOperationException("Connection string 'MvcPacientesContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Add registers of Pacientes
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
