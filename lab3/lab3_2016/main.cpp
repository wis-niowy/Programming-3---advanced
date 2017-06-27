#include <iostream>
#include <algorithm>
#include <iterator>

#include "abook.h"

using namespace lab3;

using std::cout;
using std::endl;


int main(int argc, char** argv)
    {
    address_book book1;

    book1.add_entry(entry("Boleslaw","Chrobry", {3,14,76,97,23,1}));
    book1.add_entry(entry("Kazimierz","Odnowiciel", {5,2,1,1,1,1,67}));
    book1.add_entry(entry("Wladyslaw","Warnenczyk", {1,2,3}));
    book1.add_entry(entry("Kazimierz", "Waza", {1,2,3}));
    book1.add_entry(entry("Wladyslaw", "Jagiello", {3,3,3}));
    book1.add_entry(entry("Jan", "Sobieski", {1,2,3}));
    book1.add_entry(entry("Zygmunt", "Waza", {1,2,5,6,99,1}));

    cout << "Stan poczatkowy\n" << book1 << endl;

    // Etap 1

     cout << "Etap 1" << endl;
     cout << "Nazwiska na W\n" << book1.last_names_sarting_with('W');
     cout << "Nazwiska na O\n" << book1.last_names_sarting_with('O');
     cout << "Nazwiska na X\n" << book1.last_names_sarting_with('X');
     cout << endl;
// Etap 2

     cout << "Etap 2" << endl;
     int seed=5422;

	 auto rng = [seed]()mutable->int {
		 return seed * 571 + 59;
	 };// Tu wpisać lambdę generującą ciąg losowy podany w zadaniu.
     //Lambda nie może modyfikować num. Nie można dodać w main dodatkowcyh zmiennych.
	 
     address_book random1, random2, random3;

     //Tu wygenerować po 5 wpisów w random1,2,3 z użyciem elementów ciągu losowego
     //Szczegóły w treści zadania.

     cout << random1 << endl;
     cout << random2 << endl;
     cout << random3 << endl;
     cout << endl;

// Etap 3
     cout << "Etap 3" << endl;
     cout << "Sort by first name -- porównan: " << book1.sort_by_first_name() << endl;
     cout << "Wyniki sortowania\n" << book1 << endl;

     cout << "Sort by last,first name -- porównan: " << book1.sort_by_lastfirst_name() << endl;
     cout << "Wyniki sortowania\n" << book1 << endl;
     cout << endl;

// Etap 4
     cout << "Etap 4" << endl;
     cout << "Shorten name 3\n" << book1.shorten_first_last_name(3) << endl;
     cout << "Shorten name 5\n" << book1.shorten_first_last_name(5) << endl;

     cout << "Count even phone numbers 3\n" << book1.count_phone_numbers_ending_with(3) << endl;
     cout << "Count even phone numbers 1\n" << book1.count_phone_numbers_ending_with(1) << endl;
     cout << endl;
// Etap 5

     cout << "Etap 5" << endl;
     address_book book2;

     book2.add_entry(entry("Boleslaw","Chrobry", {3,14,76,97,23,1}));
     book2.add_entry(entry("Kazimierz","Odnowiciel", {5,2,1,1,1,1,67}));
     book2.add_entry(entry("Wladyslaw","Warnenczyk", {1,2,3}));
     book2.add_entry(entry("Kazimierz", "Waza", {1,2,3}));
     book2.add_entry(entry("Wladyslaw", "Jagiello", {1,1,1}));
     book2.add_entry(entry("Jan", "Sobieski", {1,2,3}));
     book2.add_entry(entry("Zygmunt", "Waza", {1,2,5,6,99,1}));

     address_book book3;

     book3.add_entry(entry("Boleslaw","Chrobry", {3,14,76,97,23,1}));
     book3.add_entry(entry("Kazimierz","Odnowiciel", {5,2,1,1,1,1,67}));
     book3.add_entry(entry("Wladyslaw","Warnenczyk", {1,2,3}));
     book3.add_entry(entry("Jan", "Sobieski", {1,2,3}));
     book3.add_entry(entry("Zygmunt", "Waza", {1,2,5,6,99,1}));

     address_book book4;

     book4.add_entry(entry("Boleslaw","Chrobry", {3,14,76,97,23,1}));
     book4.add_entry(entry("Kazimierz","Odnowiciel", {5,2,1,1,1,1,67}));
     book4.add_entry(entry("Wladyslaw","Warnenczyk", {1,2,3}));
     book4.add_entry(entry("Wladyslaw", "Jagiello", {3,3,3}));
     book4.add_entry(entry("Jan", "Sobieski", {1,2,3}));
     book4.add_entry(entry("Zygmunt", "Waza", {1,2,5,6,99,1}));
     book4.add_entry(entry("Aleksander", "Wielki", {1,2,5,6,99,1}));

     address_book book5;

     book5.add_entry(entry("Boleslaw","Chrobry", {3,14,76,97,23,1}));
     book5.add_entry(entry("Kazimierz","Odnowiciel", {5,2,1,1,1,1,67}));
     book5.add_entry(entry("Wladyslaw","Warnenczyk", {1,2,3}));
     book5.add_entry(entry("Kazimierz", "Waza", {1,2,3}));
     book5.add_entry(entry("Wladyslaw", "Jagiello", {1,1,1}));
     book5.add_entry(entry("Jan", "Sobieski", {1,2,3}));
     book5.add_entry(entry("Zygmunt", "Waza", {1,2,5,6,99,1}));
     book5.add_entry(entry("Aleksander", "Wielki", {1,2,5,6,99,1}));


     cout << "Same names " << book1.do_address_books_contains_same_names(book2) << " powinno byc 1" << endl;
     cout << "Same names " << book1.do_address_books_contains_same_names(book3) << " powinno byc 0" << endl;
     cout << "Same names " << book1.do_address_books_contains_same_names(book4) << " powinno byc 0" << endl;
     cout << "Same names " << book1.do_address_books_contains_same_names(book5) << " powinno byc 0" << endl;

    return 0;
    }


