using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Drawing;
using System.Reflection.Metadata;
using lab2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace lab2.Models
{
    public partial class CarDealershipContext : IdentityDbContext<User>
    {
        protected readonly IConfiguration Configuration;
        public CarDealershipContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public virtual DbSet<Accesouries> Accesouries { get; set; }
        public virtual DbSet<Administration> Administrator { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Construction> Construction { get; set; }
        public virtual DbSet<AutoModel> AutoModel { get; set; }
        public virtual DbSet<ModelRange> ModelRange { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder
       modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ModelRange>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });
            modelBuilder.Entity<AutoModel>(entity =>
            {
                entity.HasOne(d => d.Range)
                .WithMany(p => p.Models)
                .HasForeignKey(d => d.Id_modelrange);
            });


            modelBuilder.Entity<AutoModel>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });
            modelBuilder.Entity<Construction>(entity =>
            {
                entity.HasOne(d => d.AutoModel)
                .WithMany(p => p.Constructions)
                .HasForeignKey(d => d.Id_model);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });
            modelBuilder.Entity<Construction>(entity =>
            {
                entity.HasOne(d => d.Color)
                .WithMany(p => p.Constructions)
                .HasForeignKey(d => d.Id_colour);
            });

            modelBuilder.Entity<Construction>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Constructions)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.Id_constr);
            });



            modelBuilder.Entity<Accesouries>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Accesouries)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.Id_acc);
            });


            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasOne(d => d.Products)
                .WithMany(p => p.Purchases)
                .HasForeignKey(d => d.Id_product);
            });



            modelBuilder.Entity<Administration>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasOne(d => d.Administrators)
                .WithMany(p => p.Purchases)
                .HasForeignKey(d => d.Id_adm);
            });



            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
            });
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasOne(d => d.Clients)
                .WithMany(p => p.Purchases)
                .HasForeignKey(d => d.Id_client);
            });

        }



    }
}
