using Fashion.Domain.Abstractions.Entities;
using Fashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Persistence;

public partial class FashionStoresContext : DbContext
{
    public FashionStoresContext()
    {
    }

    public FashionStoresContext(DbContextOptions<FashionStoresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductRate> ProductRates { get; set; }
    public virtual DbSet<ProductVariant> ProductVariant { get; set; }

    public virtual DbSet<RecipientsInformation> RecipientsInformations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleGroup> RoleGroups { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }
    private void SeedData(ModelBuilder modelBuilder)
    {
        List<RoleGroup> roleGroups = new List<RoleGroup> {
            new RoleGroup(){
                Id = Guid.NewGuid(),
                Name = "Admin"
            },
             new RoleGroup(){
                Id = Guid.NewGuid(),
                Name = "User"
            },
        };

        List<Role> roles = new List<Role>
        {
            new Role(){ Id = Guid.NewGuid(),Name = "Create_Product"},
            new Role(){ Id = Guid.NewGuid(),Name = "Find_Product"}
        };

        modelBuilder.Entity<RoleGroup>().HasData(roleGroups);
        modelBuilder.Entity<Role>().HasData(roles);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-BOC9JRS\\SQLEXPRESS;Initial Catalog=FashionStores;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;" , option => 
        option.CommandTimeout(300)
        );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var softDeleteEntities = typeof(ISoftDelete).Assembly.GetTypes().Where(type => typeof(ISoftDelete).IsAssignableFrom(type) && type.IsClass);

        foreach (var softDeleteEntitity in softDeleteEntities)
        {
            modelBuilder.Entity(softDeleteEntitity).HasQueryFilter(GenerateLamdaIsDeletedEqualFlase(softDeleteEntitity));
        }
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC074AD5E376");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.UserLoginId, "IX_Customer_UserLoginId");

            entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359E1B940700")
                .IsUnique()
                .HasFilter("([Phone] IS NOT NULL)");

            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedName).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.UserLogin).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserLoginId)
                .HasConstraintName("FK_Customer_Userlogin");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0741CB445D");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.UserLoginId, "IX_Employee_UserLoginId");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .HasDefaultValue("Nhân Viên");

            entity.HasOne(d => d.UserLogin).WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserLoginId)
                .HasConstraintName("FK_Employee_Userlogin");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC071334B5D6");

            entity.ToTable("Order");

            entity.HasIndex(e => e.CustomerId, "IX_Order_CustomerId");

            entity.HasIndex(e => e.RecipientsInformationId, "IX_Order_RecipientsInformationId");

            entity.HasIndex(e => e.VoucherId, "IX_Order_VoucherId");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedName).HasMaxLength(255);
            entity.Property(e => e.CustomerNote).HasMaxLength(500);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedName).HasMaxLength(255);
            entity.Property(e => e.DiscountPercent).HasDefaultValue(0.0);
            entity.Property(e => e.DiscountValue).HasDefaultValue(0.0);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tax).HasDefaultValue(0.0);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedName).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Order_Customer");

            entity.HasOne(d => d.RecipientsInformation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RecipientsInformationId)
                .HasConstraintName("FK_Order_RecipientsInformation");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_Order_Voucher");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC076F1F5F8B");

            entity.ToTable("OrderItem");

            entity.HasIndex(e => e.OrderId, "IX_OrderItem_OrderId");


            entity.Property(e => e.DiscountPercent).HasDefaultValue(0.0);
            entity.Property(e => e.DiscountValue).HasDefaultValue(0.0);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItem_Order");

        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC0725E8E8FC");

            entity.ToTable("Product");

            entity.HasIndex(e => e.CategoryId, "IX_Product_CategoryId");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedName).HasMaxLength(255);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedName).HasMaxLength(255);
            entity.Property(e => e.MainImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("Name_En");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedName).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__3214EC07582867F3");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductI__3214EC070BAF46A0");

            entity.ToTable("ProductImage");

            entity.HasIndex(e => e.ProductId, "IX_ProductImage_ProductId");

            entity.Property(e => e.ImageUrl).HasMaxLength(255);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductImage_Product");
        });

        modelBuilder.Entity<ProductRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductR__3214EC07D1E4BE12");

            entity.ToTable("ProductRate");

            entity.HasIndex(e => e.CustomerId, "IX_ProductRate_CustomerId");

            entity.HasIndex(e => e.ProductId, "IX_ProductRate_ProductId");

            entity.HasOne(d => d.Customer).WithMany(p => p.ProductRates)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_ProductRate_Customer");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductRates)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductRate_Product");
        });

        modelBuilder.Entity<RecipientsInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recipien__3214EC070B21DBA6");

            entity.ToTable("RecipientsInformation");

            entity.HasIndex(e => e.CustomerId, "IX_RecipientsInformation_CustomerId");

            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Detail).HasMaxLength(255);
            entity.Property(e => e.District).HasMaxLength(255);
            entity.Property(e => e.Latitude).HasMaxLength(255);
            entity.Property(e => e.Longiude).HasMaxLength(255);
            entity.Property(e => e.RecipientsName).HasMaxLength(255);
            entity.Property(e => e.RecipientsNote).HasMaxLength(255);
            entity.Property(e => e.RecipientsPhone)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Ward).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.RecipientsInformations)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipientsInformation_Customer");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC07DA4F84DC");

            entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<RoleGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoleGrou__3214EC07F2C32E25");

            entity.ToTable("RoleGroup");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasMany(d => d.Roles).WithMany(p => p.RoleGroups)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleGroupAndRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RoleGroupAndRole_Role"),
                    l => l.HasOne<RoleGroup>().WithMany()
                        .HasForeignKey("RoleGroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RoleGroupAndRole_RoleGroup"),
                    j =>
                    {
                        j.HasKey("RoleGroupId", "RoleId").HasName("PK__RoleGrou__003F8CCD9982EA3E");
                        j.ToTable("RoleGroupAndRole");
                        j.HasIndex(new[] { "RoleId" }, "IX_RoleGroupAndRole_RoleId");
                    });
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLogi__3214EC0753B5740E");

            entity.ToTable("UserLogin");

            entity.HasIndex(e => e.RoleGroupId, "IX_UserLogin_RoleGroupId");

            entity.HasIndex(e => e.Username, "UQ__UserLogi__536C85E4CC1A22D1").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(255);

            entity.HasOne(d => d.RoleGroup).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.RoleGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLogin_RoleGroup");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voucher__3214EC07734077BB");

            entity.ToTable("Voucher");

            entity.HasIndex(e => e.VoucherCode, "UQ__Voucher__7F0ABCA9AFCF4FF9").IsUnique();

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedName).HasMaxLength(255);
            entity.Property(e => e.DiscountPercent).HasDefaultValue(0.0);
            entity.Property(e => e.DiscountValue).HasDefaultValue(0.0);
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.VoucherCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
        });

        
        OnModelCreatingPartial(modelBuilder);
    }
    private LambdaExpression? GenerateLamdaIsDeletedEqualFlase(Type type)
    {
        var parameter = Expression.Parameter(type, "x");
        var valueOfPramas = Expression.Constant(false);
        var propertyOrField = Expression.PropertyOrField(parameter, nameof(ISoftDelete.IsDeleted));
        var defaultValue = Expression.Constant(false, typeof(bool));
        var propertyOrFieldCoalesced = Expression.Coalesce(propertyOrField, defaultValue);
        var condition = Expression.Equal(propertyOrFieldCoalesced, valueOfPramas);
        var lamda = Expression.Lambda(condition,parameter);
        return lamda;
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
