using System;
using System.Globalization;
using System.Linq;

namespace WcfServiceDateTime.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceDateTime : IServiceDateTime
    {
        public string GetDayOfWeek(DateTime date)
        {
            CultureInfo bulgarian = new CultureInfo("bg-BG");
            string dayOfWeek = bulgarian.DateTimeFormat.GetDayName(date.DayOfWeek);

            return dayOfWeek;
        }
    }
}
