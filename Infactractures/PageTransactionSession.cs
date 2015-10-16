using System.Web;

namespace ssc.consulting.switchboard.Infactractures
{
    public class PageTransactionSession
    {
        /// <summary>
        /// Status transaction. 1 : Success. 2 . Fail 
        /// </summary>
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }

    public static class SessionUserHelper
    {
        public static void CreateSessionError(string error)
        {
            HttpContext.Current.Session["PageTransaction"] = new PageTransactionSession
            {
                IsSuccess = false,
                Message = error
            };
        }

        public static void CreateSessionSuccess(string success)
        {
            HttpContext.Current.Session["PageTransaction"] = new PageTransactionSession
            {
                IsSuccess = true,
                Message = success
            };
        }
    }
}