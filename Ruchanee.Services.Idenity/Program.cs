using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ruchanee.Services.Idenity;
using Ruchanee.Services.Idenity.DbContexts;
using Ruchanee.Services.Idenity.Initializer;
using Ruchanee.Services.Idenity.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(SD.IdentityResources)
.AddInMemoryApiScopes(SD.ApiScopes)
.AddInMemoryClients(SD.Clients)
.AddAspNetIdentity<ApplicationUser>()
.AddDeveloperSigningCredential();

builder.Services.AddScoped<IDBInitializer, DBInitializer>();

builder.Services.AddControllersWithViews();

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
app.UseIdentityServer();
app.UseAuthorization();

SeedDatabase();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
    var context = app.Services.CreateScope().ServiceProvider.GetService<ApplicationDbContext>();
    var userManager = app.Services.CreateScope().ServiceProvider.GetService<UserManager<ApplicationUser>>();
    var roleManager = app.Services.CreateScope().ServiceProvider.GetService<RoleManager<IdentityRole>>();
    var dbInitializer = new DBInitializer(context, userManager, roleManager);
    dbInitializer.Initialize();
}
