using System;
// Napisać abstrakcyjną klasę Jedzenie
// a w niej publiczne abstrakcyjne bezparametrowe metody Pogryz i Polknij

// Napisać abstrakcyjną klasę Zwierze
// z następującymi składowymi
// - publiczne pole Imie typu string (pole readonly)
// - konstruktor z parametrem typu string (imię zwierzęcia)
// - wirtualna bezparametrowa metoda Jedz
//     wypisująca na konsolę "Zwierzę {Imie} liżę łapę"
// - abstrakcyjna metoda Jedz z parametrem typu Jedzenie
// - abstrakcyjna bezparanetrowa metoda DajGlos

// Napisać klasy Pies i Kot dziedziczące z klasy Zwierze
// obie klasy powinny zawierać konstruktor wskazujący imię zwierzęcia

// Metody klasy Pies działają w następujący sposób:
//  DajGlos wypisuje na konsolę "{Imie}: szczek, szczek"
//  bezparametrowa metoda Jedz wypisuję na konsolę "{Imie}: Nie będę lizał łapy chcę coś do jedzenia"
//  metada Jedz przyjmująca jako parametr Jedzenie - wypisuje na konsolę "{Imie} {0} połyka jedzenie: " i wywołuje metodę Polknij na parametrze.

// Metody klasy Kot dzialają w następujący sposób:
//  DajGlos wypisuje na konsolę "{Imie}: miau, miau"
//  bezparametrowa metod Jedz nie jest nadpisana
//  metada Jedz przyjmująca jako parametr Jedzenie - wypisuje na konsolę "{Imie} gryzie Jedzenie: " i wywołuje metodę Jedz na parametrze.

// Napisać klasy Kosc i Stek dziedziczące z Jedzenie
// Metody klasy Kosc działają w następujący sposób
//  Pogryz wypisuje na konsolę "Twarda i niedobra ta kość"
//  Polknij wypisuje na konsolę "Kość stanęła mi w gardle"

// Metody klasy Stek działają w następujący sposób
//  Pogryz wypisuje na konsolę "Trochę gumowy ale dobry"
//  Polknij wypisuje na konsolę "Mniam."
namespace PO_Lab5
{
    abstract public class Jedzenie
    {
        abstract public void Pogryz();
        abstract public void Polknij();
    }

    abstract public class Zwierze
    {
        public readonly string Imie;

        public Zwierze(string _imie )
        {
            this.Imie = _imie;
        }

        virtual public void Jedz()
        {
            Console.WriteLine("Zwierze {0} liże łapę\n", Imie);
        }
        abstract public void Jedz(Jedzenie _jedzenie);
        abstract public void DajGlos();
    }

    public class Pies: Zwierze
    {

        public Pies(string _imie) : base(_imie) { }
        override public void DajGlos()
        {
            Console.WriteLine("{0}: szczek, szczek", Imie);
        }
        public override void Jedz()
        {
            Console.WriteLine("{0}: Nie będę lizał łapy chcę coś do jedzenia\n", Imie);
        }
        override public void Jedz(Jedzenie _jedzenie)
        {
            Console.WriteLine("{0} połyka jedzenie: ", Imie);
            _jedzenie.Polknij();
        }

    }
    public class Kot: Zwierze
    {

        public Kot(string _imie) : base(_imie) { }
        override public void DajGlos()
        {
            Console.WriteLine("{0}: miau, miau", Imie);
        }
        public override void Jedz(Jedzenie _jedzenie)
        {
            Console.WriteLine("{0} gryzie Jedzenie: ", base.Imie);
            _jedzenie.Pogryz();
        }

    }
    public class Kosc: Jedzenie
    {
        public override void Pogryz()
        {
            Console.WriteLine("Twarda i niedobra ta kość\n");
        }
        public override void Polknij()
        {
            Console.WriteLine("Kość stanęła mi w gardle\n");
        }
    }
    public class Stek: Jedzenie
    {
        public override void Pogryz()
        {
            Console.WriteLine("Trochę gumowy ale dobry\n");
        }
        public override void Polknij()
        {
            Console.WriteLine("Mniam.\n");
        }
    }
}
