#pragma once
#include <bitset>

using namespace std;

template <int N = 32>
class Zbior
{
	bitset<N> wartosci;		// przechowuje wartości zbioru w post. binarnej | <0;N-1>

public:
	Zbior();
	Zbior(int element);
	Zbior(char* bity);
	Zbior(const bitset<N>& set);

	bool empty();
	int count();

	Zbior<N>& operator+ (const Zbior<N>& z1);
	Zbior<N>& operator- (const Zbior<N>& z1);
	Zbior<N>& operator* (const Zbior<N>& z1);
	Zbior<N>& operator+= (const Zbior<N>& z1);
	Zbior<N>& operator-= (const Zbior<N>& z1);
	Zbior<N> operator~ ();

	template <int N>
	friend bool operator<= (const Zbior<N>& z1, const Zbior<N>& z2);
	template <int N>
	friend bool operator>= (const Zbior<N>& z1, const Zbior<N>& z2);
	//Zbior<N>& operator= (const Zbior<N>& element);

	template <int N>
	friend ostream& operator<< (ostream& out, const Zbior<N>& zbior);
};

// UWAGA - indeks 0 w bitset to element pierwszy od PRAWEJ

template <int N>
Zbior<N>::Zbior(): wartosci()
{

}

template <int N>
Zbior<N>::Zbior(int element): wartosci()
{
	if (0 <= element && element < N)
	{
		wartosci.set(element);
	}
}

template <int N>
Zbior<N>::Zbior(const bitset<N>& set)
{
	if (set.any())
	{
		for (int i = 0; i < set.size(); ++i)					// pod indekem 0 jest element pierwszy od PRAWEJ strony!!!!!
		{
			if (set[i]) wartosci.set(i);
		}
	}
}

template <int N>
Zbior<N>::Zbior(char* bity)
{
	bitset<N> temp((string)bity);								// dla string(bity) nie bangla ???? temp[i] wyrzuca blad: subscript requires array or ptr type
	for (int i = 0; i < wartosci.size(); ++i)					// pod indekem 0 jest element pierwszy od PRAWEJ strony!!!!!
	{
		if (temp[i]) wartosci.set(i);
	}
}

template <int N>
bool Zbior<N>::empty()
{
	return !this->wartosci.any();
}

template <int N>
int Zbior<N>::count()
{
	return this->wartosci.count();
}

template <int N>
Zbior<N>& Zbior<N>::operator+ (const Zbior<N>& z1)
{
	*this = Zbior<N>(this->wartosci | z1.wartosci);
	return *this;
}

template<int N>
Zbior<N>& Zbior<N>::operator- (const Zbior<N>& z1)
{
	for (int i = 0; i < z1.wartosci.size(); ++i)
	{
		if (this->wartosci[i])
		{
			if (z1.wartosci[i]) this->wartosci.reset(i);
		}
	}
	return *this;
}

template <int N>
Zbior<N>& Zbior<N>::operator* (const Zbior<N>& z1)
{
	*this = Zbior<N>(this->wartosci & z1.wartosci);
	return *this;
}

template <int N>
Zbior<N>& Zbior<N>::operator+= (const Zbior<N>& z1)
{
	return *this + z1;
}

template <int N>
Zbior<N>& Zbior<N>::operator-= (const Zbior<N>& z1)
{
	return *this - z1;
}

template <int N>
bool operator<= (const Zbior<N>& z1, const Zbior<N>& z2)
{
	for (int i = 0; i < z1.wartosci.size(); ++i)
	{
		if (z1.wartosci[i])
		{
			if (!z2.wartosci[i]) return false;
		}
	}
	return true;
}

template <int N>
bool operator>= (const Zbior<N>& z1, const Zbior<N>& z2)
{
	for (int i = 0; i < z2.wartosci.size(); ++i)
	{
		if (z2.wartosci[i])
		{
			if (!z1.wartosci[i]) return false;
		}
	}
	return true;
}

template <int N>
Zbior<N> Zbior<N>::operator~ ()
{
	Zbior<N> result(this->wartosci);
	for (int i = 0; i < result.wartosci.size(); ++i)
	{
		if (result.wartosci[i])
			result.wartosci.reset(i);
		else
			result.wartosci.set(i);
	}
	return result;
}

template<int N>
ostream& operator<< (ostream& out, const Zbior<N>& zbior)
{
	out << "{ ";
	if (zbior.wartosci.any())
	{
		for (int i = 0; i < zbior.wartosci.size(); ++i)
			if (zbior.wartosci[i])
			{
				out << zbior.wartosci[i] * i << ", ";
			}
		out << "\b\b" << "";									// kursor cofamy o dwa znaki i wpisujemy "" zamiast ostatniego znaku ','
	}
	out << " }" << endl;
	return out;
}

//template<int N>
//Zbior<N>& Zbior<N>::operator= (const Zbior<N>& element)
//{
//	Zbior<N> kopia;
//	if (!element.wartosci.any()) return kopia;
//	kopia.wartosci = element.wartosci;
//	return kopia;
//}
