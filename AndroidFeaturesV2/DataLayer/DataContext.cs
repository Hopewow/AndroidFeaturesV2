using AndroidFeaturesV2.Models;

namespace AndroidFeaturesV2.DataLayer
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<GeoLocation> GeoLocations { get; set; }
        public DbSet<QRCode> QRCodes { get; set; }
        public DbSet<ImageUpload> ImageUploads { get; set; }
    }
}
