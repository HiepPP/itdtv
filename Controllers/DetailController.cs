using ssc.consulting.switchboard.Services;
using ssc.consulting.switchboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ssc.consulting.switchboard.Controllers
{
    [RoutePrefix("")]
    public class DetailController : Controller
    {

        private readonly INewsService _iNewsService = new NewsService();
        private readonly IMainCategoryService _iMainCategoryService = new MainCategoryService();
        private readonly IChildCategoryService _iChildCategoryService = new ChildCategoryService();

        [Route("{seoname}")]
        public ActionResult Index(string seoname, int page = 1)
        {
            if (_iMainCategoryService.IsExistSeoName(seoname))
            {
                var main = _iMainCategoryService.GetMainCategoryBySeoName(seoname);
                var listresult = _iNewsService.GetListNewsByMainCategories(main.Id);
                var model = new MainCategoryHomeViewModel
                {
                    ListNews = listresult.Skip((page - 1) * 12).Take(12).ToList(),
                    TotalRecord = listresult.ToList().Count()
                };
                return PartialView("MainCategory", model);
            }
            if (_iChildCategoryService.IsExistSeoName(seoname))
            {
                var child = _iChildCategoryService.GetChildCategoryBySeoName(seoname);
                var listresult = _iNewsService.GetListNewsByChildCategories(child.Id);
                var model = new ChildCategoryHomeViewModel
                {
                    ListNews = listresult.Skip((page - 1) * 12).Take(12).ToList(),
                    TotalRecord = listresult.ToList().Count()
                };
                return PartialView("ChildCategory", model);
            }
            if (_iNewsService.IsExistSeoName(seoname))
            {
                var model = _iNewsService.GetNewsBySeoName(seoname);

                return PartialView("News", model);
            }
            return RedirectToAction("Index","Home");
        }
	}
}