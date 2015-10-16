using System.Data.Entity.ModelConfiguration;

namespace ssc.consulting.switchboard.Models.Mapping
{
    public class HotLineMap : BaseMap<HotLine>
    {
        public HotLineMap() : base()
        {
            // Properties
            this.Property(t => t.Phone).IsRequired();

            // Table & Column Mappings
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.ImageUrl).HasColumnName("ImageUrl");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
