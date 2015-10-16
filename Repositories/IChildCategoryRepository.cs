using System.Collections.Generic;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.Repositories
{
    public interface IChildCategoryRepository : IBaseRepository<ChildCategory>
    {
        bool IsExistSeoName(string seoname);
        ChildCategory GetChildCategoryBySeoName(string seoname);
    }
}
