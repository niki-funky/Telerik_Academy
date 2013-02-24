using System;
using System.Linq;

namespace MobilePhoneDevice
{
    //Nokia 6310i lipoly
    class GSMTest
    {
        //defining fields
        private Battery battery1 = new Battery("Built-in rechargeable", BatteryTypes.LiIon);
        private Battery battery2 = new Battery("Built-in rechargeable", BatteryTypes.LiPoly);
        private Battery battery3 = new Battery("Built-in rechargeable", BatteryTypes.NiMH);

        private Display display1 = new Display(4, "16M");
        private Display display2 = new Display(2, "256");
        private Display display3 = new Display(1, "256");

        private GSM[] array = new GSM[3];

        //defining properties for these fields
        public GSM[] Array
        {
            get
            {
                return this.array;
            }
            set
            {
                this.array = value;
            }
        }

        //defining constructors
        public GSMTest()
        {
            this.array[0] = new GSM("Diamond", "HTC", "Pesho", 700.0, battery1, display1);
            this.array[1] = new GSM("6310i", "Nokia", "Sasho", 100.0, battery2, display2);
            this.array[2] = new GSM("1112", "Nokia", "Pesho", 700.0, battery3, display3);
        }

        //define method to print result
        public void ShowResult()
        {
            foreach (var item in array)
            {
                Console.WriteLine(item.ToString());
            }
        }
        //define method to print iPhone
        public void ShowIPhone()
        {
            Console.WriteLine(GSM.PiPhone4S.ToString());
        }
    }
}
