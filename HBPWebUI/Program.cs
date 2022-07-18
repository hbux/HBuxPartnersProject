using HBPUI.Library.Api;
using HBPUI.Library.Endpoint;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddTransient<IApiSetup, ApiSetup>();
builder.Services.AddTransient<IProductEndpoint, ProductEndpoint>();
builder.Services.AddTransient<ICategoryEndpoint, CategoryEndpoint>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{name?}");

app.MapControllerRoute(
    name: "browse",
    pattern: "{controller=Browse}/{action=Index}/{category?}/{subcategory?}/{type?}");

app.Run();
