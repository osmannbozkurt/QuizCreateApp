using Autofac;
using Autofac.Extensions.DependencyInjection;
using Businness.DependencyInjection.Autofac;
using Core.DependencyInjection;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Index/";
        });

#region Autofac Modules Integrations
builder.Services.AddDependencyResolvers(new ICoreModule[] {
               new CoreModule()
            });

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutoFacModule()));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
#region Exception Middleware Integration
app.ConfigureCustomExceptionMiddleware();
#endregion

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=QuizList}/{id?}");

app.Run();
