using System.Text;
using ECommerce.Lib.BE;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("", client =>
{
    client.BaseAddress = new Uri("https://localhost:7030");
    client.Timeout=TimeSpan.FromSeconds(5);
    // You can add other configurations here
});


builder.Services.Configure<List<ECommerce.Lib.BE.Product>>(builder.Configuration.GetSection("productList"));


//builder.Services.AddAuthentication(
//        CertificateAuthenticationDefaults.AuthenticationScheme)
//    .AddCertificate();

//builder.Services.AddAuthentication(opt =>
//    {
//        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    })
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = "https://localhost:44379",
//            ValidAudience = "https://localhost:44379",
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
//        };
//    });


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/login";
        options.Cookie.Name = "RepositoryXN-Tier";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";

    });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("*");
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();

        });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(name: "default", pattern: "{controller=Main}/{action=Index}/{id?}");

app.MapControllerRoute(name: "secondary", pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
