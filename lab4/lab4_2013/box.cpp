#include "box.h"

using namespace std;

ostream& operator<< (ostream& out, const Box& b)
{
	out << "(Pudelko " << b.w << "x" << b.h << ")";
	return out;
}

int count_fine_for_pair(const Box& b1, const Box& b2)
{
	return abs(b1.h - b2.h) + abs(b1.w - b2.w);
}

Box* find_optimal_order(Box boxes[], int array_size, int& fine_val)
{
	bool flag = false;
	int minimal_fine = fine_val;
	int current_fine = fine_val, new_fine;
	Box* temp_order = new Box[array_size-1];
	Box* current_order = new Box[array_size];
	Box* order_to_return = new Box[array_size];

	for (int i = 0; i < array_size; ++i) // TEN FOR NIE PASUJE !!!!!!!!!!
	{
		if (array_size > 1)
		{
			for (int j = 0; j < array_size - 1; ++j)		//przepisywanie pozostałych elementów do mniejszej tablicy w celu rekursji
			{
				if (j == i) flag = true;
				if (!flag)
				{
					temp_order[j] = boxes[j];
				}
				else
				{
					temp_order[j] = boxes[j + 1];
				}
			} // koniec przepisywania
			temp_order = find_optimal_order(temp_order, array_size - 1, fine_val);
			current_order[i] = boxes[i];		// wpisujemy obecnie sprawdzane ustawienie do tablicy
			for (int j = 1; j < array_size; ++j)
			{
				current_order[j] = temp_order[j - 1];
			}
			new_fine = count_fine_for_all(current_order, array_size);
			if (new_fine < minimal_fine)
			{
				if (new_fine < current_fine)
				{
					current_fine = new_fine;
					order_to_return = current_order;
				}
			}
		}	// koniec if
		
		// obsluga ostatniej rekurencji (najglebszej)
		else
		{
			current_order[0] = boxes[0];
			new_fine = count_fine_for_all(current_order, array_size);
			if (new_fine < minimal_fine)
			{
				if (new_fine < current_fine)
				{
					current_fine = new_fine;
					order_to_return = current_order;
				}
			}
		}

	}
	fine_val = minimal_fine;
	return order_to_return;
}

int count_fine_for_all(Box boxes[], int array_size)
{
	if (boxes == nullptr) return 0;
	int i = 0;
	int temp;
	int val_to_return = count_fine_for_pair(Box(0, 0), boxes[i]);	// kara - pierwsze pudelko jest skrajne..
	for (i; i < array_size; ++i)
	{
		if ((i+1) == array_size)					// ostatnie pudelko parujemy z 'pud.' 0x0
		{
			temp = count_fine_for_pair(boxes[i], Box(0, 0));
		}
		else
		{
			temp = count_fine_for_pair(boxes[i], boxes[i+1]);
		}
		val_to_return = val_to_return + temp;
	}
	return val_to_return;
}
