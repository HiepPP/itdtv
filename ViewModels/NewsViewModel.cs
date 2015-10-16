using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.ViewModels
{
    [NotMapped]
    public class NewsModel : News
    {
        public string MainCategoryName { get; set; }

        public string ChildCategoryName { get; set; }

        public IEnumerable<MainCategory> ListMainCategory { get; set; }
        public IEnumerable<ChildCategory> ListChildCategory { get; set; }
    }
    public class NewsViewModel
    {
        public IEnumerable<NewsModel> ListShow { get; set; }

        public int TotalRecord { get; set; }
    }
}