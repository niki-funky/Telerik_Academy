using System;
using System.Linq;
using System.Text;

namespace MobilePhoneDevice
{
    class Call
    {
        //defining fields
        private DateTime date;
        private TimeSpan time;
        private string phoneNumber;
        private int duration;

        //defining properties for these fields
        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public TimeSpan Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        //defining constructors
        //constructor with all fields
        public Call(string number, int duration,
                    DateTime date, TimeSpan time)
        {
            this.phoneNumber = number;
            this.duration = duration;
            this.date = date.Date;
            this.time = time;
        }

        //overriding method ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("phone call:");
            sb.AppendLine("-----------");
            sb.AppendLine(this.phoneNumber);
            sb.AppendLine(this.duration.ToString() + " seconds");
            sb.AppendLine(this.date.ToShortDateString());
            sb.AppendLine(this.time.ToString());

            return sb.ToString();
        }
    }
}
