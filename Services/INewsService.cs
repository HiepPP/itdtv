using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.Services
{
    public interface INewsService : IBaseService<News>
    {
        bool IsExistSeoName(string seoname);
        IEnumerable<News> GetListNewsByChildCategories(Guid childCategoryId);
        IEnumerable<News> GetListNewsByMainCategories(Guid mainCategoryId);
        News GetNewsBySeoName(string seoname);
        IEnumerable<News> GetSearch(string key);
    }
}
