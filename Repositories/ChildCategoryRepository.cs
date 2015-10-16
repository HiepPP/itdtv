using System;
using System.Collections.Generic;
using System.Linq;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.Repositories
{
    public class ChildCategoryRepository : BaseRepository<ChildCategory>, IChildCategoryRepository
    {
        public bool IsExistSeoName(string seoname)
        {
            try
            {
                using (var context = new SscContext())
                {
                    var result = (from item in context.ChildCategory
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

        public ChildCategory GetChildCategoryBySeoName(string seoname)
        {
            try
            {
                using(var context = new SscContext())
                {
                    var result = context.ChildCategory.FirstOrDefault(x => x.SeoName == seoname);
                    if (result == null)
                        return null;
                    return result;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}