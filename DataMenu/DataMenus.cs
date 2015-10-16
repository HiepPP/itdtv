using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ssc.consulting.switchboard.ViewModels;

namespace ssc.consulting.switchboard.DataMenu
{
    public static class DataMenus
    {
        public static IEnumerable<MenuAdminViewModel> GetListMenuAdmin()
        {
            var listresult = new List<MenuAdminViewModel>
            {
                new MenuAdminViewModel
                {
                    MenuRoot = MenuRoot.MainCategory,
                    Url = "/Admin/MainCategory",
                    Name = "Danh sách Đối tác",
                    CodeMenu = "MainCategory"
                },
                new MenuAdminViewModel
                {
                    MenuRoot = MenuRoot.MainCategory,
                    Url = "/Admin/MainCategory/Credit",
                    Name = "Tạo mới Đối tác",
                    CodeMenu = "MainCategory"
                },
                new MenuAdminViewModel
                {
                    MenuRoot = MenuRoot.ChildCategory,
                    Url = "/Admin/ChildCategory",
                    Name = "Danh sách Đối tượng",
                    CodeMenu = "ChildCategory"
                },
                new MenuAdminViewModel
                {
                    MenuRoot = MenuRoot.ChildCategory,
                    Url = "/Admin/ChildCategory/Credit",
                    Name = "Tạo mới đối tượng",
                    CodeMenu = "ChildCategory"
                },
                new MenuAdminViewModel
                {
                    MenuRoot = MenuRoot.Hotline,
                    Url = "/Admin/Hotline",
                    Name = "Danh sách HotLine",
                    CodeMenu = "Hotline"
                },
                new MenuAdminViewModel
                {
                    MenuRoot = MenuRoot.Hotline,
                    Url = "/Admin/Hotline/Credit",
                    Name = "Tạo mới HotLine",
                    CodeMenu = "Hotline"
                },
                new MenuAdminViewModel
                {
                    MenuRoot = MenuRoot.Banner,
                    Url = "/Admin/Banner",
                    Name = "Danh sách Banner",
                    CodeMenu = "Banner"
                },
                new MenuAdminViewModel
                {
                    MenuRoot = MenuRoot.Banner,
                    Url = "/Admin/Banner/Credit",
                    Name = "Tạo mới Banner",
                    CodeMenu = "Banner"
                },
                new MenuAdminViewModel
                {
                    MenuRoot = MenuRoot.News,
                    Url = "/Admin/News",
                    Name = "Danh sách Tin tức",
                    CodeMenu = "News"
                },
                new MenuAdminViewModel
                {
                    MenuRoot = MenuRoot.News,
                    Url = "/Admin/News/Credit",
                    Name = "Tạo mới Tin tức",
                    CodeMenu = "News"
                }
            };
            return listresult.AsEnumerable();
        }
    }
}