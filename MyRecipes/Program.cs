using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyRecipes.Data;
using MyRecipes.Models;

var builder = WebApplication.CreateBuilder(args);


//serviço de conexao de contexto

string conexaopadrao = builder.Configuration.GetConnectionString("ConexaoPadrao");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(conexaopadrao)
    
    );
// Add services to the container.

//config do serviço de identidade, que é o serviço de autenticação e autorização do ASP.NET Core, que permite a gente criar usuarios, perfis, regras, etc
builder.Services.AddIdentity<Usuario, IdentityRole>(
    Options =>
    {
        Options.SignIn.RequireConfirmedEmail = false;
        Options.User.RequireUniqueEmail = false;
    }

)
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();



builder.Services.AddControllersWithViews();

var app = builder.Build();

//fodasse verde pra garantir a existencia dessa meda de banco

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
    
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


app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
