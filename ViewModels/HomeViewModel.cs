using System.Collections.Generic;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<News> ListNews { get; set; }
    }

    public class MainCategoryHomeViewModel
    {
        public IEnumerable<News> ListNews { get; set; }
        public int TotalRecord { get; set; }
    }

    public class ChildCategoryHomeViewModel
    {
        public IEnumerable<News> ListNews { get; set; }
        public int TotalRecord { get; set; }
    }

    public class SearchViewModel
    {
        public IEnumerable<News> ListNews { get; set; }
        public int TotalRecord { get; set; }
    }
}