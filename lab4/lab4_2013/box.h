#ifndef BOX_H
#define BOX_H
#include <cstdlib>
#include <iostream>
#include <vector>
#include <string>
#include <cmath>

class Box
{
public:
    int w;
    int h;
    inline Box ( int w, int h ) : w ( w ), h ( h ) {}
	inline Box() : w(0), h(0) {}

	friend int count_fine_for_pair(const Box& b1, const Box& b2);
	friend Box* find_optimal_order(Box boxes[], int array_size, int& fine_val);
	friend std::ostream& operator<< (std::ostream& out, const Box& b);

};

int count_fine_for_all(Box boxes[], int array_size);

#endif // BOX_H
