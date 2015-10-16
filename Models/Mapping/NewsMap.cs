using System.Data.Entity.ModelConfiguration;

namespace ssc.consulting.switchboard.Models.Mapping
{
    public class NewsMap : BaseMap<News>
    {
        public NewsMap() : base()
        {
            // Properties
            this.Property(t => t.Title).IsRequired();
            this.Property(t => t.SeoName).IsRequired();
            this.Property(t => t.MainCategoryId).IsRequired();
            this.Property(t => t.ChildCategoryId).IsRequired();

            // Table & Column Mappings
            this.Property(t => t.MainCategoryId).HasColumnName("MainCategoryId");
            this.Property(t => t.ChildCategoryId).HasColumnName("ChildCategoryId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Contents).HasColumnName("Contents");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.SeoName).HasColumnName("SeoName");
        }
    }
}
