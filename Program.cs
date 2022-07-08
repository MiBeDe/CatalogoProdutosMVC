using CatalogoProdutosMVC.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//ConnectionString
string cnn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CatalogoProdutosDbContext>(op => op.UseSqlServer(cnn));

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
app.MapControllerRoute(
    name: "Cadastrar",
    pattern: "Cadastrar",
    defaults: new { Controller = "Products", Action = "Cadastro" }
    );

app.MapControllerRoute(
    name: "Pedido",
    pattern: "Pedido",
    defaults: new { Controller = "Pedido", Action = "Pedidos" }
    );
app.MapControllerRoute(
    name: "Estoque",
    pattern: "Estoque",
    defaults: new { Controller = "Estoque", Action = "Listar" }
    );
app.Run();
