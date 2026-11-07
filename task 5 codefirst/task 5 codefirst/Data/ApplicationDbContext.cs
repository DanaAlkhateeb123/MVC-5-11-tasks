using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using task_5_codefirst.Models;

namespace task_5_codefirst.Data
{
    public class ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext(options)
    {
        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Supplier> Suppliers { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;

        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.Property(c => c.Description)
                    .HasColumnType("varchar(500)");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(s => s.Name)
                    .HasColumnType("varchar(150)")
                    .IsRequired();

                entity.Property(s => s.Email)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.HasIndex(s => s.Email).IsUnique();

                entity.Property(s => s.Phone)
                    .HasColumnType("varchar(20)")
                    .IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name)
                    .HasColumnType("varchar(150)")
                    .IsRequired();

                entity.Property(p => p.Price)
                    .HasPrecision(10, 2);

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(p => p.Supplier)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.SupplierId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.Property(p => p.OrderDate)
                    .HasColumnType("datetime2");

                entity.Property(p => p.Status)
                    .HasColumnType("varchar(20)")
                    .IsRequired();

                entity.HasOne(p => p.Supplier)
                    .WithMany(s => s.PurchaseOrders)
                    .HasForeignKey(p => p.SupplierId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PurchaseOrderItem>(entity =>
            {
                entity.Property(i => i.UnitPrice)
                    .HasPrecision(10, 2);

                entity.HasOne(i => i.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderItems)
                    .HasForeignKey(i => i.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(i => i.Product)
                    .WithMany(p => p.PurchaseOrderItems)
                    .HasForeignKey(i => i.ProductId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}