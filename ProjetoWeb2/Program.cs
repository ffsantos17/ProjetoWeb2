using Microsoft.EntityFrameworkCore;
using ProjetoWeb2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Contexto>(options => options.UseMySql(
        "Server=localhost;DataBase=local;Uid=felipe;Pwd=Acesso@01",
        serverVersion: Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mysql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
