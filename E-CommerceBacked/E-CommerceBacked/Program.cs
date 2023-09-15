using System.Runtime.InteropServices.ComTypes;
using System.Text;
using E_CommerceBacked.Controllers;
using ECommerce.Lib.BE;
using ECommerce.Lib.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRazorPages();


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();


builder.Services.Configure<ECommerce.Lib.BE.Util.DBService>(configuration.GetSection("ConnectionStrings"));

builder.Services.Configure<FormatSettings>(builder.Configuration.GetSection("Formatting"));

builder.Services.AddScoped<ECommerce.Lib.BLL.Product>(p =>
{
    // Resolve the DBService dependency using the IServiceProvider
    var dbService = p.GetRequiredService<ECommerce.Lib.BE.Util.DBService>();

    // Create and return the Product instance with the resolved DBService
    return new ECommerce.Lib.BLL.Product(new ECommerce.Lib.DAL.Product(dbService));
}).AddScoped<ECommerceEndPoints>(); ;

// Register ECommerceEndPoints (if necessary)
//builder.Services.AddScoped<ECommerceEndPoints>();



//builder.Services
//    .AddScoped<ECommerce.Lib.BLL.Product>
//    (p =>
//            { return new ECommerce.Lib.BLL.Product(new ECommerce.Lib.DAL.Product()); })
//    .AddScoped<ECommerceEndPoints>();


//builder.Services
//    .AddScoped<ECommerce.Lib.BLL.Product>
//    (p=>{
//        return new ECommerce.Lib.BLL.Product(new ECommerce.Lib.DAL.Product());
//    });


//builder.Services
//    .AddScoped<ECommerce.Lib.BLL.Product, ECommerce.Lib.BLL.Product>()
//    .AddScoped<ECommerceEndPoints>();


builder.Services.Configure<FormatSettings>(builder.Configuration.GetSection("Formatting"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");

        // Customize the Swagger UI page, e.g., change the title
        c.DocumentTitle = "Custom Swagger UI Title";

        // Set a custom URL for the Swagger UI page
        c.RoutePrefix = "swagger";
    });
} 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

//app.MapControllerRoute(
//    name: "tada",
//    pattern: "{controller=ECommerceEndPoints}/{action=getProductbyID}/{id?}"
//    );

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});


app.Run();

static void main(string[] args)
{
    Console.WriteLine("Hello World");
}
