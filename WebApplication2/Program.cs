global using OnlineWalmart.DAL.Entities;
global using OnlineWalmart.DAL.Contexts;
global using OnlineWalmart.DAL.Interfaces;
global using OnlineWalmart.DAL.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TimsString"));
});
// Add services to the container.
//builder.Configuration.AddJsonFile("ocelot.json");

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddOcelot();

var app = builder.Build();

using (var scope = ((IApplicationBuilder)app).ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProductContext>();
    await context.Database.EnsureDeletedAsync();
    await context.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseOcelot().Wait();

app.UseAuthorization();

app.MapControllers();

app.Run();
