using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PubsDataAPI.Models;
using System.Reflection.Metadata;

namespace PubsDataAPI.DbContexts
{
    public partial class PubsDbContext : DbContext
    {
        private string connectionString = Environment.GetEnvironmentVariable("DBCONNECTIONSTRING");
        public PubsDbContext(DbContextOptions<PubsDbContext> options) : base(options) { }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            try
            {
                if (!dbContextOptionsBuilder.IsConfigured)
                {
                    dbContextOptionsBuilder.UseSqlServer(connectionString, o => o.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds));
                }
            }
            catch
            {
                throw;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(e =>
            {
                e.ToTable("authors", "dbo").HasKey(k => k.Id);

                e.Property(p => p.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("au_id");

                e.Property(p => p.LastName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("au_lname");

                e.Property(p => p.FirstName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("au_fname");

                e.Property(p => p.Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("phone");

                e.Property(p => p.Address)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("address");

                e.Property(p => p.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");

                e.Property(p => p.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("state");

                e.Property(p => p.Zip)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("zip");

                e.Property(p => p.Contract)
                .HasColumnName("contract");

            });

            modelBuilder.Entity<Publisher>(e =>
            {
                e.ToTable("publishers", "dbo").HasKey(k => k.Id);

                e.Property(p => p.Id)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("pub_id");

                e.Property(p => p.Name)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("pub_name");

                e.Property(p => p.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");

                e.Property(p => p.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("state");

                e.Property(p => p.Country)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("country");

            });

            //modelBuilder.Entity<Publisher>()
            //    .HasMany<Title>(t => t.Titles)
            //    .WithOne(p => p.Publisher)
            //    .HasForeignKey(p => p.PublisherId);


            modelBuilder.Entity<Title>(e =>
            {
                e.ToTable("titles", "dbo").HasKey(k => k.Id);
                

                e.Property(p => p.Id)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("title_id");

                e.Property(p => p.Name)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("title");

                e.Property(p => p.Type)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("type");

                e.Property(p => p.Price)
                .HasColumnName("price");

                e.Property(p => p.Advance)
                .HasColumnName("advance");

                e.Property(p => p.Royalty)
                .HasColumnName("royalty");

                e.Property(p => p.YTDSales)
                .HasColumnName("ytd_sales");

                e.Property(p => p.Notes)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("notes");

                e.Property(p => p.PublishedDate)
                .HasColumnName("pubdate");

                e.Property(p => p.PublisherId)
                .HasColumnName("pub_id");

                e.HasOne<Publisher>(t => t.Publisher).WithMany().HasForeignKey(p => p.PublisherId);

            });







            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
