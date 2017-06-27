

#include "box.h"
#include <iostream>
#include <vector>

using namespace std;

/* W magazynie są ustawiane prostokątne pudła,
 * o wymiarach szerokość x długość (reprezentowane przez klasę Box).
 * Pudła są ustawiane w jednym szeregu, każde nieskrajne pudło ma dokładnie
 * dwóch sąsiadów. Skrajne --- jednego.
 * Zarządca magazynu oczekuje, aby pudła zostały ustawione estetycznie,
 * Ustawienie jest estetyczne, gdy obok siebie stoją pudła podobnych rozmiarów.
 * Aby ułatwić zadanie magazynierowi, zdefiniował dokładnie miarę estetyki
 * ustawienia: dla każdych dwóch sąsiednich pudeł wyliczamy karę za różnicę rozmiarów:
 * Niech jedno z pudeł ma wymiary h1 × w1, drugie  h2 × w2. Kara za ustawienie ich obok siebie
 * wynosi |h1-h2|+|w1-w2| -- suma modułów różnic wymairów.
 * Dodatkowo dla skrajnych pudeł liczymy karę tak, jakby stało obok pudło w wymiarach 0×0.
 * Kara ogólna za całe ustawienie to suma wszystkich kar za ustawienie pudeł obok siebie.
 *
 * Ustawienie będzie estetyczne, gdy kara ogólna będzie jak najmniejsza.
 *
 * Zadanie: napisać program, który dla zadanych wymiarów pudeł znajdzie ich estetyczne ustawienie.
 * Jeśli jest kilka takich -- znajdzie dowolne.
 * Należy wydrukować na konsolę wartość kary dla estetycznego ustawienia oraz kolejność.
 *
 *
 * Podpowiedzi:
 * - można sprawdzać wszystkie możliwe ustawienia pudełek, do tego celu można
 *   wykorzystać rekursję
 *
 * - W niektórych przypadkach możemy stwierdzić, że rozwiązanie będzie gorsze
 *   od najlepszego, zanim policzymy wszystkie kary
 *
 * - Dwa ostatnie przykłady należy uruchamiać bez debugera i wybrać build
 *   ***Release***.
 *
 * ****
 * Nie można modyfikować już napisanych elementów klasy Box (można dodać inne),
 * nie można modyfikować przykładów na początku funkcji main.
 * ****
 *
 * Punktacja:
 *   Poprawne znajdowanie minimalnej kary w mniej niż 2 minuty dla pierwszych trzech przykładów 3p.
 *   Drukowanie znalezionego rozwiązania (kolejność pudełek) 1p.
 *   Poprawne znajdowanie minimalnej kary w mniej niż 2 minuty dla wszystkich przykładów 1p.
 *
 *   Dodatkowy (bonusowy) punkt można dostać za znalezienie i wypisanie wszystkich najlepszych rozwiązań
 *   (i ich liczby). Ten punkt można dostać jednynie po wcześniejszym poprawnym rozwiązaniu całego
 *   podstawowego wariantu zadania.
 */


int main()
{
    Box boxes1[] = {Box ( 4, 4 ), Box ( 5, 5 ), Box ( 3, 3 ) , Box ( 1, 1 ), Box ( 2, 2 ) }; // kara: 20
    Box boxes2[] = {Box ( 1, 5 ), Box ( 5, 1 ), Box ( 2, 4 ), Box ( 4, 2 ), Box ( 3, 3 ) }; //20
    Box boxes3[] = {Box ( 1, 5 ), Box ( 5, 1 ), Box ( 2, 4 ), Box ( 4, 2 ), Box ( 3, 3 ), Box ( 3, 4 ), Box ( 4, 3 ) }; //20
    Box boxes4[] = {Box ( 7, 4 ), Box ( 8, 5 ), Box ( 2, 3 ) , Box ( 1, 1 ), Box ( 2, 7 ), Box ( 9, 6 ), Box ( 10, 12 ),
                    Box ( 1, 10 ), Box ( 10, 1 ), Box ( 5, 5 ), Box ( 14, 16 ), Box ( 1, 20 ), Box ( 20, 1 ) }; //100
    Box boxes5[] = {Box ( 7, 4 ), Box ( 8, 5 ), Box ( 2, 3 ) , Box ( 1, 1 ), Box ( 2, 7 ), Box ( 9, 6 ),
                    Box ( 10, 12 ), Box ( 1, 10 ), Box ( 10, 1 ), Box ( 5, 5 ), Box ( 14, 16 ), Box ( 1, 20 ),
                    Box ( 20, 1 ), Box ( 10, 10 ) }; //100



     // ...   

	int fine_value;
	int array_size;
	Box* box_order;

	array_size = sizeof(boxes1) / sizeof(Box);
	fine_value = count_fine_for_all(boxes1, array_size);
	cout << "starting set fine: Boxes1: " << fine_value << endl;
	box_order = find_optimal_order(boxes1, array_size, fine_value);
	cout << "Optimal set: Boxes1: ";
		for (int i = 0; i < array_size; ++i)
		{
			cout << box_order[i] << " ";
		}
		cout << endl;
	cout << "With fine: " << fine_value << endl;

	array_size = sizeof(boxes2) / sizeof(Box);
	fine_value = count_fine_for_all(boxes2, array_size);
	cout << "starting set fine: Boxes2: " << fine_value << endl;
	/*box_order = find_optimal_order(boxes1, array_size, fine_value);
	cout << "Optimal set: Boxes1: " << box_order << "With fine: " << fine_value << endl;*/

    return 0;
}


