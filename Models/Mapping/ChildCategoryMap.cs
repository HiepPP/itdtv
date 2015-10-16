using System.Data.Entity.ModelConfiguration;

namespace ssc.consulting.switchboard.Models.Mapping
{
    public class ChildCategoryMap : BaseMap<ChildCategory>
    {
        public ChildCategoryMap() : base()
        {

            // Properties
            this.Property(t => t.Name).IsRequired();
            this.Property(t => t.SeoName).IsRequired();

            // Table & Column Mappings
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SeoName).HasColumnName("SeoName");
        }
    }
}
