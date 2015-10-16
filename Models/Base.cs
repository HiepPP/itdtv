using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ssc.consulting.switchboard.Models
{
    public class Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Vị trí phải là số tự nhiên và lớn hơn 0")]
        public int Position { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Base()
        {
            Created = DateTime.Now;
            IsDeleted = false;
        }
    }
}