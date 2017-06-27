using System;
using System.Collections;

namespace Lab8b
{
    public static class Sequences
    {

        public static void PrintSeq(IEnumerable arg)
        {
            foreach (int el in arg)
            {
                Console.Write("{0} ", el);
            }
            Console.WriteLine();
        }
        public static IEnumerable LimitSequence(IEnumerable arg, int n)
        {
            int i = 0;
            foreach (int el in arg)
            {
                if (i >= n) break;
                yield return el;
                i++;
            }
        }
        public static IEnumerable NaturalNumbers()
        {
            for (int i = 0; ; i++)
            {
                yield return i;
            }
        }
        public static IEnumerable Intersperse(IEnumerable arg, int x)
        {
            foreach (int el in arg)
            {
                yield return el;
                yield return x;
            }
        }
        /////////////// 2 ETAP /////////////////
        public static IEnumerable Cycle(IEnumerable arg)
        {
            while (true)
            {
                foreach (int el in arg)
                {
                    yield return el;
                }
            }
        }
        public static int IndexOfFirstOccurrence(IEnumerable arg, int x)
        {
            int? i = null;
            int iter = 0;
            foreach (int el in arg)
            {
                if (el == x)
                {
                    i = iter;
                    break;
                }
                iter++;
            }
            if (!(i.HasValue))
            {
                return -1;
            }
            else
            {
                return i.Value;
            }
        }
        public static IEnumerable SkipN(IEnumerable arg, int n)
        {
            int i = 0;
            foreach (int el in arg)
            {
                if (i >= n)
                {
                    yield return el;
                }
                i++;
            }
        }
        ///////////////// 3 ETAP ///////////////////////
        public static IEnumerable SequenceSum(IEnumerable seq1, IEnumerable seq2)
        {
            IEnumerator e1 = seq1.GetEnumerator();
            IEnumerator e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return (int)e1.Current + (int)e2.Current;
            }
        }
        public static IEnumerable ArithmeticSubsequence(IEnumerable seq)
        {
            int poprz1, poprz2, r;
            IEnumerator e = seq.GetEnumerator();
            if (e.MoveNext())
            {
                poprz1 = (int)e.Current;
                yield return poprz1;
                if (e.MoveNext())
                {
                    poprz2 = (int)e.Current;
                    yield return poprz2;
                    r = poprz2 - poprz1;
                    while (e.MoveNext())
                    {
                        if ((int)e.Current - poprz2 == r)
                        {
                            yield return (int)e.Current;
                            poprz1 = poprz2;
                            poprz2 = (int)e.Current;
                        }

                    }
                }
            }
        }
        public static IEnumerable SequenceSumWithTail(IEnumerable seq1, IEnumerable seq2)
        {
            IEnumerator e1 = seq1.GetEnumerator();
            IEnumerator e2 = seq2.GetEnumerator();
            bool flag1 = true, flag2 = true;
            while ((flag1 = e1.MoveNext()) && (flag2 = e2.MoveNext()))
            {
                yield return (int)e1.Current + (int)e2.Current;
            }
            if (!flag1)
            {
                while (e2.MoveNext())
                {
                    yield return (int)e2.Current;
                }
            }
            else if (!flag2)
            {
                yield return (int)e1.Current;
                while (e1.MoveNext())
                {
                    yield return (int)e1.Current;
                }
            }
        }
        /////////////////// 4 ETAP ////////////////////
        public static bool IsRecurrenceEquation(IEnumerable seq, int[] arr)
        {
            int n = arr.Length - 1;
            int counter = 0;
            int suma = 0;
            IEnumerator e;
            bool flag = false;
            while(true)
            {
                e = seq.GetEnumerator();
                for (int i = 0; i < counter; ++i)
                {
                    e.MoveNext();
                }
                if (!e.MoveNext()) break;
                for (int i = 0; i < n; ++i)
                {
                    suma += (int)e.Current*arr[i];
                    if (!e.MoveNext()) flag=true;
                }
                suma += arr[n];
                if (flag) break;
                if ((int)e.Current != suma)
                {
                    return false;
                }
                suma = 0;
                counter++;
            }

            return true;
        }
    }
}
