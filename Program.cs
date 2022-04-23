using CatalogoProdutosMVC.Database;
using CatalogoProdutosMVC.Repositories;
using CatalogoProdutosMVC.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//ConnectionString
string cnn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CatalogoProdutosDbContext>(op => op.UseSqlServer(cnn));

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();


//Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
    pattern: "{controller=Products}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Products",
    pattern: "Products/{cat?}/{sub?}",
    defaults: new {Controller = "Products", Action = "Index"}
    );
app.MapControllerRoute(
    name: "Detalhes",
    pattern: "Products/{idProd}",
    defaults: new {Controller = "Products", Action = "Detalhes"}
    );
app.Run();
