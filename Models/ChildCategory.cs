using System;
using System.ComponentModel.DataAnnotations;

namespace ssc.consulting.switchboard.Models
{
    public class ChildCategory : Base
    {
        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [RegularExpression(@"^[a-zA-Z0-9-]+$", ErrorMessage = "Chỉ cho phép chứa những ký tự bình thường không dấu, không có khoảng trắng và không có ký tự đặc biệt (cho phép dùng ký tự '-')")]
        public string SeoName { get; set; }
        
    }
}
