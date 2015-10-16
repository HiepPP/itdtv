using ssc.consulting.switchboard.Repositories;

namespace ssc.consulting.switchboard.Services
{
    public class SeoNameService
    {
        private readonly IMainCategoryService _iMainCategoryService = new MainCategoryService();
        private readonly IChildCategoryService _iChildCategoryRepository = new ChildCategoryService();
        private readonly INewsService _iNewsRepository = new NewsService();

        public bool CheckSeoName(string seoname)
        {
            if ((_iMainCategoryService.IsExistSeoName(seoname)))
                return true;
            if ((_iChildCategoryRepository.IsExistSeoName(seoname)))
                return true;
            if ((_iNewsRepository.IsExistSeoName(seoname)))
                return true;
            return false;
        }
    }
}