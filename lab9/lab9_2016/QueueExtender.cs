using System;
using System.Collections;

namespace lab9
{

static class QueueExtedner   // dopisac co trzeba
    {
        public static bool Empty<T>(this Queue<T> arg1)
            where T: IComparable
        {
            return (arg1.Count == 0);
        }

        public static T[] ToArray<T>(this Queue<T> arg1)
            where T: IComparable
        {
            Queue<T> kopia = arg1.Clone();
            T[] zwrot = new T[kopia.Count];
            int i = 0;
            while (!kopia.Empty())
            {
                zwrot[i] = kopia.Dequeue();
                ++i;
            }
            return zwrot;
        }
    }

}
