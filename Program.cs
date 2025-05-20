using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using SSH_FrontEnd;
using SSH_FrontEnd.Services;
using SSH_FrontEnd.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingConfig));

// Register named HttpClient for API usage
builder.Services.AddHttpClient("EventPlannerAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ServicesUrls:EventPlannerAPI"]);
});

// Register services
builder.Services.AddScoped<IEventServices, EventServices>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddScoped<IFloristService, FloristService>();

builder.Services.AddScoped<IMusicProviderService, MusicProviderService>();

builder.Services.AddScoped<IPastryService, PastryService>();



// Auth setup
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

var app = builder.Build();

// Configure the HTTP request pipeline
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
