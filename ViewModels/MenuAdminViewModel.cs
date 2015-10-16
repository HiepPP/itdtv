using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using ssc.consulting.switchboard.DataMenu;

namespace ssc.consulting.switchboard.ViewModels
{
    public enum MenuRoot
    {
        /// <summary>
        /// Quản lý Menu Đối tác
        /// </summary>
        [Description("Quản lý Menu Đối tác")]
        MainCategory = 0,
        /// <summary>
        /// Quản lý Menu Đối tượng
        /// </summary>
        [Description("Quản lý Menu Đối tượng")]
        ChildCategory = 1,
        /// <summary>
        /// Quản lý Danh sách Hotline
        /// </summary>
        [Description("Quản lý Hotline")]
        Hotline = 2,
        /// <summary>
        /// Quản lý Banner
        /// </summary>
        [Description("Quản lý Banner")]
        Banner = 3,
        /// <summary>
        /// Đã sắp xếp phòng thi
        /// </summary>
        [Description("Quản lý Tin tức")]
        News = 4
    }
    public class MenuAdminViewModel
    {
        public MenuRoot MenuRoot { get; set; }
        public string Name { get; set; }
        public string CodeMenu { get; set; }
        public string Url { get; set; }
    }

    public class ListMenuAdminViewModel
    {
        public IEnumerable<MenuAdminViewModel> ListMenu 
        {
            get { return DataMenus.GetListMenuAdmin(); }
        }
    }
}