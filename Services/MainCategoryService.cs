using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ssc.consulting.switchboard.Models;
using ssc.consulting.switchboard.Repositories;

namespace ssc.consulting.switchboard.Services
{
    public class MainCategoryService : BaseService<MainCategory>, IMainCategoryService
    {
        private readonly IMainCategoryRepository _iRepository = new MainCategoryRepository();
        public bool IsExistSeoName(string seoname)
        {
            return _iRepository.IsExistSeoName(seoname);
        }

        public MainCategory GetMainCategoryBySeoName(string seoname)
        {
            return _iRepository.GetMainCategoryBySeoName(seoname);
        }
    }
}