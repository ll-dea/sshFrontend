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
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMenuService, MenuServices>();
builder.Services.AddScoped<IVenueTypeService, VenueTypeService>();
builder.Services.AddScoped<IVenueProviderService, VenueProviderService>();
builder.Services.AddScoped<IFlowerArrangmentService, FloristArrangmentService>();
builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
builder.Services.AddScoped<IMusicProviderOrderService, MusicProviderOrderServices>();
builder.Services.AddScoped<IFlowerArrangmentOrderService, FlowerArrangementOrderService>();
builder.Services.AddScoped<IVenueOrderService, VenueOrderService>();
builder.Services.AddScoped<IMenuOrderService, MenuOrderService>();
builder.Services.AddScoped<IFlowerArrangmentTypeService, FlowerArrangmentTypeService>();
builder.Services.AddScoped<IPerformerTypeService, PerformerTypeService>();
builder.Services.AddScoped<IMenuTypeService, MenuTypeService>();
builder.Services.AddScoped<IPartnerStatusService, PartnerStatusService>();
builder.Services.AddScoped<IPastryService, PastryService>();
builder.Services.AddScoped<IPastryShopService, PastryShopService>();
builder.Services.AddScoped<IPastryTypeService, PastryTypeService>();
builder.Services.AddScoped<IPlaylistItemService, PlaylistItemService>();
builder.Services.AddScoped<IPastryOrderService, PastryOrderService>();

// HttpContext accessor
builder.Services.AddHttpContextAccessor();

// ? Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ? Authentication setup
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

// ? Add session to middleware pipeline
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
