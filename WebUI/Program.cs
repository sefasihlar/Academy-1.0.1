using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.Configure<IdentityOptions>(options =>
{

	options.Lockout.AllowedForNewUsers = true;
	options.User.RequireUniqueEmail = true;
	options.SignIn.RequireConfirmedEmail = true;

});

builder.Services.AddDbContext<AcademyContext>();
builder.Services.AddIdentity<AppUser, AppRole>()
	.AddEntityFrameworkStores<AcademyContext>()
	.AddDefaultTokenProviders();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
