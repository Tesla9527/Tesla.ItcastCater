using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.ItcastCater.CommonHelper
{
    public static class Util
    {
        public static DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        public static string GetCurrentFormattedTime()
        {
            string formattedDatetime = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            return formattedDatetime;
        }

        public static string GetFormattedTime(DateTime time)
        {
            return time.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        public static string GetTimeDifference(DateTime startTime, DateTime endTime)
        {
            string timeDifferenceDetailed = "";
            try
            {
                TimeSpan diffTime = endTime.Subtract(startTime);
                timeDifferenceDetailed = (diffTime.Minutes) + " minute(s), "
                                                + (diffTime.Seconds) + " seconds";
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);

            }
            return timeDifferenceDetailed;
        }
    }
}