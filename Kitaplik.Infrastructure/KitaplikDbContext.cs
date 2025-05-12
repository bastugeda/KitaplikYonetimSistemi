using Kitaplik.Domain;
using Kitaplik.Domain;
using Microsoft.EntityFrameworkCore;
using Kitaplik.Domain.Entities;


namespace Kitaplik.Infrastructure
{
    public class KitaplikDbContext : DbContext
    {
        public KitaplikDbContext(DbContextOptions<KitaplikDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
