using System.Collections.Generic;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.Repositories
{
    public interface IBannerRepository : IBaseRepository<Banner>
    {
        IEnumerable<Banner> GetBannersForDisplay();
    }
}
