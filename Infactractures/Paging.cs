using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

namespace ssc.consulting.switchboard.Infactractures
{
    public static class Paging
    {
        
        //show paging 
        public static string Page(int pageindex, int totalrecord)
        {
            var myuri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            var pathquery = myuri.Query;
            var charracter = "?";
            if (pathquery != string.Empty)
            {
                var checkpathquery = "?page=" + pageindex;
                if (pathquery != checkpathquery)
                {
                    var words = Regex.Split(pathquery, "&page=");
                    pathquery = words[0];
                    charracter = "&";
                }
                else
                {
                    pathquery = string.Empty;
                }
            }

            var pagedisplay = int.Parse(WebConfigurationManager.AppSettings["pagedisplay"].ToString());
            var rowsdisplay = int.Parse(WebConfigurationManager.AppSettings["rowsdisplay"].ToString());

            var rawHtml = string.Empty;

            //get value page index
            var index = pageindex;
            //max count page
            var maxpage = totalrecord / rowsdisplay;
            if (totalrecord % rowsdisplay > 0)
                maxpage = maxpage + 1;

            if (maxpage <= 1) return rawHtml;
            rawHtml = "<ul class='pagination'>";
            //page start
            var start = (index / pagedisplay) * pagedisplay;
            if (start == 0)
                start = 1;

            //page end
            var end = start + pagedisplay;
            if (pageindex >= pagedisplay)
                end = end + 1;

            //page next
            //int next = index + 1;

            //page previous
            //int pre = index - 1;

            //show First page
            if (index > 1)
                rawHtml = rawHtml + string.Format("<li><a href='{0}{1}page=1'>«</a><li>", pathquery, charracter);

            //list page
            for (var i = start; i <= maxpage && i <= end; i++)
            {
                if (i == index)
                    rawHtml = rawHtml + string.Format("<li><a class='active' href='#'>{0}</a><li>", i);
                else
                    rawHtml = rawHtml + string.Format("<li><a href='{0}{1}page={2}'>{2}</a><li>", pathquery, charracter, i);
            }

            //show Last page
            if (index < maxpage)
                rawHtml = rawHtml + string.Format("<li><a href='{0}{1}page={2}'>»</a><li>", pathquery, charracter, maxpage);
            rawHtml += "</ul>";
            return rawHtml;
        }

    }
}