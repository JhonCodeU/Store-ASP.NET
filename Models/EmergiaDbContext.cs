using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmergiaStoreMVC.Models;

public partial class EmergiaDbContext : DbContext
{
    public EmergiaDbContext()
    {
    }

    public EmergiaDbContext(DbContextOptions<EmergiaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Cycle> Cycles { get; set; }

    public virtual DbSet<Detail> Details { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCycle> ProductCycles { get; set; }

    public virtual DbSet<Salesperson> Salespeople { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__79D361B637F66F43");

            entity.ToTable("Category");

            entity.Property(e => e.IdCategory)
                .ValueGeneratedNever()
                .HasColumnName("idCategory");
            entity.Property(e => e.Detail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("detail");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ParentCategoryId).HasColumnName("parentCategoryID");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("FK__Category__parent__3D5E1FD2");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__Customer__D0587686DF247A6B");

            entity.ToTable("Customer");

            entity.Property(e => e.IdCustomer)
                .ValueGeneratedNever()
                .HasColumnName("idCustomer");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Facebook)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("facebook");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Instagram)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("instagram");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Twitter)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("twitter");
        });

        modelBuilder.Entity<Cycle>(entity =>
        {
            entity.HasKey(e => e.IdCycle).HasName("PK__Cycle__E2A679882BECEB1E");

            entity.ToTable("Cycle");

            entity.Property(e => e.IdCycle)
                .ValueGeneratedNever()
                .HasColumnName("idCycle");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("endDate");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("startDate");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Detail>(entity =>
        {
            entity.HasKey(e => e.IdDetail).HasName("PK__Detail__75EC3C0677EF80A5");

            entity.ToTable("Detail");

            entity.Property(e => e.IdDetail)
                .ValueGeneratedNever()
                .HasColumnName("idDetail");
            entity.Property(e => e.IdCycle).HasColumnName("idCycle");
            entity.Property(e => e.IdInvoice).HasColumnName("idInvoice");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdInvoiceNavigation).WithMany(p => p.Details)
                .HasForeignKey(d => d.IdInvoice)
                .HasConstraintName("FK__Detail__idInvoic__4BAC3F29");

            entity.HasOne(d => d.Id).WithMany(p => p.Details)
                .HasForeignKey(d => new { d.IdProduct, d.IdCycle })
                .HasConstraintName("FK__Detail__4AB81AF0");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.IdInvoice).HasName("PK__Invoice__D3631FCE583867BE");

            entity.ToTable("Invoice");

            entity.Property(e => e.IdInvoice)
                .ValueGeneratedNever()
                .HasColumnName("idInvoice");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");
            entity.Property(e => e.IdSalesperson).HasColumnName("idSalesperson");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.IdCustomer)
                .HasConstraintName("FK__Invoice__idCusto__46E78A0C");

            entity.HasOne(d => d.IdSalespersonNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.IdSalesperson)
                .HasConstraintName("FK__Invoice__idSales__47DBAE45");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product__5EEC79D13ACF2E24");

            entity.ToTable("Product");

            entity.Property(e => e.IdProduct)
                .ValueGeneratedNever()
                .HasColumnName("idProduct");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Detail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("detail");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Product__idCateg__403A8C7D");
        });

        modelBuilder.Entity<ProductCycle>(entity =>
        {
            entity.HasKey(e => new { e.IdProduct, e.IdCycle }).HasName("PK__Product___C0C61E49D94BEA20");

            entity.ToTable("Product_Cycle");

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdCycle).HasColumnName("idCycle");
            entity.Property(e => e.Cannon)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cannon");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PromotionalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("promotionalPrice");
            entity.Property(e => e.SalesCommission)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("salesCommission");

            entity.HasOne(d => d.IdCycleNavigation).WithMany(p => p.ProductCycles)
                .HasForeignKey(d => d.IdCycle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_C__idCyc__440B1D61");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductCycles)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_C__idPro__4316F928");
        });

        modelBuilder.Entity<Salesperson>(entity =>
        {
            entity.HasKey(e => e.IdSalesperson).HasName("PK__Salesper__FF53E9B69FF1E35A");

            entity.ToTable("Salesperson");

            entity.Property(e => e.IdSalesperson)
                .ValueGeneratedNever()
                .HasColumnName("idSalesperson");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.ConditionIf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("conditionIf");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Facebook)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("facebook");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Instagram)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("instagram");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Twitter)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("twitter");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
