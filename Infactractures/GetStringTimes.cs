using System;

namespace ssc.consulting.switchboard.Infactractures
{
    public static class GetStringTimes
    {
       public static string GetTimes(DateTime input)
        {
            var str = String.Format("{0:d-M-yyyy HH-mm-ss}", input).Replace(" ", "-") + "-";
            return string.Format("{0}{1}", str, input.Millisecond.ToString());
        }
    }
}