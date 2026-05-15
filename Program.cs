
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RateMedia.Data;
using RateMedia.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RateMediaDb>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<RateMediaDb>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
});

builder.Services.AddControllersWithViews();

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
    name: "default",
    pattern: "{controller=KMovies}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RateMediaDb>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    db.Database.Migrate();


    /* create a test user if it doesn't exist */
    const string testEmail = "test@ratemedia.si";
    const string testPassword = "Test123!";

    if (await userManager.FindByEmailAsync(testEmail) == null)
    {
        var testUser = new User
        {
            UserName = testEmail,
            Email = testEmail,
            DisplayName = "Testni Uporabnik"
        };
        await userManager.CreateAsync(testUser, testPassword);
    }
}

app.Run();