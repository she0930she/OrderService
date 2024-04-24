using ApplicationCore.Repository;
using ApplicationCore.Services;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; // CORS
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins(
                    "http://localhost:4200", "http://example.com",
                    "https://ashy-river-0f68ccb1e.5.azurestaticapps.net")
                .AllowAnyHeader()
                .AllowAnyMethod();
                
        });
});
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
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();