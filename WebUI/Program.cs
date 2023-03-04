using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(
   )
    .AddCookie(option =>
    {
        option.LoginPath = "Account/Login";

        option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        option.Cookie = new CookieBuilder
        {
            HttpOnly = true,
            Name = "Academy cookies",
            SameSite = SameSiteMode.Strict
        };

    });

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
});

Assembly.GetExecutingAssembly();

builder.Services.AddDbContext<AcademyContext>();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AcademyContext>()
    .AddDefaultTokenProviders();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

    options.Cookie = new CookieBuilder()
    {
        HttpOnly = true,
        Name = "Academy.Security.Cookie"
    };
});

builder.Services.AddMvc();
builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;

});

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

app.UseMvc(Route =>
{
    Route.MapRoute(
      name: "default",
      template: "{controller=Home}/{action=Index}/{id?}"
      );

    Route.MapRoute(
        name: "cart",
        template: "cart",
        defaults: new { controller = "Cart", action = "Index" }
        );
    Route.MapRoute(
        name: "exam",
        template: "exam",
        defaults: new { controller = "Exam", action = "Exam" }
        );
    Route.MapRoute(
       name: "result",
       template: "result",
       defaults: new { controller = "Result", action = "Index" }
       );
    Route.MapRoute(
     name: "sulution",
     template: "solution",
     defaults: new { controller = "Solution", action = "Questions" }
     );
    Route.MapRoute(
     name: "questions",
     template: "MyExam/{id?}",
     defaults: new { controller = "Exam", action = "Exam" }
     );
});

app.Run();
