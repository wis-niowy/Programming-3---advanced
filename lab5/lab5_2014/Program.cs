using System;

namespace PO_Lab5
{
	class Program
	{
        static void Main()
        {
            Zwierze[] zwierzeta = { new Pies("Burek"), new Kot("Puszek"), new Pies("Reksio"), };

            // Etap 1 (2p.)
            Console.WriteLine("\nZwierzęta mówią:");
            for (int i = 0; i < zwierzeta.Length; i++)
            {
                zwierzeta[i].DajGlos();
            }

            // Etap 2 (1p.)
            Console.WriteLine("\nZwierzęta liżą łapę:");
            for (int i = 0; i < zwierzeta.Length; i++)
            {
                zwierzeta[i].Jedz();
            }

            // Etap 3 (2p.)
            Jedzenie[] jedzenie = { new Kosc(), new Stek() };

            Console.WriteLine("\nZwierzęta jedzą:");
            for (int i = 0; i < zwierzeta.Length; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < jedzenie.Length; j++)
                {
                    zwierzeta[i].Jedz(jedzenie[j]);
                }
            }

            Console.WriteLine();
		}
	}
}
