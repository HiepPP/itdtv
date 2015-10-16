using System;
using System.ComponentModel.DataAnnotations;

namespace ssc.consulting.switchboard.Models
{
    public class News : Base
    {
        [Required(ErrorMessage = "Không được để trống")]
        public Guid MainCategoryId { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public Guid ChildCategoryId { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        public string Description { get; set; }
        public string Contents { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [RegularExpression(@"^[a-zA-Z0-9-]+$", ErrorMessage = "Chỉ cho phép chứa những ký tự bình thường không dấu, không có khoảng trắng và không có ký tự đặc biệt (cho phép dùng ký tự '-')")]
        public string SeoName { get; set; }
    }
}
