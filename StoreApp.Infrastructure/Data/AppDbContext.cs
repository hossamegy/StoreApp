using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreApp.Core.Entities;
using StoreApp.Core.Entities.Carts;
using StoreApp.Core.Entities.Orders;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Entities.Users;

namespace StoreApp.Infrastructure.Data;
public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Brands> Brands { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Review> Reviews { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
 
        // ── User ────────────────────────────────────────────────────────────────
 
        modelBuilder.Entity<User>(u =>
        {
 
            u.Property(x => x.FirstName).IsRequired().HasMaxLength(25);
            u.Property(x => x.LastName).IsRequired().HasMaxLength(25); 
   
            // User → Addresses (one-to-many)
            u.HasMany(x => x.Addresses)
             .WithOne(a => a.User)
             .HasForeignKey(a => a.UserId)
             .OnDelete(DeleteBehavior.Cascade);
 
            // User → Orders (one-to-many)
            u.HasMany(x => x.Orders)
             .WithOne(o => o.User)
             .HasForeignKey(o => o.UserId)
             .OnDelete(DeleteBehavior.Restrict); 
 
            // User → Cart (one-to-one)
            u.HasOne(x => x.Cart)
             .WithOne(c => c.User)
             .HasForeignKey<Cart>(c => c.UserId) 
             .OnDelete(DeleteBehavior.Cascade);
        });
 
        // ── Address ─────────────────────────────────────────────────────────────
 
        modelBuilder.Entity<Address>(a =>
        {
            a.HasKey(x => x.Id);
            a.Property(x => x.City).IsRequired().HasMaxLength(50);
            a.Property(x => x.Street).IsRequired().HasMaxLength(150);
        });
 
        // ── Product ─────────────────────────────────────────────────────────────
 
        modelBuilder.Entity<Product>(p =>
        {
            p.HasKey(x => x.Id);
            p.Property(x => x.Name).IsRequired().HasMaxLength(200);
            p.Property(x => x.Description).IsRequired().HasMaxLength(500);
            p.Property(x => x.Price).IsRequired();
 
            // Product → ProductImages (one-to-many)
            p.HasMany(x => x.ProductImages)
             .WithOne(pi => pi.Product)
             .HasForeignKey(pi => pi.ProductId)
             .OnDelete(DeleteBehavior.Cascade);
 
            // Product → Reviews (one-to-many)
            p.HasMany(x => x.Reviews)
             .WithOne(r => r.Product)
             .HasForeignKey(r => r.ProductId)
             .OnDelete(DeleteBehavior.Cascade);
        });
 
        // ── Brands ──────────────────────────────────────────────────────────────
 
        modelBuilder.Entity<Brands>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).IsRequired().HasMaxLength(50);
 
            // Brand → Products (one-to-many)
            b.HasMany(x => x.Products)
             .WithOne(p => p.Brand)
             .HasForeignKey(p => p.BrandId)
             .OnDelete(DeleteBehavior.Restrict);
        });
 
        // ── Categories ──────────────────────────────────────────────────────────
 
        modelBuilder.Entity<Categories>(c =>
        {
            c.HasKey(x => x.Id);
            c.Property(x => x.Name).IsRequired().HasMaxLength(50);
 
            // Category → Products (one-to-many)
            c.HasMany(x => x.Products)
             .WithOne(p => p.Category)
             .HasForeignKey(p => p.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);
        });
 
        // ── ProductImage ─────────────────────────────────────────────────────────
 
        modelBuilder.Entity<ProductImage>(pi =>
        {
            pi.HasKey(x => x.Id);
            pi.Property(x => x.ImageUrl).IsRequired();

            pi.HasIndex(x => new { x.ProductId, x.IsPrimary }).IsUnique();
        });
 
        // ── Cart ─────────────────────────────────────────────────────────────────
 
        modelBuilder.Entity<Cart>(c =>
        {
            c.HasKey(x => x.Id);
 
            // Cart → CartItems (one-to-many)
            c.HasMany(x => x.CartItem)
             .WithOne(ci => ci.Cart)
             .HasForeignKey(ci => ci.CartId)
             .OnDelete(DeleteBehavior.Cascade);
        });
 
        // ── CartItem ─────────────────────────────────────────────────────────────
 
        modelBuilder.Entity<CartItem>(ci =>
        {
            ci.HasKey(x => x.Id);
            ci.Property(x => x.Quantity).IsRequired();
            ci.Property(x => x.UnitPrice).IsRequired();
 
            // CartItem → Product (many-to-one)
            ci.HasOne(x => x.Product)
              .WithMany()
              .HasForeignKey(x => x.ProductId)
              .OnDelete(DeleteBehavior.Restrict);
        });
 
        // ── Order ─────────────────────────────────────────────────────────────────

        modelBuilder.Entity<Order>(o =>
        {
            o.HasKey(x => x.Id);
            o.HasOne(x => x.Address)
             .WithMany()
             .HasForeignKey(x => x.ShippingAddressId)
             .OnDelete(DeleteBehavior.Restrict);
 
            // Order → OrderItems (one-to-many)
            o.HasMany(x => x.OrderItems)
             .WithOne(oi => oi.Order)
             .HasForeignKey(oi => oi.OrderId)
             .OnDelete(DeleteBehavior.Cascade);
        });
 
        // ── OrderItems ────────────────────────────────────────────────────────────
 
        modelBuilder.Entity<OrderItems>(oi =>
        {
            oi.HasKey(x => x.Id);
            oi.Property(x => x.Quantity).IsRequired();
            oi.Property(x => x.UnitPrice).IsRequired();
 
            // OrderItem → Product (many-to-one)
            oi.HasOne(x => x.Product)
              .WithMany()
              .HasForeignKey(x => x.ProductId)
              .OnDelete(DeleteBehavior.Restrict);
        });
 
        // ── Review ────────────────────────────────────────────────────────────────
 
        modelBuilder.Entity<Review>(r =>
        {
            r.HasKey(x => x.Id);
            r.Property(x => x.Comment).IsRequired();
            r.Property(x => x.Rating).IsRequired();
 
            // Review → User (many-to-one)
            r.HasOne(x => x.User)
             .WithMany()
             .HasForeignKey(x => x.UserId)
             .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
