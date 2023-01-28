using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PresaleApi.DataBaseEntity;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PresaleApi
{
    public partial class PresaleContext : DbContext
    {
        public PresaleContext()
        {
        }

        public PresaleContext(DbContextOptions<PresaleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Bedroom> Bedroom { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Cms> Cms { get; set; }
        public virtual DbSet<CompletionYear> CompletionYear { get; set; }
        public virtual DbSet<ConstructionType> ConstructionType { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Developer> Developer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<ImageDump> ImageDump { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MarketingCompany> MarketingCompany { get; set; }
        public virtual DbSet<NearBy> NearBy { get; set; }
        public virtual DbSet<PrimaryProductImageView> PrimaryProductImageView { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductBedroomMapping> ProductBedroomMapping { get; set; }
        public virtual DbSet<ProductBedroomMappingView> ProductBedroomMappingView { get; set; }
        public virtual DbSet<ProductCategoryMapping> ProductCategoryMapping { get; set; }
        public virtual DbSet<ProductConstructionTypeMapping> ProductConstructionTypeMapping { get; set; }
        public virtual DbSet<ProductConstructionTypeMappingView> ProductConstructionTypeMappingView { get; set; }
        public virtual DbSet<ProductDeveloperMapping> ProductDeveloperMapping { get; set; }
        public virtual DbSet<ProductDeveloperMappingView> ProductDeveloperMappingView { get; set; }
        public virtual DbSet<ProductFeatureMapping> ProductFeatureMapping { get; set; }
        public virtual DbSet<ProductFeatureMappingView> ProductFeatureMappingView { get; set; }
        public virtual DbSet<ProductInquiry> ProductInquiry { get; set; }
        public virtual DbSet<ProductMarketingCompanyMapping> ProductMarketingCompanyMapping { get; set; }
        public virtual DbSet<ProductMarketingCompanyMappingView> ProductMarketingCompanyMappingView { get; set; }
        public virtual DbSet<ProductNearByMapping> ProductNearByMapping { get; set; }
        public virtual DbSet<ProductNearByMappingView> ProductNearByMappingView { get; set; }
        public virtual DbSet<ProductPropertyTypeMapping> ProductPropertyTypeMapping { get; set; }
        public virtual DbSet<ProductPropertyTypeMappingView> ProductPropertyTypeMappingView { get; set; }
        public virtual DbSet<ProductRelatedMapping> ProductRelatedMapping { get; set; }
        public virtual DbSet<PropertyType> PropertyType { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<SubLocation> SubLocation { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<TeacherView> TeacherView { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Testimonial> Testimonial { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ViewUrl> ViewUrl { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<WorkersView> WorkersView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-VF6GA3A;Database=Presale;User ID=sa;Password=123456;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Bedroom>(entity =>
            {
                entity.Property(e => e.BedroomName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MetaDescription).HasMaxLength(400);

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Cms>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CmsId).ValueGeneratedOnAdd();

                entity.Property(e => e.CmsName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.CmsTitle)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CompletionYear>(entity =>
            {
                entity.Property(e => e.CompletionYear1)
                    .IsRequired()
                    .HasColumnName("CompletionYear")
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ConstructionType>(entity =>
            {
                entity.Property(e => e.ConstructionTypeName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ContactUs>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(220)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeveloperName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.Gender).HasMaxLength(6);

                entity.Property(e => e.LastName)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FeatureName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ImageDump>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK_tbl_Image_Dump");

                entity.ToTable("Image_Dump");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FolderName)
                    .HasColumnName("Folder_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.ImageActualFileName)
                    .HasColumnName("Image_Actual_File_Name")
                    .HasMaxLength(150);

                entity.Property(e => e.ImageFileName)
                    .HasColumnName("Image_File_Name")
                    .HasMaxLength(150);

                entity.Property(e => e.MaterId).HasColumnName("MaterID");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<MarketingCompany>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.MarketingCompanyName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<NearBy>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.NearByName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<PrimaryProductImageView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PrimaryProductImageView");

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FolderName)
                    .HasColumnName("Folder_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.ImageActualFileName)
                    .HasColumnName("Image_Actual_File_Name")
                    .HasMaxLength(150);

                entity.Property(e => e.ImageFileName)
                    .HasColumnName("Image_File_Name")
                    .HasMaxLength(150);

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.MaterId).HasColumnName("MaterID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.GoogleAddressIfram).HasMaxLength(500);

                entity.Property(e => e.MetaDescription).HasMaxLength(400);

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.NewPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OldPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductName).HasMaxLength(400);

                entity.Property(e => e.ShortDescription).HasMaxLength(400);

                entity.Property(e => e.SubName).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<ProductBedroomMapping>(entity =>
            {
                entity.HasOne(d => d.Bedroom)
                    .WithMany(p => p.ProductBedroomMapping)
                    .HasForeignKey(d => d.BedroomId)
                    .HasConstraintName("FK__ProductBe__Bedro__6C190EBB");
            });

            modelBuilder.Entity<ProductBedroomMappingView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductBedroomMappingView");

                entity.Property(e => e.BedroomName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ProductCategoryMapping>(entity =>
            {
                entity.HasKey(e => e.ProductCategoryId)
                    .HasName("PK_tbl_Product_Category_Mapping");

                entity.HasIndex(e => e.ProductCategoryId)
                    .HasName("UQ__tbl_Produ__3224ECEF47DBAE45")
                    .IsUnique();

                entity.Property(e => e.DisplayOrder).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ProductConstructionTypeMapping>(entity =>
            {
                entity.HasOne(d => d.ConstructionType)
                    .WithMany(p => p.ProductConstructionTypeMapping)
                    .HasForeignKey(d => d.ConstructionTypeId)
                    .HasConstraintName("FK__ProductCo__Const__6D0D32F4");
            });

            modelBuilder.Entity<ProductConstructionTypeMappingView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductConstructionTypeMappingView");

                entity.Property(e => e.ConstructionTypeName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ProductDeveloperMapping>(entity =>
            {
                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.ProductDeveloperMapping)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK__ProductDe__Devel__6E01572D");
            });

            modelBuilder.Entity<ProductDeveloperMappingView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductDeveloperMappingView");

                entity.Property(e => e.DeveloperName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ProductFeatureMapping>(entity =>
            {
                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.ProductFeatureMapping)
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK__ProductFe__Featu__6EF57B66");
            });

            modelBuilder.Entity<ProductFeatureMappingView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductFeatureMappingView");

                entity.Property(e => e.FeatureName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ProductInquiry>(entity =>
            {
                entity.Property(e => e.Bedrooms).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PriceRange).HasMaxLength(100);
            });

            modelBuilder.Entity<ProductMarketingCompanyMapping>(entity =>
            {
                entity.HasOne(d => d.MarketingCompany)
                    .WithMany(p => p.ProductMarketingCompanyMapping)
                    .HasForeignKey(d => d.MarketingCompanyId)
                    .HasConstraintName("FK__ProductMa__Marke__6FE99F9F");
            });

            modelBuilder.Entity<ProductMarketingCompanyMappingView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductMarketingCompanyMappingView");

                entity.Property(e => e.MarketingCompanyName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ProductNearByMapping>(entity =>
            {
                entity.HasOne(d => d.NearBy)
                    .WithMany(p => p.ProductNearByMapping)
                    .HasForeignKey(d => d.NearById)
                    .HasConstraintName("FK__ProductFe__Featu__0C85DE4D");
            });

            modelBuilder.Entity<ProductNearByMappingView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductNearByMappingView");

                entity.Property(e => e.NearByName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ProductPropertyTypeMapping>(entity =>
            {
                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.ProductPropertyTypeMapping)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .HasConstraintName("FK__ProductPr__Prope__71D1E811");
            });

            modelBuilder.Entity<ProductPropertyTypeMappingView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProductPropertyTypeMappingView");

                entity.Property(e => e.PropertyTypeName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.PropertyTypeName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(220)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(210)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(210)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SubLocation>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.SubLocationName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SubLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubLocati__Locat__65370702");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(220)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TeacherView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TeacherView");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastName)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectIds)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.StateIds)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");
            });
            modelBuilder.Entity<States>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(220)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<WorkersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WorkersView");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LastName)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.StateIds)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectIds)
                    .HasMaxLength(220)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.TestimonialId).ValueGeneratedOnAdd();

                entity.Property(e => e.TestimonialName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.TestimonialTitle)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C380BFF1A");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ViewUrl>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_URL");

                entity.Property(e => e.Controller)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MetaDescription).HasMaxLength(400);

                entity.Property(e => e.MetaKeywords).HasMaxLength(400);

                entity.Property(e => e.MetaTitle).HasMaxLength(400);

                entity.Property(e => e.Url).HasMaxLength(400);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
