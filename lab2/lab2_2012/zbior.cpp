#include "zbior.h"

//template <int N>
//Zbior<N>::Zbior()
//{
//
//}
//
//template <int N>
//Zbior<N>::Zbior(int element): wartosci(element)
//{
//	if (0 <= element && element < N)
//	{
//		wrtosci[element] = 1;
//	}
//}
//
//template <int N>
//Zbior<N>::Zbior(char* bity)
//{
//	wartosci = wartosci | bity;
//}
//
//template<int N>
//ostream& operator<< (ostream& out, const Zbior<N>& zbior)
//{
//	out << "{ ";
//	if (wartosci.size())
//	{
//		for (int i = 0; i < wartosci.size(); ++i)
//			out << wartosci[wartosci.size() - i + 1] << ", ";
//	}
//	out << " }" << endl;
//	return out;
//}