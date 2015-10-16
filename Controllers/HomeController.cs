using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ssc.consulting.switchboard.Services;
using ssc.consulting.switchboard.ViewModels;

namespace ssc.consulting.switchboard.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        private readonly INewsService _iNewsService = new NewsService();
        
        [Route("")]
        public ActionResult Index()
        {
            var listresult = _iNewsService.GetListActive().Skip(0).Take(12).ToList();
            var model = new HomeViewModel
            {
                ListNews = listresult
            };
            return View(model);
        }

        [Route("tim-kiem")]
        [ValidateInput(false)]
        public ActionResult Search(string sort, string Key, int page = 1)
        {
            if (string.IsNullOrEmpty(Key))
                return RedirectToAction("Index", "Home");
            Key = Key.Trim().ToLower();
            var result = _iNewsService.GetSearch(Key).ToList();
            var model = new SearchViewModel
            {
                ListNews = result.Skip((page - 1) * 12).Take(12).ToList(),
                TotalRecord = result.ToList().Count()
            };
            return View(model);
        }
    }
}