using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using PhotoStore;
using PhotoStore.Data;
using PhotoStore.Models;
using PhotoStore.Utilities;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SQLConnection")
    ));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromSeconds(4000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

/////
builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
builder.Services.AddMvc()
       .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
       .AddDataAnnotationsLocalization(options => {
           options.DataAnnotationLocalizerProvider = (type, factory) =>
               factory.Create(typeof(AnnotationSharedResource));
       });

builder.Services.Configure<RequestLocalizationOptions>(options => {
    var supportedCultures = new List<CultureInfo>()
    {
        new CultureInfo("en-US"),
        new CultureInfo("vi-VN")
    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
builder.Services.AddSingleton<SharedViewLocalizer>();
builder.Services.AddSingleton<IValidationAttributeAdapterProvider, IgnoreBadWordAttributeAdapterProvider>();
builder.Services.AddSingleton<IValidationAttributeAdapterProvider, NotPartOfAttributeAdapterProvider>();

/////

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.UseRequestLocalization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Me",
    pattern: "Me",
    new {controller = "User", action = "GetSelf"}
    );

app.Run();
