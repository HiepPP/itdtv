using System.Web.Configuration;

namespace ssc.consulting.switchboard.Infactractures
{
    public static class SerialNumber
    {
        private static readonly int Rowsdisplay = int.Parse(WebConfigurationManager.AppSettings["rowsdisplay"].ToString());
        public static int CurrentIndex(int page)
        {
            return (Rowsdisplay * (page - 1)) + 1;
        }
    }
}