using System.Collections.Generic;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.ViewModels
{
    public class MainCategoryViewModel
    {
        public IEnumerable<MainCategory> ListShow { get; set; }

        public int TotalRecord { get; set; }
    }
}