using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServicioMontacargas.Data;
using DinkToPdf;
using DinkToPdf.Contracts;
using ServicioMontacargas.Extension;
using ServicioMontacargas.Interfaces;
using ServicioMontacargas.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ServicioMontacargasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServicioMontacargasContext") ?? throw new InvalidOperationException("Connection string 'ServicioMontacargasContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IViewRenderService, ViewRenderService>();


builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
