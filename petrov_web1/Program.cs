using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using petrov_web1.Data;
using petrov_web1.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<petrov_web1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("petrov_web1Context") ?? throw new InvalidOperationException("Connection string 'petrov_web1Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
