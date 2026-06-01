using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WpfApp2.Data;

namespace WpfApp2.Model;

public partial class TestDemContext : DbContext
{
    public TestDemContext()
    {
    }

    public TestDemContext(DbContextOptions<TestDemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Creater> Creaters { get; set; }

    public virtual DbSet<DetailsOrder> DetailsOrders { get; set; }

    public virtual DbSet<Import> Imports { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Pvz> Pvzs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=TestDem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0BDC6C6BD3");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Creater>(entity =>
        {
            entity.HasKey(e => e.CreaterId).HasName("PK__Creater__538CFE8E977DCB11");

            entity.ToTable("Creater");

            entity.Property(e => e.CreaterName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetailsOrder>(entity =>
        {
            entity.HasKey(e => e.DetailsOrdersId).HasName("PK__DetailsO__F6D3EC2156F43587");

            entity.Property(e => e.ProductsId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Orders).WithMany(p => p.DetailsOrders)
                .HasForeignKey(d => d.OrdersId)
                .HasConstraintName("FK__DetailsOr__Order__55009F39");

            entity.HasOne(d => d.Products).WithMany(p => p.DetailsOrders)
                .HasForeignKey(d => d.ProductsId)
                .HasConstraintName("FK__DetailsOr__Produ__55F4C372");
        });

        modelBuilder.Entity<Import>(entity =>
        {
            entity.HasKey(e => e.ImportId).HasName("PK__Import__869767EAE3E9D852");

            entity.ToTable("Import");

            entity.Property(e => e.ImportName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdersId).HasName("PK__Orders__630B99762F483BF1");

            entity.Property(e => e.Pvzid).HasColumnName("PVZId");

            entity.HasOne(d => d.Pvz).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Pvzid)
                .HasConstraintName("FK__Orders__PVZId__503BEA1C");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Orders__StatusId__5224328E");

            entity.HasOne(d => d.Users).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK__Orders__UsersId__51300E55");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductsId).HasName("PK__Products__BB48EDE51CCA928E");

            entity.Property(e => e.ProductsId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Info)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__4B7734FF");

            entity.HasOne(d => d.Creater).WithMany(p => p.Products)
                .HasForeignKey(d => d.CreaterId)
                .HasConstraintName("FK__Products__Create__4A8310C6");

            entity.HasOne(d => d.Import).WithMany(p => p.Products)
                .HasForeignKey(d => d.ImportId)
                .HasConstraintName("FK__Products__Import__498EEC8D");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .HasConstraintName("FK__Products__Produc__47A6A41B");

            entity.HasOne(d => d.Unit).WithMany(p => p.Products)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK__Products__UnitId__489AC854");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("PK__ProductT__A1312F6EBE991581");

            entity.ToTable("ProductType");

            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pvz>(entity =>
        {
            entity.HasKey(e => e.Pvzid).HasName("PK__PVZ__5957648FB266443F");

            entity.ToTable("PVZ");

            entity.Property(e => e.Pvzid).HasColumnName("PVZId");
            entity.Property(e => e.Pvzname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PVZName");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A9721C4A0");

            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE20633CE2D196");

            entity.ToTable("Status");

            entity.Property(e => e.StatusType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__Unit__44F5ECB560365A19");

            entity.ToTable("Unit");

            entity.Property(e => e.UnitName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CA4C10BD2");

            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
