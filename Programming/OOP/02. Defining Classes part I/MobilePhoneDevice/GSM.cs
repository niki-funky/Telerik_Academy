using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilePhoneDevice
{
    class GSM
    {
        //defining fields
        public string Model { get; private set; }
        public string Manufacturer { get; private set; }
        public string Owner { get; private set; }
        public Battery Battery { get; private set; }
        public Display Display { get; private set; }
        private double? price;
        //static fields
        private static readonly Battery iPhone4Sbattery = new Battery("Built-in rechargeable", BatteryTypes.LiIon);
        private static readonly Display iPhone4Sdisplay = new Display(5, "16M");
        private static readonly GSM iPhone4S = new GSM("iPhone4S", "Apple", "Steve", 800.1, iPhone4Sbattery, iPhone4Sdisplay);

        #region defining properties for these fields

        public double? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be positive!");
                }
                this.price = value;
            }
        }
        //static property
        public static GSM PiPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        //list to hold all performed calls
        public List<Call> CallHistory = new List<Call>();
        #endregion

        #region defining constructors

        //constructor with all fields
        public GSM(string model, string manufacturer, string owner,
                   double? price, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.price = price;
        }

        //constructor only with model and manufacturer fields
        //and setting the other fields to be null
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null, null, null)
        {

        }

        //constructor with model, manufacturer and owner fields
        //and setting the other fields to be null
        public GSM(string model, string manufacturer, string owner)
            : this(model, manufacturer, owner, null, null, null)
        {

        }

        //constructor with model, manufacturer, owner and price fields
        //and setting the other fields to be null
        public GSM(string model, string manufacturer, string owner, double? price)
            : this(model, manufacturer, owner, price, null, null)
        {

        }

        //constructor with model, manufacturer, owner, price and Battery fields
        //and setting the other fields to be null
        public GSM(string model, string manufacturer, string owner, double? price, Battery battery)
            : this(model, manufacturer, owner, price, battery, null)
        {

        }

        //constructor with model, manufacturer, owner, price and Display fields
        //and setting the other fields to be null
        public GSM(string model, string manufacturer, string owner, double? price, Display display)
            : this(model, manufacturer, owner, price, null, display)
        {

        }
        #endregion

        #region methods dealing with calls
        //add call to CallHistory
        public void AddCall(string number, int duration, DateTime date, TimeSpan time)
        {
            Call call = new Call(number, duration, date, time);
            CallHistory.Add(call);
        }

        //remove call from CallHistory
        public void RemoveCall(string number, DateTime date)
        {
            for (int i = 0; i < CallHistory.Count; i++)
            {
                if (CallHistory[i].PhoneNumber == number
                    && CallHistory[i].Date == date)
                {
                    CallHistory.RemoveAt(i);
                }
            }
        }

        //clear CallHistory
        public void ClearHistory()
        {
            CallHistory.Clear();
        } 

        //calculate price of all calls
        public double CalculateCallsPrice(double price)
        {
            double seconds = 0;
            foreach (var item in CallHistory)
            {
                seconds = seconds + item.Duration;
            }

            return Math.Round(price * (seconds / 60), 3); 
        }
        #endregion

        //overriding method ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Phone Device:");
            sb.AppendLine("-------------");
            sb.AppendLine(this.Model);
            sb.AppendLine(this.Manufacturer);
            sb.AppendLine(this.price.ToString());
            sb.AppendLine(this.Owner);
            sb.AppendLine(this.Battery.ToString());
            sb.AppendLine(this.Display.ToString());

            return sb.ToString();
        }
    }
}
