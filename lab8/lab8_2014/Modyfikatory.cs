using System;
using System.Collections;
namespace Lab8
{
    /// <summary>
    /// Interfejs klas modyfikujących sekwencje
    /// </summary>
    public interface IModifier
    {
        /// <summary>
        /// Nazwa modyfikatora
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Metoda modyfikuje sekwencje
        /// </summary>
        /// <param name="sequence">Sekwencja do modyfikacji</param>
        /// <returns>Zmodyfikowana sekwencja</returns>
        IEnumerable Modify(IEnumerable sequence);
    }

    public class PoczatkoweN: IModifier
    {
        private int n;
        public PoczatkoweN(int arg)
        {
            n = arg;
        }

        string IModifier.Name
        {
            get
            {
                return "Poczatkowe " + this.n + " liczb";
            }
        }
        IEnumerable IModifier.Modify(IEnumerable sequence)
        {
            int index = 0;
            foreach(var el in sequence)
            {
                yield return el;
                if (++index > n) break;
            }
        }
    }

    public class TransformacjaLiniowa : IModifier
    {
        private int a;
        private int b;
        public TransformacjaLiniowa(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        string IModifier.Name
        {
            get
            {
                return "Transforamcja liniowa";
            }
        }
        IEnumerable IModifier.Modify(IEnumerable sequence)
        {
            foreach (var el in sequence)
            {
                yield return a*(int)el+b;
            }
        }
    }

    public class TylkoRozne : IModifier
    {

        string IModifier.Name
        {
            get
            {
                return "Uniklane wartosci";
            }
        }
        IEnumerable IModifier.Modify(IEnumerable sequence)
        {
            var last = 0;
            int index = 0;
            foreach (var el in sequence)
            {
                if (index > 0 && last == (int)el) continue;
                last = (int)el;
                yield return el;
                index++;
            }
        }
    }

    public class LiczbyPierwsze : IModifier
    {

        string IModifier.Name
        {
            get
            {
                return "Liczby pierwsze";
            }
        }
        IEnumerable IModifier.Modify(IEnumerable sequence)
        {
            bool flag;
            foreach(var el in sequence)
            {
                flag = true;
                for (int i = 2; i < (int)el; i++)
                {
                    if ((int)el % i == 0) // liczba nie jest pierwsza
                    {
                        flag = false; break;
                    }
                }
                if (flag)
                {
                    yield return el;
                }
            } 
           
        }
    }
}
