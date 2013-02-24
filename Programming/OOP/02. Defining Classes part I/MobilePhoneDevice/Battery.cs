using System;
using System.Linq;
using System.Text;

namespace MobilePhoneDevice
{
    class Battery
    {
        //defining fields
        public string Model { get; private set; }
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryTypes batteryType;

        //defining properties for these fields
        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours should not be negative!");
                }
                this.hoursTalk = value;
            }
        }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours should not be negative!");
                }
                this.hoursIdle = value;
            }
        }

        public BatteryTypes BatteryType
        {
            get
            {
                return this.batteryType;
            }
        }

        //defining constructors
        //constructor with all fields
        public Battery(string model, int? idleHours, int? talkHours, BatteryTypes type)
        {
            this.Model = model;
            this.hoursIdle = idleHours;
            this.hoursTalk = talkHours;
            this.batteryType = type;
        }

        //constructor only with model and type fields
        //and setting hours to be null
        public Battery(string model, BatteryTypes type)
            : this(model, null, null, type)
        {

        }

        //overriding method ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Model);
            sb.AppendLine(this.BatteryType.ToString());
            if (HoursTalk != null)
            {
                sb.AppendLine(this.HoursTalk.ToString());
            }
            if (HoursIdle != null)
            {
                sb.AppendLine(this.HoursIdle.ToString());
            }

            return sb.ToString();
        }
    }
}
