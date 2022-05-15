using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Pharmavite_Saja.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FinReport> FinReports { get; set; }
        public virtual DbSet<PharmativeContact> PharmativeContacts { get; set; }
        public virtual DbSet<PharmativeUserContact> PharmativeUserContacts { get; set; }
        public virtual DbSet<PharmaviteAbouteU> PharmaviteAbouteUs { get; set; }
        public virtual DbSet<PharmaviteCard> PharmaviteCards { get; set; }
        public virtual DbSet<PharmaviteCategory> PharmaviteCategories { get; set; }
        public virtual DbSet<PharmaviteOrder> PharmaviteOrders { get; set; }
        public virtual DbSet<PharmaviteProduct> PharmaviteProducts { get; set; }
        public virtual DbSet<PharmaviteProductCart> PharmaviteProductCarts { get; set; }
        public virtual DbSet<PharmaviteReviw> PharmaviteReviws { get; set; }
        public virtual DbSet<PharmaviteRole> PharmaviteRoles { get; set; }
        public virtual DbSet<PharmaviteTestimonial> PharmaviteTestimonials { get; set; }
        public virtual DbSet<PharmaviteUser> PharmaviteUsers { get; set; }
        public virtual DbSet<PharmaviteWebsite> PharmaviteWebsites { get; set; }
        public object FinReport { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=TAH10_USER118;PASSWORD=saja123;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAH10_USER118")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<FinReport>(entity =>
            {
                entity.HasKey(e => e.RId)
                    .HasName("FIN_REPORT_PK");

                entity.ToTable("FIN_REPORT");

                entity.Property(e => e.RId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("R_ID");

                entity.Property(e => e.Deleverddate)
                    .HasColumnType("DATE")
                    .HasColumnName("DELEVERDDATE");

                entity.Property(e => e.OrderIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_IDFK");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("DATE")
                    .HasColumnName("ORDERDATE");

                entity.Property(e => e.ProductIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_IDFK");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.ProductOrderQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_ORDER_QTY");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_PRICE");

                entity.HasOne(d => d.OrderIdfkNavigation)
                    .WithMany(p => p.FinReports)
                    .HasForeignKey(d => d.OrderIdfk)
                    .HasConstraintName("ORDERFK");

                entity.HasOne(d => d.ProductIdfkNavigation)
                    .WithMany(p => p.FinReports)
                    .HasForeignKey(d => d.ProductIdfk)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("PRODUCTFK");
            });

            modelBuilder.Entity<PharmativeContact>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("SYS_C00118894");

                entity.ToTable("PHARMATIVE_CONTACT");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FbAccaunt)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FB_ACCAUNT");

                entity.Property(e => e.InstaAccaunt)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("INSTA_ACCAUNT");

                entity.Property(e => e.LiAccaunt)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LI_ACCAUNT");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.WebsiteIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WEBSITE_IDFK");

                entity.HasOne(d => d.WebsiteIdfkNavigation)
                    .WithMany(p => p.PharmativeContacts)
                    .HasForeignKey(d => d.WebsiteIdfk)
                    .HasConstraintName("SYS_C00118895");
            });

            modelBuilder.Entity<PharmativeUserContact>(entity =>
            {
                entity.HasKey(e => e.UserContactId)
                    .HasName("SYS_C00118857");

                entity.ToTable("PHARMATIVE_USER_CONTACT");

                entity.Property(e => e.UserContactId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_CONTACT_ID");

                entity.Property(e => e.ContactMsg)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CONTACT_MSG");

                entity.Property(e => e.UserIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_IDFK");

                entity.HasOne(d => d.UserIdfkNavigation)
                    .WithMany(p => p.PharmativeUserContacts)
                    .HasForeignKey(d => d.UserIdfk)
                    .HasConstraintName("SYS_C00118858");
            });

            modelBuilder.Entity<PharmaviteAbouteU>(entity =>
            {
                entity.HasKey(e => e.AbouteId)
                    .HasName("SYS_C00118892");

                entity.ToTable("PHARMAVITE_ABOUTE_US");

                entity.Property(e => e.AbouteId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUTE_ID");

                entity.Property(e => e.Aboute1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ABOUTE1");

                entity.Property(e => e.Aboute2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ABOUTE2");

                entity.Property(e => e.WebsiteIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WEBSITE_IDFK");

                entity.HasOne(d => d.WebsiteIdfkNavigation)
                    .WithMany(p => p.PharmaviteAbouteUs)
                    .HasForeignKey(d => d.WebsiteIdfk)
                    .HasConstraintName("SYS_C00118893");
            });

            modelBuilder.Entity<PharmaviteCard>(entity =>
            {
                entity.HasKey(e => e.CreditCardid)
                    .HasName("SYS_C00118917");

                entity.ToTable("PHARMAVITE_CARD");

                entity.Property(e => e.CreditCardid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CREDIT_CARDID");

                entity.Property(e => e.Balanc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANC");

                entity.Property(e => e.Cardnumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Ccb)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CCB");

                entity.Property(e => e.ExpDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXP_DATE");

                entity.Property(e => e.UserIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_IDFK");

                entity.HasOne(d => d.UserIdfkNavigation)
                    .WithMany(p => p.PharmaviteCards)
                    .HasForeignKey(d => d.UserIdfk)
                    .HasConstraintName("SYS_C00118918");
            });

            modelBuilder.Entity<PharmaviteCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("SYS_C00115975");

                entity.ToTable("PHARMAVITE_CATEGORY");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryImg)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_IMG");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");
            });

            modelBuilder.Entity<PharmaviteOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("SYS_C00118869");

                entity.ToTable("PHARMAVITE_ORDER");

                entity.Property(e => e.OrderId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.DeleverdDate)
                    .HasColumnType("DATE")
                    .HasColumnName("DELEVERD_DATE");

                entity.Property(e => e.OrderStartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ORDER_START_DATE");

                entity.Property(e => e.ProductQty)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_QTY");

                entity.Property(e => e.ProductStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_STATUS");

                entity.Property(e => e.UserIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_IDFK");

                entity.HasOne(d => d.UserIdfkNavigation)
                    .WithMany(p => p.PharmaviteOrders)
                    .HasForeignKey(d => d.UserIdfk)
                    .HasConstraintName("SYS_C00118870");
            });

            modelBuilder.Entity<PharmaviteProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("SYS_C00118866");

                entity.ToTable("PHARMAVITE_PRODUCT");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.CategoryIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_IDFK");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_FROM");

                entity.Property(e => e.DateTo)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_TO");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProductDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_DESC");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.ProductQuantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_QUANTITY");

                entity.Property(e => e.Productimg)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTIMG");

                entity.HasOne(d => d.CategoryIdfkNavigation)
                    .WithMany(p => p.PharmaviteProducts)
                    .HasForeignKey(d => d.CategoryIdfk)
                    .HasConstraintName("SYS_C00118867");
            });

            modelBuilder.Entity<PharmaviteProductCart>(entity =>
            {
                entity.HasKey(e => e.ProductCartId)
                    .HasName("SYS_C00118872");

                entity.ToTable("PHARMAVITE_PRODUCT_CART");

                entity.Property(e => e.ProductCartId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_CART_ID");

                entity.Property(e => e.OrderIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_IDFK");

                entity.Property(e => e.ProductIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_IDFK");

                entity.HasOne(d => d.OrderIdfkNavigation)
                    .WithMany(p => p.PharmaviteProductCarts)
                    .HasForeignKey(d => d.OrderIdfk)
                    .HasConstraintName("SYS_C00118874");

                entity.HasOne(d => d.ProductIdfkNavigation)
                    .WithMany(p => p.PharmaviteProductCarts)
                    .HasForeignKey(d => d.ProductIdfk)
                    .HasConstraintName("SYS_C00118873");
            });

            modelBuilder.Entity<PharmaviteReviw>(entity =>
            {
                entity.HasKey(e => e.ReviwId)
                    .HasName("SYS_C00118886");

                entity.ToTable("PHARMAVITE_REVIW");

                entity.Property(e => e.ReviwId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REVIW_ID");

                entity.Property(e => e.Reviw)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REVIW");

                entity.Property(e => e.WebsiteIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WEBSITE_IDFK");

                entity.HasOne(d => d.WebsiteIdfkNavigation)
                    .WithMany(p => p.PharmaviteReviws)
                    .HasForeignKey(d => d.WebsiteIdfk)
                    .HasConstraintName("SYS_C00118887");
            });

            modelBuilder.Entity<PharmaviteRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("SYS_C00115878");

                entity.ToTable("PHARMAVITE_ROLE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_DESC");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<PharmaviteTestimonial>(entity =>
            {
                entity.HasKey(e => e.TestimonialId)
                    .HasName("SYS_C00118889");

                entity.ToTable("PHARMAVITE_TESTIMONIAL");

                entity.Property(e => e.TestimonialId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIAL_ID");

                entity.Property(e => e.Img)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMG");

                entity.Property(e => e.ReviwMsg)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("REVIW_MSG");

                entity.Property(e => e.WebsiteIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WEBSITE_IDFK");

                entity.HasOne(d => d.WebsiteIdfkNavigation)
                    .WithMany(p => p.PharmaviteTestimonials)
                    .HasForeignKey(d => d.WebsiteIdfk)
                    .HasConstraintName("SYS_C00118890");
            });

            modelBuilder.Entity<PharmaviteUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("SYS_C00118847");

                entity.ToTable("PHARMAVITE_USERS");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Bod)
                    .HasColumnType("DATE")
                    .HasColumnName("BOD");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Img)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMG");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleIdfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_IDFK");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.HasOne(d => d.RoleIdfkNavigation)
                    .WithMany(p => p.PharmaviteUsers)
                    .HasForeignKey(d => d.RoleIdfk)
                    .HasConstraintName("SYS_C00118848");
            });

            modelBuilder.Entity<PharmaviteWebsite>(entity =>
            {
                entity.HasKey(e => e.IdPharmavite)
                    .HasName("SYS_C00118850");

                entity.ToTable("PHARMAVITE_WEBSITE");

                entity.Property(e => e.IdPharmavite)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_PHARMAVITE");

                entity.Property(e => e.UserAdminfk)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ADMINFK");

                entity.Property(e => e.WebsiteDesc)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE_DESC");

                entity.Property(e => e.WebsiteHeroimg)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE_HEROIMG");

                entity.Property(e => e.WebsiteHeroimg2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE_HEROIMG2");

                entity.Property(e => e.WebsiteHeroimg3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE_HEROIMG3");

                entity.Property(e => e.WebsiteLogo1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE_LOGO1");

                entity.Property(e => e.WebsiteLogo2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE_LOGO2");

                entity.Property(e => e.WebsiteName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WEBSITE_NAME");

                entity.Property(e => e.WebsiteWallet)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WEBSITE_WALLET");

                entity.HasOne(d => d.UserAdminfkNavigation)
                    .WithMany(p => p.PharmaviteWebsites)
                    .HasForeignKey(d => d.UserAdminfk)
                    .HasConstraintName("SYS_C00118851");
            });

            modelBuilder.HasSequence("DEPARTMENT_ID");

            modelBuilder.HasSequence("TASK1_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
