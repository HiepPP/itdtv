using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ssc.consulting.switchboard.Models;
using ssc.consulting.switchboard.Repositories;

namespace ssc.consulting.switchboard.Services
{
    public class NewsService : BaseService<News>, INewsService
    {
        private readonly INewsRepository _iRepository = new NewsRepository();
        public IEnumerable<News> GetListNewsByChildCategories(Guid childCategoryId)
        {
            return _iRepository.GetListNewsByChildCategories(childCategoryId);
        }

        public IEnumerable<News> GetListNewsByMainCategories(Guid mainCategoryId)
        {
            return _iRepository.GetListNewsByMainCategories(mainCategoryId);
        }

        public bool IsExistSeoName(string seoname)
        {
            return _iRepository.IsExistSeoName(seoname);
        }

        public News GetNewsBySeoName(string seoname)
        {
            return _iRepository.GetNewsBySeoName(seoname);
        }

        public IEnumerable<News> GetSearch(string key)
        {
            return _iRepository.GetSearch(key);
        }
    }
}