#include "planer.h"

#include <ostream>

using lab2::projekt;
using lab2::zadanie;
using lab2::zasob;

std::ostream& lab2::operator<<(std::ostream& out, const lab2::zadanie& z)
    {
    return out << "Zadanie " << z.nazwa << " koszt " << z.koszt;
    }

std::ostream& lab2::operator<<(std::ostream& out, const lab2::zasob& z)
    {
    return out << "Zasob: " << z.nazwa;
    }

// Tu dodać potrzebne implementacje

zasob::zasob(const zasob& z)
{
	this->nazwa = z.nazwa;
	this->rozmiar = z.rozmiar;
}

zasob& zasob::operator= (const zasob& z)
{
	if (this != &z)
	{
		this->nazwa.clear();
		this->rozmiar = z.rozmiar;
		this->nazwa = z.nazwa;
	}
	return *this;
}

bool lab2::operator< (const zasob& z1, const zasob& z2)
{
	return z1.nazwa < z2.nazwa;
}

bool lab2::operator== (const zasob& z1, const zasob& z2)
{
	if (z1.nazwa == z2.nazwa)
	{
		if (z1.rozmiar == z2.rozmiar)
			return true;
	}
		else return false;

}

//bool zasob::operator> (const zasob& z1)
//{
//	return this->nazwa > z1.nazwa;
//}

std::ostream& lab2::operator<<(std::ostream& out, const std::set<zasob>& s)
{
	std::copy(s.begin(), s.end(), std::ostream_iterator<zasob>(out, ","));

	return out;
}

bool lab2::operator== (const zadanie&z1, const zadanie& z2)
{
	if (z1.koszt == z2.koszt)
	{
		if (z1.nazwa == z2.nazwa)
			if (z1.potrzebne_zasoby == z2.potrzebne_zasoby)
				return true;
	}
			else return false;
}

bool projekt::dodaj_zasob(const zasob& z)
{
	if (dostepne_zasoby.find(z) == dostepne_zasoby.end())
	{
		dostepne_zasoby.insert(z);
		return true;
	}
	else return false;
}

bool projekt::usun_zasob(const zasob& z)
{
	if (dostepne_zasoby.find(z) != dostepne_zasoby.end())
	{
		std::set<zasob>::iterator it = dostepne_zasoby.find(z);
		dostepne_zasoby.erase(it);
		return true;
	}
	else return false;
}

const std::set<zasob>& projekt::pobierz_dostepne_zasoby() const
{
	return dostepne_zasoby;
}

bool projekt::czy_da_sie_zrealizowac(const zadanie& z) const
{
	if (std::includes(dostepne_zasoby.begin(), dostepne_zasoby.end(), z.potrzebne_zasoby.begin(), z.potrzebne_zasoby.end()))
		return true;
	else return false;
}

bool projekt::rozpocznij_zadanie(const zadanie& z)
{
	std::set<zasob> temp;
	if (this->czy_da_sie_zrealizowac(z))
	{
		std::set_difference(dostepne_zasoby.begin(), dostepne_zasoby.end(),
			z.potrzebne_zasoby.begin(), z.potrzebne_zasoby.end(),
			std::inserter<std::set<zasob>>(temp, temp.begin()));
		zadania_w_toku.push_back(z);
		dostepne_zasoby = temp;
		return true;
	}
	return false;

}

bool projekt::zakoncz_zadanie(const zadanie& z)
{
	std::list<zadanie>::iterator it;
	it = std::find_if(zadania_w_toku.begin(), zadania_w_toku.end(), [z](const zadanie& zad)->bool {
		if (z == zad)
			return true;
		else return false;
	});
	if (it == zadania_w_toku.end())
	return false;
	else
	{
		zadania_w_toku.erase(it);
		wykonane_zadania.push_back(z);
		std::set<zasob> temp;
		std::set_union(z.potrzebne_zasoby.begin(), z.potrzebne_zasoby.end(),
			dostepne_zasoby.begin(), dostepne_zasoby.end(),
			std::inserter<std::set<zasob>>(temp, temp.begin()));
		dostepne_zasoby = temp;
		return true;
	}
}

std::ostream& lab2::operator<<(std::ostream& out, const projekt& z)
{
	std::copy(z.wykonane_zadania.begin(), z.wykonane_zadania.end(),
		std::ostream_iterator<zadanie>(out, ","));
	return out;
}

void projekt::utajnij_zadania()
{
	std::for_each(wykonane_zadania.begin(), wykonane_zadania.end(), [](zadanie& zad) {
		if (zad.koszt > 2)
		{
			zad.nazwa.clear();
			zad.nazwa.insert(0, "tajne");
		}
	});
}

int lab2::poziom_niezgodnosci_z_planem(const std::vector<zadanie> v1, const std::vector<zadanie> v2)
{
	return std::inner_product(v1.begin(), v1.end(), v2.begin(), 0, std::plus<int>(),
		[](const zadanie& zad1, const zadanie& zad2)->bool {
			return zad1.nazwa == zad2.nazwa;
	});
}