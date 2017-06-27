using System;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {

            // konstruktor, Show, Count, Enqueue

            Console.WriteLine("*** konstruktor, Show, Count, Enqueue **********************************\n");

            Console.WriteLine(" TEST 1");
            Queue<int> pq = new Queue<int>(5);
            pq.Show();
            Console.WriteLine(">Powinno byc: Pusta kolejka \n");
            Console.WriteLine("Liczba elementow: {0}", pq.Count);
            Console.WriteLine(">Powinno byc: 0 \n");

            Console.WriteLine(" TEST 2");
            pq.Enqueue(3);
            pq.Enqueue(1);
            pq.Enqueue(7);
            pq.Enqueue(2);
            pq.Enqueue(6);
            pq.Enqueue(4);
            pq.Show();
            Console.WriteLine(">Powinno byc: 3 1 7 2 6 4\n");
            Console.WriteLine("Liczba elementow: {0}", pq.Count);
            Console.WriteLine(">Powinno byc: 6 \n");

            // Dequeue

            Console.WriteLine("*** Dequeue ***********************************************************\n");

            Console.WriteLine(" TEST 3");
            Console.WriteLine("Usunieta wartosc: {0}", pq.Dequeue());
            Console.WriteLine(">Powinno byc: 3 \n");
            pq.Show();
            Console.WriteLine(">Powinno byc: 1 7 2 6 4\n");
            Console.WriteLine("Liczba elementow: {0}", pq.Count);
            Console.WriteLine(">Powinno byc: 5 \n");

            Console.WriteLine(" TEST 4");

            Queue<double> pq2 = new Queue<double>(4);
            pq2.Enqueue(0.8);
            pq2.Dequeue();
            pq2.Enqueue(0.9);
            pq2.Enqueue(1.0);
            pq2.Enqueue(1.1);
            pq2.Enqueue(1.2);
            pq2.Dequeue();
            pq2.Dequeue();
            pq2.Enqueue(1.3);
            pq2.Dequeue();
            pq2.Show();
            Console.WriteLine(">Powinno byc: 1,2 1,3\n");
            Console.WriteLine("Liczba elementow: {0}", pq2.Count);
            Console.WriteLine(">Powinno byc: 2 \n");

            // Max

            Console.WriteLine("*** Max **************************************************************\n");

            Console.WriteLine(" TEST 5");
            Console.WriteLine("Maksimum dla pq: {0}", pq.Max());
            Console.WriteLine(">Powinno byc: 7\n\n");

            Console.WriteLine(" TEST 6");
            Console.WriteLine("Maksimum dla pq2: {0}", pq2.Max());
            Console.WriteLine(">Powinno byc: 1,3\n\n");

            // Clone

            Console.WriteLine("*** Clone **************************************************************\n");

            Console.WriteLine(" TEST 7");
            pq.Enqueue(8);
            Queue<int> pqClone = (Queue<int>)pq.Clone();
            pqClone.Show();
            Console.WriteLine(">Powinno byc: 1 7 2 6 4 8\n");

            // Empty

            Console.WriteLine("*** Empty **************************************************************\n");

            Console.WriteLine(" TEST 8");
            Console.WriteLine("Czy kolejka pq2 jest pusta: {0}", pq2.Empty());
            Console.WriteLine(">Powinno byc: False \n");

            Console.WriteLine(" TEST 9");
            pq2.Dequeue();
            pq2.Dequeue();
            Console.WriteLine("Czy kolejka pq2 jest pusta: {0}", pq2.Empty());
            Console.WriteLine(">Powinno byc: True \n\n");

            // ToArray

            Console.WriteLine("*** ToArray ************************************************************\n");

            Console.WriteLine(" TEST 10");
            int[] tab = new int[pq.Count];
            tab = pq.ToArray();
            for (int i = 0; i < pq.Count; i++)
            {
                Console.Write("{0} ", tab[i]);
            }
            Console.WriteLine("\n>Powinno byc: 1 7 2 6 4 8\n\n");

            // sortowanie

            Console.WriteLine("*** sortowanie *********************************************************\n");
            
            // tutaj wpisz kod sortujacy elementy kolejki pq

            //Console.WriteLine(" TEST 11");
            //pqSort.Show();
            //Console.WriteLine("\n>Powinno byc: 8 7 6 4 2 1\n\n");

            Console.WriteLine("************************************************************************\n");

        }
    }
}
