
using System;

namespace Set
{
    public class Program
    {

        public static void Main()
        {
            Set s;
            ulong a;

            Console.WriteLine();
            Console.WriteLine("*****   ETAP I  (2p)   *****");
            Console.WriteLine();

            Set s0 = new Set(0xA5UL);
            a = (ulong)s0;
            Console.WriteLine("wartosc liczbowa s0 to {0} (powinno byc 165)", a);
            Console.WriteLine();

            Set s1 = 3;
            a = (ulong)s1;
            Console.WriteLine("wartosc liczbowa s1 to {0} (powinno byc 8)", a);
            Console.WriteLine();

            Set s2 = new Set(2, 3, 5, 7);
            Set s3 = new Set(1, 5);
            a = (ulong)s3;
            Console.WriteLine("wartosc liczbowa s3 to {0} (powinno byc 34)", a);
            Console.WriteLine();

            s = s1 + s3;
            a = (ulong)s;
            Console.WriteLine("wartosc liczbowa s to {0} (powinno byc 42)", a);
            Console.WriteLine();

            s -= s3;
            a = (ulong)s;
            Console.WriteLine("wartosc liczbowa s to {0} (powinno byc 8)", a);
            Console.WriteLine();

            Console.WriteLine("czy s == s1 ? {0} (powinno byc True)", s == s1);
            Console.WriteLine("a teras czy s == s1 ? {0} (powinno byc True)", s.Equals(s1));
            Console.WriteLine("czy s == s2 ? {0} (powinno byc False)", s == s2);
            Console.WriteLine("skrot (hash) s3 to {0} (powinno byc 34)", s3.GetHashCode());
            Console.WriteLine();

            Console.WriteLine("czy 3 nalezy do s2 ? {0} (powinno byc True)", s2[3]);
            Console.WriteLine("czy 9 nalezy do s2 ? {0} (powinno byc False)", s2[9]);
            s2[9] = true;
            Console.WriteLine("czy teraz 9 nalezy do s2 ? {0} (powinno byc True)", s2[9]);
            s2[9] = false;
            Console.WriteLine("a teraz 9 nalezy do s2 ? {0} (powinno byc False)", s2[9]);
            Console.WriteLine();

            Console.WriteLine("zbior s2 to {0} (powinno byc {{ 2 3 5 7 }})", s2);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("*****   ETAP II  (1p)   *****");
            Console.WriteLine();

            Console.WriteLine("iloczyn s2 i s3 to {0} (powinno byc {{ 5 }})", s2 * s3);
            Console.WriteLine("roznica s2 i s3 to {0} (powinno byc {{ 2 3 7 }})", s2 - s3);
            Console.WriteLine("roznica s3 i s2 to {0} (powinno byc {{ 1 }})", s3 - s2);
            Console.WriteLine();

            Console.WriteLine("czy s2 zawiera się w s3 ? {0} (powinno byc False)", s2 < s3);
            Console.WriteLine("czy s2 zawiera w sobie s3 ? {0} (powinno byc False)", s2 > s3);
            Console.WriteLine("czy s1 zawiera się w s2 ? {0} (powinno byc True)", s1 < s2);
            s = s2;
            Console.WriteLine("czy s2 zawiera się w s2 ? {0} (powinno byc False)", s2 < s);
            Console.WriteLine();

            s = new Set(0xCFFUL);
            Console.WriteLine("test dopelnienia i iloczynu {0} (powinno byc {{ 0 1 4 6 10 11 }})", s * ~s2);
            Console.WriteLine();

            Console.WriteLine("s2 ma {0} elementy (powinno byc 4)", s2.Count);
            Console.WriteLine("najmniejszy element s2 to {0} (powinno byc 2)", s2.Min);
            Console.WriteLine("najmniejszy zbioru pustego to {0} (powinno byc -1)", Set.Empty.Min);
            Console.WriteLine();

            Console.WriteLine("czy iloczyn zbiorow s1 i s3 jest pusty ? {0} (powinno True)", s1 * s3 == Set.Empty);
            Console.WriteLine();

            s = s1;
            s[8] = true;
            Console.WriteLine("jeszcze jeden test rownosci {0} (powinno False)", s == s1);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("*****   ETAP III  (2p)   *****");
            Console.WriteLine();

            Console.WriteLine("wszystkie podzbiory zbioru {0} to:", s2);
            Set[] tab = s2.Subsets();
            for (int i = 0; i < tab.Length; ++i)
                Console.WriteLine(" {0,2}:  {1}", i, tab[i]);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("*****   KONIEC   *****");
            Console.WriteLine();

        }

    }
}