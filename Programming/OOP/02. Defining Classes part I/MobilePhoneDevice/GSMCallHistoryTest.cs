using System;
using System.Linq;

namespace MobilePhoneDevice
{
    class GSMCallHistoryTest
    {
        //defining fields
        private readonly Battery battery1 = new Battery("Built-in rechargeable", BatteryTypes.LiIon);
        private readonly Display display1 = new Display(4, "16M");

        private GSM phone;

        //defining properties for these fields
        public GSM Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        //add few calls in the phone
        public GSMCallHistoryTest()
        {
            phone = new GSM("Diamond", "HTC", "Pesho", 700.0, battery1, display1);
            phone.AddCall("0888123456", 133, DateTime.Parse("22.02.2013"),TimeSpan.Parse("15:16"));
            phone.AddCall("0888000001", 15, DateTime.Parse("20.02.2013"), TimeSpan.Parse("10:20"));
            phone.AddCall("0888000002", 62, DateTime.Parse("19.02.2013"), TimeSpan.Parse("22:30"));
        }

        //define method to print result
        public void ShowResult()
        {
            foreach (var item in phone.CallHistory)
            {
                Console.WriteLine(item.ToString());
            }
            if (phone.CallHistory.Count == 0)
            {
                Console.WriteLine("No call records!");
            }
        }

        //calculate price of all calls
        public void PriceOfCalls()
        {
            Console.WriteLine("Price of all calls: " + phone.CalculateCallsPrice(0.37) +"\n");
        }

        //remove longest call from history
        public void RemoveLongestCall()
        {
            int longestCall = phone.CallHistory[0].Duration;
            //number of longest call
            string number = phone.CallHistory[0].PhoneNumber;
            //time of longest call
            DateTime callDate = phone.CallHistory[0].Date;
            for (int i = 1; i < phone.CallHistory.Count; i++)
            {
                if (longestCall < phone.CallHistory[i].Duration)
                {
                    longestCall = phone.CallHistory[i].Duration;
                    number = phone.CallHistory[i].PhoneNumber;
                    callDate = phone.CallHistory[i].Date;
                }
            }
            phone.RemoveCall(number, callDate);
            Console.WriteLine("Longest call removed!");
        }

        //clear call history
        public void ClearCallHistory()
        {
            phone.ClearHistory();
        }
    }
}
