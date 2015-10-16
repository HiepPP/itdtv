using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.Services
{
    public interface IMainCategoryService : IBaseService<MainCategory>
    {
        bool IsExistSeoName(string seoname);
        MainCategory GetMainCategoryBySeoName(string seoname);
    }
}
