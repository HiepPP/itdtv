using System.Collections.Generic;
using ssc.consulting.switchboard.Models;

namespace ssc.consulting.switchboard.ViewModels
{
    public class BannerViewModel
    {
        public IEnumerable<Banner> ListShow { get; set; }

        public int TotalRecord { get; set; }
    }
}