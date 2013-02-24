using System;
using System.Linq;

namespace MobilePhoneDevice
{
    class Program
    {
        static void Main()
        {
            //uncomment first 3 lines and
            //comment next 7 lines to test GSM info

            //GSMTest test = new GSMTest();
            //test.ShowResult();
            //test.ShowIPhone();

            GSMCallHistoryTest testCalls = new GSMCallHistoryTest();
            testCalls.ShowResult();
            testCalls.PriceOfCalls();
            testCalls.RemoveLongestCall();
            testCalls.PriceOfCalls();
            testCalls.ClearCallHistory();
            testCalls.ShowResult();
        }
    }
}
