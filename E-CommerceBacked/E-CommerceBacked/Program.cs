using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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
