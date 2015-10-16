using System.Collections.Generic;
using ssc.consulting.switchboard.Models;
using ssc.consulting.switchboard.Services;

namespace ssc.consulting.switchboard.ViewModels
{
    public class BannerDisplayViewModel
    {
        private readonly IBannerService _iService = new BannerService();
        public IEnumerable<Banner> ListBanners
        {
            get { return _iService.GetListActive(); }
        }
    }
    public class HotlineDisplayViewModel
    {
        private readonly IHotlineService _iService = new HotlineService();

        public IEnumerable<HotLine> ListHotLines
        {
            get { return _iService.GetListActive(); }
        }
    }

    public class MenuLeftViewModel
    {
        private readonly IMainCategoryService _iService = new MainCategoryService();

        public IEnumerable<MainCategory> ListMainCategories
        {
            get { return _iService.GetListActive(); }
        }
    }

    public class MenuContentViewModel
    {
        private readonly IChildCategoryService _iService = new ChildCategoryService();

        public IEnumerable<ChildCategory> LisChildCategories
        {
            get { return _iService.GetListActive(1, 6); }
        }
    }
}