using System;
using System.Linq;

namespace Attribute
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class 
        | AttributeTargets.Interface | AttributeTargets.Enum
        | AttributeTargets.Method)]

    class VersionAttribute : System.Attribute
    {
        public double Version { get; private set; }
        public int Major { get; private set; }
        public int Minor { get; private set; }

        public VersionAttribute(double version)
        {
            this.Major = (int)version;
            this.Minor = Fraction(version);
        }

        private Int32 Fraction(double minor)
        {
            string str = minor.ToString("#.#########", System.Globalization.CultureInfo.InvariantCulture);
            return Int32.Parse(str.Substring(str.IndexOf(".") + 1));
        }
    }
}
