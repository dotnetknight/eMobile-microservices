using eMobile.Phones.Domain.DimensionsEntity;
using eMobile.Phones.Domain.DisplayEntity;
using eMobile.Phones.Domain.MediaEntity;
using eMobile.Phones.Domain.PhonesEntity;
using Microsoft.EntityFrameworkCore;

namespace eMobile.Phones.Repository
{
    public class PhonesContext : DbContext
    {
        public PhonesContext(DbContextOptions<PhonesContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new PhoneMap(modelBuilder.Entity<Phone>());
            new DisplayMap(modelBuilder.Entity<Display>());
            new DimensionsMap(modelBuilder.Entity<Dimensions>());
            new MediaMap(modelBuilder.Entity<Media>());
        }
    }
}
