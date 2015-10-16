using System.Data.Entity;
using ssc.consulting.switchboard.Models.Mapping;

namespace ssc.consulting.switchboard.Models
{
    public partial class SscContext : DbContext
    {
        static SscContext()
        {
            Database.SetInitializer<SscContext>(null);
        }

        public SscContext()
            : base("Name=SscContext")
        {

        }

        public DbSet<Banner> Banner { get; set; }
        public DbSet<ChildCategory> ChildCategory { get; set; }
        public DbSet<MainCategory> MainCategory { get; set; }
        public DbSet<HotLine> HotLine { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BannerMap());
            modelBuilder.Configurations.Add(new ChildCategoryMap());
            modelBuilder.Configurations.Add(new MainCategoryMap());
            modelBuilder.Configurations.Add(new HotLineMap());
            modelBuilder.Configurations.Add(new NewsMap());
        }
    }
}
