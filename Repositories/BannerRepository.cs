using System;
using System.Collections.Generic;
using System.Linq;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.Repositories
{
    public class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public IEnumerable<Banner> GetBannersForDisplay()
        {
            using (var context = new SscContext())
            {
                return context.Banner.Where(c => c.IsActive == true && c.IsDeleted == false).ToList();
            }
        }
    }
}