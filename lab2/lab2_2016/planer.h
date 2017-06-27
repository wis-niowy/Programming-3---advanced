#ifndef PLANER_H
#define PLANER_H

#include <set>
#include <string>
#include <vector>
#include <list>
#include <ostream>
#include <iterator>
#include <algorithm>
#include <numeric>

namespace lab2
{

class zasob
    {
        std::string nazwa;
        int rozmiar;

    public:
        inline zasob(std::string n, int r) : nazwa(n), rozmiar(r) {}

        friend std::ostream& operator<<(std::ostream& out, const zasob& z);

        //Dodać składowe potrzebne, aby można było utworzyć std::set<zasob>
		zasob(const zasob& z);
		zasob& operator= (const zasob& z);
		friend bool operator< (const zasob& z1, const zasob& z2);
		friend bool operator== (const zasob& z1, const zasob& z2);
		//bool operator> (const zasob& z1);
    };

class zadanie
    {
    public:
        std::string nazwa;
        int koszt;
        std::set<zasob> potrzebne_zasoby;

        // W etapie 2 dodać konstruktor publiczny pozwalający na utworzenie inzstancji zadania
        // z trzema argumentami -- nazwą, kosztem (mają po prostu zostać przypisane do odpowiednich pól)
        // i listą inicjującą zasobów, która utworzy
        // zbiór potrzebne_zasoby
        // Wywołanie konstruktora jest w main.cpp w liniach 43-45.
		inline zadanie(std::string _n, int _k, std::set<zasob> _s) :
			nazwa(_n), koszt(_k), potrzebne_zasoby(_s) { }
        // Można dodać inne potrzebne składowe.
		friend bool operator== (const zadanie&z1, const zadanie& z2);
    };

// Ten operator potrzebny jest w etapie 1
std::ostream& operator<<(std::ostream& out, const std::set<zasob>& s);

// Ten operator przyda się przy implementacji analogicznego operatora dla klasy
// projekt w etapie 3
std::ostream& operator<<(std::ostream& out, const zadanie& z);

int poziom_niezgodnosci_z_planem(const std::vector<zadanie> v1, const std::vector<zadanie> v2);

class projekt
    {
        std::set<zasob> dostepne_zasoby;
        std::vector<zadanie> wykonane_zadania;
        std::list<zadanie> zadania_w_toku;

    public:
        // Dodać składowe wymagane a odpowiednich etapach i ewentualne składowe pomocnicze
		bool dodaj_zasob(const zasob& z);
		bool usun_zasob(const zasob& z);
		const std::set<zasob>& pobierz_dostepne_zasoby() const;

		bool czy_da_sie_zrealizowac(const zadanie& z) const;
		bool rozpocznij_zadanie(const zadanie& z);
		bool zakoncz_zadanie(const zadanie& z);

		friend std::ostream& operator<<(std::ostream& out, const projekt& z);
		void utajnij_zadania();
    };

// Dodać potrzebne funkcje i ewentualne funkcje pomocnicze
}

#endif /* PLANER_H */
