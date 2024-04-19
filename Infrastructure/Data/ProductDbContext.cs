using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductDbContext: DbContext
{
    public ProductDbContext (DbContextOptions<ProductDbContext> options):base(options)
    {

    }
    // set table name
    public DbSet<Product> Products { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
}