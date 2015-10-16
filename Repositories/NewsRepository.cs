using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.Repositories
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        public IEnumerable<News> GetListNewsByChildCategories(Guid childCategoryId)
        {
            using (var context = new SscContext())
            {
                try
                {
                    return context.News.Where(c => c.IsActive == true && c.IsDeleted == false && c.ChildCategoryId == childCategoryId).ToList();
                }
                catch (Exception)
                {
                    return Enumerable.Empty<News>();
                }
            }
        }

        public IEnumerable<News> GetListNewsByMainCategories(Guid mainCategoryId)
        {
            using (var context = new SscContext())
            {
                try
                {
                    return context.News.Where(c => c.IsActive == true && c.IsDeleted == false && c.MainCategoryId == mainCategoryId).ToList();
                }
                catch (Exception)
                {
                    return Enumerable.Empty<News>();
                }
                
            }
        }

        public IEnumerable<News> GetSearch(string key)
        {
            using (var context = new SscContext())
            {
                try
                {
                    var list = (from pn in context.News.AsEnumerable()
                                where (pn.Title.Trim().ToLower().Contains(key.Trim().ToLower()) && pn.IsActive)
                                select pn).ToList();
                    return list;
                }
                catch (Exception)
                {
                    return Enumerable.Empty<News>();
                }
            }
        }

        public bool IsExistSeoName(string seoname)
        {
            try
            {
                using (var context = new SscContext())
                {
                    var result = (from item in context.News
                                  where item.SeoName.Trim().ToLower().Equals(seoname.Trim().ToLower()) && item.IsDeleted == false
                                  select item.SeoName).ToList();
                    if (result.Any())
                        return true;
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }

        public News GetNewsBySeoName(string seoname)
        {
            try
            {
                using (var context = new SscContext())
                {
                    var result = context.News.FirstOrDefault(x => x.SeoName == seoname);
                    if (result == null)
                        return null;
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}