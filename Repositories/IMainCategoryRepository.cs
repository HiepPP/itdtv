using System.Collections.Generic;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.Repositories
{
    public interface IMainCategoryRepository : IBaseRepository<MainCategory>
    {
        bool IsExistSeoName(string seoname);
        MainCategory GetMainCategoryBySeoName(string seoname);
    }
}
