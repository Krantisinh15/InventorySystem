using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InvoiceProjectMVCCore.Models;

public partial class InvoiceProjectContext : DbContext
{
    public InvoiceProjectContext()
    {
    }

    public InvoiceProjectContext(DbContextOptions<InvoiceProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InvoicePayment> InvoicePayments { get; set; }

    public virtual DbSet<Tblcategory> Tblcategories { get; set; }

    public virtual DbSet<Tblcity> Tblcities { get; set; }

    public virtual DbSet<Tblcustomer> Tblcustomers { get; set; }

    public virtual DbSet<TblcustomerInvoice> TblcustomerInvoices { get; set; }

    public virtual DbSet<TblinvoiceProduct> TblinvoiceProducts { get; set; }

    public virtual DbSet<Tbllocation> Tbllocations { get; set; }

    public virtual DbSet<TblorderStock> TblorderStocks { get; set; }

    public virtual DbSet<TblorderStockProduct> TblorderStockProducts { get; set; }

    public virtual DbSet<Tblproduct> Tblproducts { get; set; }

    public virtual DbSet<TblrecivedStock> TblrecivedStocks { get; set; }

    public virtual DbSet<TblrecivedStockProduct> TblrecivedStockProducts { get; set; }

    public virtual DbSet<Tblstate> Tblstates { get; set; }

    public virtual DbSet<Tblsubcategory> Tblsubcategories { get; set; }

    public virtual DbSet<Tblunit> Tblunits { get; set; }

    public virtual DbSet<Tbluser> Tblusers { get; set; }

    public virtual DbSet<Tblvender> Tblvenders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KRANTI\\MSSQLSERVE;Database=InvoiceProject;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoicePayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__invoice___ED1FC9EA81239421");

            entity.ToTable("invoice_payment");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.PaymentAmount).HasColumnName("payment_amount");
            entity.Property(e => e.PaymentDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentDescription)
                .IsUnicode(false)
                .HasColumnName("payment_description");
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("payment_mode");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoicePayments)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("fkinid");

            entity.HasOne(d => d.User).WithMany(p => p.InvoicePayments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkuuid");
        });

        modelBuilder.Entity<Tblcategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tblcateg__D54EE9B42A714FD5");

            entity.ToTable("tblcategory");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Tblcategories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkccuid");
        });

        modelBuilder.Entity<Tblcity>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__tblcity__031491A893523127");

            entity.ToTable("tblcity");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city_name");
            entity.Property(e => e.StateId).HasColumnName("state_id");

            entity.HasOne(d => d.State).WithMany(p => p.Tblcities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("fksid");
        });

        modelBuilder.Entity<Tblcustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tblcusto__CD65CB85468F1B5A");

            entity.ToTable("tblcustomer");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email_address");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mobile_no");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Location).WithMany(p => p.Tblcustomers)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("fkllid");

            entity.HasOne(d => d.User).WithMany(p => p.Tblcustomers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkuid");
        });

        modelBuilder.Entity<TblcustomerInvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__tblcusto__F58DFD49397DED1F");

            entity.ToTable("tblcustomer_invoice");

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.InvoiceDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("invoice_date");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblcustomerInvoices)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("fkcusid");

            entity.HasOne(d => d.User).WithMany(p => p.TblcustomerInvoices)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkcusuid");
        });

        modelBuilder.Entity<TblinvoiceProduct>(entity =>
        {
            entity.HasKey(e => e.InvoiceProductId).HasName("PK__tblinvoi__8C8C7E01D4A51856");

            entity.ToTable("tblinvoice_products");

            entity.Property(e => e.InvoiceProductId).HasColumnName("invoice_product_id");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.PurchaseQuantity).HasColumnName("purchase_quantity");

            entity.HasOne(d => d.Invoice).WithMany(p => p.TblinvoiceProducts)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("fkiid");

            entity.HasOne(d => d.Product).WithMany(p => p.TblinvoiceProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fkinpid");
        });

        modelBuilder.Entity<Tbllocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__tbllocat__771831EAFBED4295");

            entity.ToTable("tbllocation");

            entity.Property(e => e.LocationId)
                .ValueGeneratedNever()
                .HasColumnName("location_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("location");

            entity.HasOne(d => d.City).WithMany(p => p.Tbllocations)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("fkcid");
        });

        modelBuilder.Entity<TblorderStock>(entity =>
        {
            entity.HasKey(e => e.OrderStockId).HasName("PK__tblorder__0C8FAE81A42533C7");

            entity.ToTable("tblorder_stock");

            entity.Property(e => e.OrderStockId).HasColumnName("order_stock_id");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.OderDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("oder_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VenderId).HasColumnName("vender_id");

            entity.HasOne(d => d.User).WithMany(p => p.TblorderStocks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkoruid");

            entity.HasOne(d => d.Vender).WithMany(p => p.TblorderStocks)
                .HasForeignKey(d => d.VenderId)
                .HasConstraintName("fkvid");
        });

        modelBuilder.Entity<TblorderStockProduct>(entity =>
        {
            entity.HasKey(e => e.OrderStockProductId).HasName("PK__tblorder__F682533403CD362F");

            entity.ToTable("tblorder_stock_products");

            entity.Property(e => e.OrderStockProductId).HasColumnName("order_stock_product_id");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.OderProductQuantity).HasColumnName("oder_product_quantity");
            entity.Property(e => e.OderStockId).HasColumnName("oder_stock_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.OderStock).WithMany(p => p.TblorderStockProducts)
                .HasForeignKey(d => d.OderStockId)
                .HasConstraintName("fkosid");

            entity.HasOne(d => d.Product).WithMany(p => p.TblorderStockProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fkopid");
        });

        modelBuilder.Entity<Tblproduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__tblprodu__47027DF544241D90");

            entity.ToTable("tblproducts");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.ProductName)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.SellingRate).HasColumnName("selling_rate");
            entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");
            entity.Property(e => e.Tax).HasColumnName("tax");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Subcategory).WithMany(p => p.Tblproducts)
                .HasForeignKey(d => d.SubcategoryId)
                .HasConstraintName("fksupid");

            entity.HasOne(d => d.Unit).WithMany(p => p.Tblproducts)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("fkunid");

            entity.HasOne(d => d.User).WithMany(p => p.Tblproducts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkppidd");
        });

        modelBuilder.Entity<TblrecivedStock>(entity =>
        {
            entity.HasKey(e => e.RecivedStockId).HasName("PK__tblreciv__830E812E138C0AF8");

            entity.ToTable("tblrecived_stock");

            entity.Property(e => e.RecivedStockId).HasColumnName("Recived_Stock_id");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.RecivedDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("recived_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VenderId).HasColumnName("vender_id");

            entity.HasOne(d => d.User).WithMany(p => p.TblrecivedStocks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkreuid");

            entity.HasOne(d => d.Vender).WithMany(p => p.TblrecivedStocks)
                .HasForeignKey(d => d.VenderId)
                .HasConstraintName("fkrevid");
        });

        modelBuilder.Entity<TblrecivedStockProduct>(entity =>
        {
            entity.HasKey(e => e.RecivedStockProductsId).HasName("PK__tblreciv__44347E7416E7B500");

            entity.ToTable("tblrecived_stock_products");

            entity.Property(e => e.RecivedStockProductsId).HasColumnName("recived_stock_products_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.RecivedProductQuantity).HasColumnName("recived_product_quantity");
            entity.Property(e => e.RecivedProductRate).HasColumnName("recived_product_rate");
            entity.Property(e => e.RecivedStockId).HasColumnName("recived_stock_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.TblrecivedStockProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fkrsp");

            entity.HasOne(d => d.RecivedStock).WithMany(p => p.TblrecivedStockProducts)
                .HasForeignKey(d => d.RecivedStockId)
                .HasConstraintName("fkrecid");

            entity.HasOne(d => d.User).WithMany(p => p.TblrecivedStockProducts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkppuuidd");
        });

        modelBuilder.Entity<Tblstate>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__tblstate__81A47417423FECC2");

            entity.ToTable("tblstate");

            entity.Property(e => e.StateId)
                .ValueGeneratedNever()
                .HasColumnName("state_id");
            entity.Property(e => e.StateName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("state_name");
        });

        modelBuilder.Entity<Tblsubcategory>(entity =>
        {
            entity.HasKey(e => e.SubcategoryId).HasName("PK__tblsubca__F7A5CC26F43806E2");

            entity.ToTable("tblsubcategory");

            entity.Property(e => e.SubcategoryId).HasColumnName("subcategory_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.Subcategory)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("subcategory");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Tblsubcategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fkcaid");

            entity.HasOne(d => d.User).WithMany(p => p.Tblsubcategories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkscuid");
        });

        modelBuilder.Entity<Tblunit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__tblunits__D3AF5BD795A433B2");

            entity.ToTable("tblunits");

            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.UnitName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("unit_name");
        });

        modelBuilder.Entity<Tbluser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tbluser__B9BE370F50B8FC5C");

            entity.ToTable("tbluser");

            entity.HasIndex(e => e.UniqueCode, "UQ__tbluser__8E12EA408BF37591").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email_address");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mobile_number");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UniqueCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("unique_code");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPhoto)
                .IsUnicode(false)
                .HasColumnName("user_photo");

            entity.HasOne(d => d.Location).WithMany(p => p.Tblusers)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("fklid");
        });

        modelBuilder.Entity<Tblvender>(entity =>
        {
            entity.HasKey(e => e.VenderId).HasName("PK__tblvende__881C032CB48BA3FD");

            entity.ToTable("tblvenders");

            entity.Property(e => e.VenderId).HasColumnName("vender_id");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Email_address");
            entity.Property(e => e.Flag)
                .HasDefaultValueSql("((0))")
                .HasColumnName("flag");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mobile_no");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VenderName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vender_name");

            entity.HasOne(d => d.User).WithMany(p => p.Tblvenders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fkvuid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
