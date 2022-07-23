using HBPUI.Library.Api;
using HBPUI.Library.Endpoint;
using HBPWebUI.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddTransient<IApiSetup, ApiSetup>();
builder.Services.AddTransient<IProductEndpoint, ProductEndpoint>();
builder.Services.AddTransient<ICategoryEndpoint, CategoryEndpoint>();
builder.Services.AddTransient<IProductHelper, ProductHelper>();
builder.Services.AddTransient<ICategoryHelper, CategoryHelper>();
builder.Services.AddTransient<IBasketHelper, BasketHelper>();


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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{name?}");

app.MapControllerRoute(
    name: "category",
    pattern: "{controller=Browse}/{action=Category}/{category?}");

app.MapControllerRoute(
    name: "browse",
    pattern: "{controller=Browse}/{action=Index}/{category?}/{subcategory?}/{type?}");


app.Run();
