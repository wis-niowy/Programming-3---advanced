using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class Set
    {
        private ulong bits;

        /// 
        public Set(ulong arg)
        {
            bits = arg;
        }

        public Set(params int[] arg)
        {
            for (int i = 0; i < arg.Length; ++i)
            {
                ulong temp = 1;
                temp = temp << arg[i];
                bits |= temp;
            }
        }

        public static explicit operator ulong(Set ident)
        {
            return ident.bits;
        }

        public static implicit operator Set(int ident)
        {
            return new Set(ident);
        }

        public static Set operator +(Set s1, Set s2)
        {
            return new Set(s1.bits | s2.bits);
        }

        public static Set operator -(Set s1, Set s2)
        {
            return new Set((s1.bits & ~s2.bits));
        }
        public override bool Equals(object obj)
        {
            return (this.bits ^ ((Set)obj).bits) == 0; 
        }

        public static bool operator ==(Set s1, Set s2)
        {
            return s1.Equals(s2);
        }
        public static bool operator !=(Set s1, Set s2)
        {
            return !(s1==s2);
        }

        public override int GetHashCode()
        {
            return bits.GetHashCode();
        }

        public bool this [int i]
        {
            get
            {
                return ((bits >> i) & 1) == 1;
            }
            set
            {
                bits = value ? bits | ((ulong)1 << i) : bits & ~((ulong)1 << i);
            }
        }
        public override string ToString()
        {
            int i = 0;
            string zwrot = "{ ";
            ulong bits_copy = bits;
            while (bits_copy != 0)
            {
                if ((bits_copy & 1) == 1)
                {
                    zwrot = zwrot + i + " ";
                }
                bits_copy = bits_copy >> 1;
                i++;
            }
            zwrot = zwrot + " }";
            return zwrot;
        }

        public static Set operator *(Set s1, Set s2)
        {
            return new Set(s1.bits & s2.bits);
        }

        public static bool operator <(Set s1, Set s2)
        {
            return ~(~s1.bits | s2.bits) == 0 && (s1.bits ^ s2.bits) != 0;
        }
        public static bool operator >(Set s1, Set s2)
        {
            return ~(~s2.bits | s1.bits) == 0 && (s1.bits ^ s2.bits) != 0;
        }
        public static Set operator ~(Set s1)
        {
            return new Set(~s1.bits);
        }
        public int Count
        {
            get
            {
                int licznik = 0;
                ulong temp = bits;
                while (temp > 0)
                {
                    if ((temp & 1) == 1)
                    {
                        licznik++;
                    }
                    temp = temp >> 1;
                }
                return licznik;
            }
        }
        public int? Min
        {
            get
            {
                int? wartosc = null;
                int licz = 0;
                ulong temp = bits;
                while (!wartosc.HasValue && temp > 0)
                {
                    if ((temp & 1) == 1)
                    {
                        wartosc = licz;
                        break;
                    }
                    licz++;
                    temp = temp >> 1;
                }
                if (!wartosc.HasValue) wartosc = -1;
                return wartosc;
            }
        }
        //public bool Empty
        //{
        //    get
        //    {
        //        bool flag = true;
        //        ulong temp = bits;
        //        while (temp > 0)
        //        {
        //            if ((temp & 1) == 1)
        //            {
        //                flag = false;
        //                break;
        //            }
        //            temp = temp >> 1;
        //        }
        //        return flag;
        //    }
        //}
        public static Set Empty
        {
            get
            {
                return new Set();
            }
        }
        public Set[] Subsets()
        {
            ulong temp = bits;
            while (temp > 0)
            {

            }
        }
    }
}
