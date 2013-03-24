using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray
{
    class BitArray64 : IEnumerable<int>
    {
        //property
        public ulong Number { get; private set; }

        //constructor
        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        //implementing interface IEnumerable<int>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            string s = Convert.ToString((long)this.Number, 2);    //convert to string of bits
            byte[] bitValues = s.PadLeft(64, '0')               // Add 0's from left
                     .Select(c => byte.Parse(c.ToString()))     // convert each char to byte
                     .Reverse()
                     .ToArray();

            foreach (var item in bitValues)
            {
                yield return item;
            }
        }

        //overriding methods
        public override bool Equals(object obj)
        {
            BitArray64 bitObj = obj as BitArray64;
            if (bitObj == null)
            {
                return false;
            }

            if (!Object.Equals(this.Number, bitObj.Number))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 17 + Number.GetHashCode();
            return hash;
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < 64)
                {
                    return (int)(this.Number & (1UL << index)) >> index;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < 64)
                {
                    if (value == 1)
                    {
                        this.Number = this.Number | (1UL << index);
                    }
                    else if (value == 0)
                    {
                        this.Number = this.Number & (~(1UL << index));
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("value", "Value must be 0 or 1.");
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.ReferenceEquals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.ReferenceEquals(first, second);
        }
    }
}
