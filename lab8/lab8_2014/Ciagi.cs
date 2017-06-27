using System;
using System.Collections;

namespace Lab8
{
    public class Naturalne: IEnumerable
    {
        private int first;
        public Naturalne(int arg = 0)
        {
            first = arg;
        }

        public IEnumerator GetEnumerator()
        {
            int temp = first;
            while (true)
            yield return temp++;
        }
    }

    public class Losowe: IEnumerable
    {
        private int max;
        private int seed;
        public Losowe(int arg1, int arg2)
        {
            max = arg1; seed = arg2;
        }

        public IEnumerator GetEnumerator()
        {
            Random rng = new Random(seed);
            while (true)
            {
                yield return rng.Next(0, max + 1);
            }
        }
    }
    public class Tetranacci: IEnumerable
    {

        public IEnumerator GetEnumerator()
        {
            int t0 = 0, t1 = 0, t2 = 0, t3 = 1, tn;
            yield return t0;
            yield return t1;
            yield return t2;
            yield return t3;
            while (true)
            {
                yield return tn = t0 + t1 + t2 + t3;
                t0 = t1;
                t1 = t2;
                t2 = t3;
                t3 = tn;
            }

        }
    }

        public class Catalan: IEnumerable
        {

            public IEnumerator GetEnumerator()
            {
                int c0 = 1, cn;
                int i = 0;
                yield return c0;
                while (true)
                {
                    yield return cn = c0 * 2 * (2 * i + 1) / (i + 2);
                    c0 = cn;
                    i++;
                }
            }
        }
        public class Wielomian: IEnumerable
        {
        private int[] wsp;

        public Wielomian(int[] arg)
        {
            wsp = new int[arg.Length];
            for (int i = 0; i < arg.Length; ++i)
            {
                wsp[i] = arg[i];
            }
        }

            public IEnumerator GetEnumerator()
            {
                int liczbNat = 0;
                int wynik;
                while (true)
                {
                    wynik = wsp[wsp.Length-1];
                    for (int i = wsp.Length-2; i >= 0; --i)
                    {
                        wynik += wynik * liczbNat + wsp[i]; // algorytm Hornera
                    }
                    yield return wynik;
                    liczbNat++;
                }
            }
        }

}
