using System.Text;
using E_CommerceBacked.Controllers;
using ECommerce.Lib.BE;
using ECommerce.Lib.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRazorPages();




//builder.Services
//    .AddScoped<ECommerce.Lib.BLL.Product>
//        (p =>
//            { return new ECommerce.Lib.BLL.Product(new ECommerce.Lib.DAL.Product()); })
//    .AddScoped<ECommerceEndPoints>();


builder.Services
    .AddScoped<ECommerce.Lib.BLL.Product>
    (p=>{
        return new ECommerce.Lib.BLL.Product(new ECommerce.Lib.DAL.Product());
    });
   


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
