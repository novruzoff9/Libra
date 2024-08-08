using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdminApp.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdminAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdminAppDbContext") ?? throw new InvalidOperationException("Connection string 'AdminAppDbContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
