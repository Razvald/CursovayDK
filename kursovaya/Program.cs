using Microsoft.EntityFrameworkCore;
using rlf.Data;
using rlf.Data.interfaces;
using rlf.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBContent>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Регистрируем реализации интерфейсов в контейнере внедрения зависимостей
builder.Services.AddScoped<IAllTransactions, AllTransactions>();
builder.Services.AddScoped<ITransactionsCategory, TransactionsCategory>();

// Добавляем сервисы аутентификации и авторизации
builder.Services.AddAuthentication("Cookie").AddCookie();
builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "transactions",
    pattern: "Transactions/{action}/{userId?}",
    defaults: new { controller = "Transactions", action = "List" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();