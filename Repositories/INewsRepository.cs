using System.Collections.Generic;
using ssc.consulting.switchboard.Models;
using System;

namespace ssc.consulting.switchboard.Repositories
{
    public interface INewsRepository : IBaseRepository<News>
    {
        bool IsExistSeoName(string seoname);
        News GetNewsBySeoName(string seoname);
        IEnumerable<News> GetListNewsByChildCategories(Guid childCategoryId);
        IEnumerable<News> GetListNewsByMainCategories(Guid mainCategoryId);
        IEnumerable<News> GetSearch(string key);
    }
}
