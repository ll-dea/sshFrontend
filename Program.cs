using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Services;
using SSH_FrontEnd.Services.IServices;
using System;
using Utility;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews(options => {
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
}).AddRazorRuntimeCompilation();


builder.Services.AddHttpClient("EventAPI", client => {
    client.BaseAddress = new Uri(builder.Configuration["ServiceUrls:EventAPI"]);
});
builder.Services.AddHttpClient("UserAPI", client => {
    client.BaseAddress = new Uri(builder.Configuration["ServiceUrls:UserAPI"]);
});
builder.Services.AddHttpClient("SSHAPI", client => {
    client.BaseAddress = new Uri(builder.Configuration["ServiceUrls:BaseUrl"]);
});



builder.Services.AddScoped<IBaseServices, BaseServices>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventServices, EventServices>();

builder.Services.AddAutoMapper(typeof(MappingConfig));


SD.BaseUrl = builder.Configuration["ServiceUrls:BaseUrl"] ?? "https://localhost:5001";
SD.APIUrl = $"{SD.BaseUrl}/api/{SD.ApiVersion}";

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<APIRequest, APIRequest>(); 
        
    }
}