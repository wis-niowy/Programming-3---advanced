using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab12
{
    public class SlowString
    {
        private string text;
        private bool flag;
        private int delay;

        public SlowString(string Text, bool Flag = false, int Delay = 30)
        {
            text = Text;
            flag = Flag;
            delay = Delay;
        }

        public async Task<bool> Equal(SlowString other)
        {
            bool wynik;
            if (flag) Console.WriteLine("Poczatek operacji Equal");
            wynik = await Task<bool>.Run(() =>
            {
                Thread.Sleep(delay);
                return this.text.Equals(other.text);
            });
            if (flag) Console.WriteLine("Koniec operacji Equal");
            return wynik;
        }

        public async Task<bool> GreaterThen(SlowString other)
        {
            bool wynik;
            if (flag) Console.WriteLine("Poczatek operacji GreaterThen");
            wynik = await Task<bool>.Run(() =>
            {
                Thread.Sleep(delay);
                return this.text.CompareTo(other.text) > 0;
            });
            if (flag) Console.WriteLine("Koniec operacji GreaterThen");
            return wynik;
        }

        public async Task<SlowString> Last(SlowString other)
        {
            if (flag) Console.WriteLine("Poczatek operacji Last");
            SlowString wynik;
            wynik = await Task<SlowString>.Run(() =>
           {
               Thread.Sleep(delay);
               if (this.text.CompareTo(other.text) > 0) return this;
               else return other;
           });
            if (flag) Console.WriteLine("Koniec operacji Last");
            return wynik;
        }
        public override string ToString()
        {
            return text;
        }
    }
    ///////////////// 2 ETAP //////////////////////

    public static class SlowStringExtension
    {
        public static async Task<SlowString> Last(this SlowString[] tab, bool flag = false)
        {
            if (flag) Console.WriteLine("Poczatek operacji Last");
            SlowString wynik, w = new SlowString("", flag);
            wynik = await Task<SlowString>.Run(() =>
            {
                w = tab[0];
                for (int i = 1; i < tab.Length; ++i)
                {
                    //if (!w.GreaterThen(tab[i]).Result) w = tab[i];
                    w = w.Last(tab[i]).Result;
                }
                return w;
            });
            if (flag) Console.WriteLine("Koniec operacji Last");
            return wynik;
        }
    }

}
