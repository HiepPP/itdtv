using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ssc.consulting.switchboard.Models;
using ssc.consulting.switchboard.Repositories;

namespace ssc.consulting.switchboard.Services
{
    public class ChildCategoryService : BaseService<ChildCategory>, IChildCategoryService
    {
        private readonly IChildCategoryRepository _iRepository = new ChildCategoryRepository();
        public bool IsExistSeoName(string seoname)
        {
            return _iRepository.IsExistSeoName(seoname);
        }

        public ChildCategory GetChildCategoryBySeoName(string seoname)
        {
            return _iRepository.GetChildCategoryBySeoName(seoname);
        }
    }
}