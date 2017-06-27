using System;

namespace lab9
{

    class Queue<T>: ICloneable // dopisac co trzeba
        where T: IComparable
    {

        private T[] tab;
        private int size;
        private int start;
        private int end;

        public Queue(int arg)
        {
            tab = new T[arg];
            size = 0;
            start = 0; end = 0;
        }
        public void Show()
        {
            if (size > 0)
            {
                for (int i = start, j = 0; j < size; i=(i+1)%tab.Length, ++j)
                {
                    Console.Write("{0} ", tab[i]);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Pusta kolejka\n");
            }
        }
        public int Count
        {
            get
            {
                return size;
            }
        }
        public void Enqueue(T arg)
        {
            if (size == 0)
            {
                tab[0] = arg;
                size++;
            }
            else if (size == tab.Length)
            {
                T[] temp = new T[2 * tab.Length];
                for (int i = start, j = 0; j < tab.Length; i=(i+1)%tab.Length, ++j)
                {
                    temp[j] = tab[i];
                }
                temp[tab.Length] = arg;
                size++;
                start = 0;
                end = tab.Length;
                tab = temp;
            }
            else
            {
                end = (end + 1) % tab.Length;
                tab[end] = arg;
                size++;
            }
        }
        public T Dequeue()
        {
            T zwrot = tab[start];
            start = (start + 1) % tab.Length;
            size--;
            if (size == 0)
            {
                start = 0;
                end = 0;
            }
            return zwrot;
        }
        public T Max()
        {
            T maxi = tab[0];
            for (int i = 1; i < tab.Length; ++i)
            {
                if (tab[i].CompareTo(maxi) > 0)
                {
                    maxi = tab[i];
                }
            }
            return maxi;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public Queue<T> Clone()
        {
            Queue<T> zwrot = new Queue<T>(this.tab.Length);
            for (int i = 0; i < tab.Length; ++i)
            {
                zwrot.tab[i] = this.tab[i];
            }
            zwrot.start = this.start;
            zwrot.end = this.end;
            zwrot.size = this.size;
            return zwrot;
        }
        //public T[] ToArray()
        //{
        //    T[] zwrot = new T[size];
        //    for (int i = 0, j = start; i < size; ++i, j = (j + 1)%tab.Length)
        //    {
        //        zwrot[i] = tab[j];
        //    }
        //    return zwrot;
        //}
    }
}
