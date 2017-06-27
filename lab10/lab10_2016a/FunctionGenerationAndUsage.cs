using System;
using System.Collections.Generic;

namespace lab10A
{

    public static class FunctionGenerationAndUsage
    {

        public static Func<double, double, double> LukasiewiczTnormGeneration()
        {
            return delegate (double a, double b)
            {
                return Math.Max(0, a + b - 1);
            };
        }

        public static T ReduceManyArguments<T>(Func<T, T, T> fun, params T[] args)
        {
            if (args.Length == 0)
            {
                return default(T);
            }
            else if (args.Length == 1)
            {
                return args[0];
            }
            else
            {
                T wart = fun(args[0], args[1]);
                for (int i = 2; i < args.Length; ++i)
                {
                    wart = fun(args[i], wart);
                }
                return wart;
            }

        }
        ////////////////// 2 ETAP //////////////////
        public static Func<double, double> QuadraticFunction(Func<double, double> fun, double a, double b, double c)
        {
            return x => a * fun(x) * fun(x) + b * fun(x) + c;
        }
        public static bool IsMonotonic(double a, double b, double n, Func<double, double> fun)
        {
            double przedz = (b - a)/n;
            bool flag1 = false; // zakladamy rosnaca
            if (fun(a) > fun(a + przedz)) flag1 = true;
            for (double i = a + przedz; i < b; i = i + przedz)
            {
                if (flag1) // malejaca
                {
                    if (fun(i) < fun(i + przedz))
                        return false;
                }
                else if (!flag1) // rosnaca
                {
                    if (fun(i) > fun(i + przedz))
                        return false;
                }
            }
            return true;
        }
        //////////// 3 ETAP //////////////////////
        public static Func<Point2D, Point2D, double> ManhattanDistance()
        {
            return delegate (Point2D a, Point2D b)
            {
                return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
            };
        }
        public static Point2D Medoid(List<Point2D> lista, Func<Point2D, Point2D, double> fun)
        {
            double sum = 0;
            double min = double.MaxValue;
            Point2D ind = lista[0];
            for (int i = 0; i < lista.Count; ++i)
            {
                for (int j = 0; j < lista.Count; ++j)
                {
                    sum += fun(lista[i], lista[j]);
                }
                if (sum < min)
                {
                    ind = lista[i];
                    min = sum;
                }
                sum = 0;
            }
            return ind;
        }
        ///////////////////// 4 ETAP //////////////////
        public static Func<int[], int[]> PascalTriangleGeneration(int a, int b, int c)
        {
            return delegate (int[] arr)
            {
                int[] arr2 = new int[arr.Length+1];
                arr2[0] = arr[0];
                arr2[arr2.Length - 1] = arr[arr.Length -1];
                for (int i = 1; i < arr2.Length -1; ++i)
                {
                    arr2[i] = arr[i-1] + arr[i];
                }
                return arr2;
            };
        }
        public static void TriangleGeneration(Func<int[], int[]> fun, int n)
        {
            int[] tablica = new int[0];
            for (int i = 0; i < n; ++i)
            {
                tablica = fun(tablica);
                Console.WriteLine("{0}", Program.PrintArray(tablica));
            }
        }
    }
}
