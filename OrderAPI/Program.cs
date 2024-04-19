using ApplicationCore.Repository;
using ApplicationCore.Services;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// attach it to connectionstring
builder.Services.AddDbContext<ProductDbContext>(option =>
{
    //option.UseSqlServer(Environment.GetEnvironmentVariable("CustomerDB")); 
    // comment dev
    option.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB"));
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 
    // for contextDb not to track single instance of one entity
});
builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>(); // in controller
builder.Services.AddScoped<IProductRepoAsync, ProductRepoAsync>(); // in service
builder.Services.AddScoped<ICartItemServiceAsync, CartItemServiceAsync>(); // in controller
builder.Services.AddScoped<ICartItemRepoAsync, CartItemRepoAsync>(); // in service


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

app.Run();