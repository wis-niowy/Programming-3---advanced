using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            var pm = new Piramida();

            Console.WriteLine("=== ETAP 1 ===");
            //2 punkty

            char[][] piramida1 = pm.BudujNowaPiramide();
            pm.WypiszPiramide(piramida1);

            char[][] piramida2 = pm.BudujNowaPiramide(material: 'M');
            pm.WypiszPiramide(piramida2);

            char[][] piramida3 = pm.BudujNowaPiramide(3, 'S');
            pm.WypiszPiramide(piramida3);

            char[][] piramida4 = pm.BudujNowaPiramide(-10, 'Z');
            pm.WypiszPiramide(piramida4);

            Console.WriteLine();

            Console.WriteLine("=== ETAP 2 ===");
            //1.5 punktu

            char material5;
            char[][] piramida5 = pm.OdejmijPiramidy(out material5, piramida1, piramida2, piramida3);
            Console.WriteLine("Out material: {0}\n", material5);
            pm.WypiszPiramide(piramida5);

            char material6;
            char[][] piramida6 = pm.OdejmijPiramidy(out material6, new[] { piramida2, piramida3 });
            Console.WriteLine("Out material: {0}\n", material6);
            pm.WypiszPiramide(piramida6);

            Console.WriteLine();

            Console.WriteLine("=== ETAP 3 ===");
            //1.5 punktu

            char[][] piramida7 = pm.BudujPiramideZObiektow(new object[] { 2.9, "Some text", 'C', 2, 'c', 3.8, 4 });
            pm.WypiszPiramide(piramida7);

            char[][] piramida8 = pm.BudujPiramideZObiektow(2.9, "Some text", 2, 3.8, 4);
            pm.WypiszPiramide(piramida8);

            char[][] piramida9 = pm.BudujPiramideZObiektow(new object[] { 2.9, "Some text", 'C', 'c', 3.8 });
            pm.WypiszPiramide(piramida9);

            char[][] piramida10 = pm.BudujPiramideZObiektow(2.9, "Some text", 3.8);
            pm.WypiszPiramide(piramida10);

            Console.WriteLine();
        }
    }
}
