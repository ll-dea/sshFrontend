using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using SSH_FrontEnd;
using SSH_FrontEnd.Services;
using SSH_FrontEnd.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------
// MVC + AutoMapper
// ------------------------------------
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingConfig));

// ------------------------------------
// HttpClient for API communication
// ------------------------------------
builder.Services.AddHttpClient("EventPlannerAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ServicesUrls:EventPlannerAPI"]);
});

// ------------------------------------
// Service Registrations (Clean & Grouped)
// ------------------------------------

// Core
builder.Services.AddScoped<IEventServices, EventServices>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

// Providers
builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddScoped<IVenueProviderService, VenueProviderService>();
builder.Services.AddScoped<IVenueTypeService, VenueTypeService>();
builder.Services.AddScoped<IFloristService, FloristService>();
builder.Services.AddScoped<IMusicProviderService, MusicProviderService>();
builder.Services.AddScoped<IPastryService, PastryService>();
builder.Services.AddScoped<IPastryShopService, PastryShopService>();

// Orders
builder.Services.AddScoped<IVenueOrderService, VenueOrderService>();
builder.Services.AddScoped<IMusicProviderOrderService, MusicProviderOrderServices>();
builder.Services.AddScoped<IPastryOrderService, PastryOrderService>();
builder.Services.AddScoped<IMenuOrderService, MenuOrderService>();
builder.Services.AddScoped<IFlowerArrangmentOrderService, FlowerArrangementOrderService>();

// Menus
builder.Services.AddScoped<IMenuService, MenuServices>();
builder.Services.AddScoped<IMenuTypeService, MenuTypeService>();

// Flowers
builder.Services.AddScoped<IFlowerArrangmentService, FloristArrangmentService>();
builder.Services.AddScoped<IFlowerArrangmentTypeService, FlowerArrangmentTypeService>();

// Misc
builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
builder.Services.AddScoped<IPartnerStatusService, PartnerStatusService>();
builder.Services.AddScoped<IPastryTypeService, PastryTypeService>();
builder.Services.AddScoped<IPerformerTypeService, PerformerTypeService>();
builder.Services.AddScoped<IPlaylistItemService, PlaylistItemService>();

// ------------------------------------
// HttpContext Accessor & Session
// ------------------------------------
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ------------------------------------
// Authentication (Cookies)
// ------------------------------------
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

// ------------------------------------
// Build & Middleware
// ------------------------------------
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
