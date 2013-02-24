using System;
using System.Linq;
using System.Text;

namespace MobilePhoneDevice
{
    class Display
    {
        //defining fields
        private int size;
        private string numberOfColors;

        //defining properties for these fields
        public string NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                this.numberOfColors = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of colors can not be negative!");
                }
                this.size = value;
            }
        }

        //defining constructors
        //constructor with all fields
        public Display(int size, string numOfColors)
        {
            this.size = size;
            this.numberOfColors = numOfColors;
        }

        //constructor only with size field
        //and setting NumberOfColors to be null
        public Display(int size)
            : this(size, null)
        {

        }

        //overriding method ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Size.ToString());
            if (NumberOfColors != null)
            {
                sb.AppendLine(this.NumberOfColors);
            }

            return sb.ToString();
        }
    }
}
