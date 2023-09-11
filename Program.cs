using System;
using Microsoft.EntityFrameworkCore;
using DynamicWebBookLibrary.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using DynamicWebBookLibrary.Services; // or the correct namespace where BookService is defined

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<BookService>();

// Add services to the container
builder.Services.AddDbContext<BookContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
    new MySqlServerVersion(new Version(8, 0, 25)))); // Use the appropriate MySQL server version

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Request for {context.Request.Path} received");
    await next(); // Continue to the next middleware
    Console.WriteLine($"Response for {context.Request.Path} sent with status code {context.Response.StatusCode}");
});

app.Use(async (context, next) =>
{
    if (context.Request.Headers.ContainsKey("Authorization"))
    {
        await next(); // Continue to the next middleware
    }
    else
    {
        context.Response.StatusCode = 401; // Unauthorized
        await context.Response.WriteAsync("Not authorized");
    }
});

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    
Console.WriteLine("Application has started. Navigate to http://localhost:5297 in your browser to view the application.");

app.Run();
