using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.ViewModels
{
    public class ChildCategoryViewModel
    {
        public IEnumerable<ChildCategory> ListShow { get; set; }

        public int TotalRecord { get; set; }
    }
}