using System;
using System.Threading.Tasks;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestsAsync().Wait();
        }

        private async static Task RunTestsAsync()
        {
            Console.WriteLine("=== ETAP 1 ===");
            var a = new SlowString("ab", true);
            var b = new SlowString("c", true);

            var result1 = a.Equal(b);
            var result2 = b.Last(b);
            var result3 = b.GreaterThen(a);

            result1.Wait();
            result2.Wait();
            result3.Wait();

            Console.WriteLine();
            Console.WriteLine("Results: {0},   {1},   {2}", result1.Result, result2.Result, result3.Result);
            Console.WriteLine();

            var result4 = await a.Equal(a);
            var result5 = await a.Last(b);
            var result6 = await a.GreaterThen(a);

            Console.WriteLine();
            Console.WriteLine("Results: {0},   {1},   {2}", result4, result5, result6);
            Console.WriteLine();

            Console.WriteLine("=== ETAP 2 ===");

            var array1 = new SlowString[]
            {
                new SlowString("a", true), new SlowString("b", true), new SlowString("abc", true), new SlowString("bc", true)
            };

            var last1 = await array1.Last(true);

            var array2 = new SlowString[60];
            for (int i = 0; i < 60; ++i)
                array2[i] = new SlowString(i.ToString(), false, 1);

            var last2 = await array2.Last();

            Console.WriteLine();
            Console.WriteLine("Results: {0},   {1}", last1, last2);
            Console.WriteLine();

            Console.WriteLine("=== ETAP 3 ===");

            //var max1 = array1.Concatenate();
            //var max2 = array2.Concatenate();

            //max1.Wait();
            //max2.Wait();

            //Console.WriteLine();
            //Console.WriteLine("Results: {0},   {1}", max1.Result, max2.Result);
            //Console.WriteLine();
        }
    }


}
