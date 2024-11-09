using UniversityApp.Models; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<UniversityContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MyDatabase"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MyDatabase"))
    ));


var app = builder.Build();

// Налаштування конвеєра обробки запитів
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // Додає маршрутизацію для API-контролерів
app.MapRazorPages();   // Додає маршрутизацію для Razor Pages

app.Run();
