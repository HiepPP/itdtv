using System;
using System.ComponentModel.DataAnnotations;

namespace ssc.consulting.switchboard.Models
{
    public class HotLine : Base
    {
        [Required(ErrorMessage = "Không được để trống")]
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
