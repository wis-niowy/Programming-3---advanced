#include <iostream>

#include "planer.h"


using lab2::projekt;
using lab2::zadanie;
using lab2::zasob;
using std::ostream;

int main(int argc, char** argv)
    {
    std::cout << std::endl << "*** Etap 1 (2p) ***" << std::endl << std::endl;

    projekt p;
    const projekt& pr=p;

    const auto z1 = zasob("komputer",2);
    const auto z2 = zasob("dlugopis",1);
    const auto z3 = zasob("olowek",1);
    const auto z4 = zasob("dywan",3);

    p.dodaj_zasob(z1);
    p.dodaj_zasob(z2);
    p.dodaj_zasob(z3);
    std::cout << "Powinno byc 1: " << p.dodaj_zasob(z4) << std::endl;
    std::cout << "Powinno byc 0: " << p.dodaj_zasob(zasob("dywan",3)) << std::endl;


    const std::set<zasob>& zasoby = pr.pobierz_dostepne_zasoby();
    std::cout << zasoby << std::endl;

    std::cout << "Powinno byc 1: " << p.usun_zasob(zasob("komputer", 2)) << std::endl;
    std::cout << "Powinno byc 0: " << p.usun_zasob(zasob("komputer", 2)) << std::endl;

    std::cout << zasoby << std::endl;

    std::cout << std::endl << "*** Etap 2 (1p) ***" << std::endl << std::endl;

   p.dodaj_zasob(z4);
    p.dodaj_zasob(z1);

    zadanie zad1("spanie", 1, {z4});
    zadanie zad2("spanie+", 1, {z4, zasob("poduszka", 1)});
    zadanie zad3("nauka c++", 3, {z4,z1,z3});

    std::cout << "Wykonalnosc 0: " << pr.czy_da_sie_zrealizowac(zad2) << std::endl;
    std::cout << "Wykonalnosc 1: " << pr.czy_da_sie_zrealizowac(zad1) << std::endl;
    std::cout << "Wykonalnosc 1: " << pr.czy_da_sie_zrealizowac(zad3) << std::endl;

    std::cout << "Stan zasobow: " << zasoby << std::endl;

    std::cout << "Rozpoczecie 0: " << p.rozpocznij_zadanie(zad2) << std::endl;
    std::cout << "Rozpoczecie 1: " << p.rozpocznij_zadanie(zad3) << std::endl;
    std::cout << "Rozpoczecie 0: " << p.rozpocznij_zadanie(zad1) << std::endl;

    std::cout << "Stan zasobow: " << zasoby << std::endl;

    std::cout << "Zakoncz zadanie 0: " << p.zakoncz_zadanie(zad2) << std::endl;
    std::cout << "Zakoncz zadanie 1: " << p.zakoncz_zadanie(zad3) << std::endl;

    std::cout << "Stan zasobow: " << zasoby << std::endl;

    std::cout << std::endl << "*** Etap 3 (1p) ***" << std::endl << std::endl;

    p.rozpocznij_zadanie(zad1);
    p.zakoncz_zadanie(zad1);

    p.rozpocznij_zadanie(zad3);
    p.zakoncz_zadanie(zad3);

    std::cout << "Stan projektu: " << p << std::endl;
    p.utajnij_zadania();
    std::cout << "Stan projektu: " << p << std::endl;

    std::cout << std::endl << "*** Etap 4 (1p) ***" << std::endl << std::endl;

    std::vector<zadanie> v1= {zad1,zad2,zad3,zad1};
    std::vector<zadanie> v2= {zad1,zad1,zad3,zad2};

    std::cout << "Test poziomu niezgodnosci (powinno byc 2): " <<
              poziom_niezgodnosci_z_planem(v1,v2) << std::endl;

    std::cout << std::endl << "*** Koniec ***" << std::endl << std::endl;
    return 0;
    }

