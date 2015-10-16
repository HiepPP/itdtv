using System.Data.Entity.ModelConfiguration;

namespace ssc.consulting.switchboard.Models.Mapping
{
    public class BannerMap : BaseMap<Banner>
    {
        public BannerMap() : base()
        {
            // Table & Column Mappings
            this.Property(t => t.ImageUrl).HasColumnName("ImageUrl");
        }
    }
}
