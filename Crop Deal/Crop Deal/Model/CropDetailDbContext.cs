using Crop_Deal.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal.Model
{
    public class CropDetailDbContext : DbContext
    {
        public CropDetailDbContext(DbContextOptions<CropDetailDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BankDetails> BankDetails { get; set; }

        public DbSet<CropDetails> CropDetails { get; set; }

        public DbSet<CropType> CropTypes { get; set; }

        public DbSet<Receipt> Receipt { get; set; }

        public DbSet<Subscribe> Subscribes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>()
                 .HasOne(r => r.FarmerUser)
                 .WithMany(u => u.FarmerName)
                 .HasForeignKey(r => r.FarmerId)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.DealerUser)
                .WithMany(u => u.DealerName)
                .HasForeignKey(r => r.DealerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique(true);

            modelBuilder.Entity<Receipt>()
                .HasOne(c => c.CropDetails)
                .WithMany(c => c.Receipt)
                .HasForeignKey(c=> c.CropId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }


    }
}
