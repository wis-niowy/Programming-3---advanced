#ifndef ABOOK_H
#define ABOOK_H

#include <string>
#include <vector>
#include <ostream>
#include <functional>
//--


namespace lab3
{
class entry
    {
        // Nie wolno dodawać lub zmieniać składowych tej klasy,
        // ani definiować dla niej operatorów poza nią.
    public:
        std::string first_name;
        std::string last_name;
        std::vector<unsigned char> phone_number;

        inline entry(const std::string& first_name, const std::string& last_name, const std::vector<unsigned char>& phone_number)
            : first_name(first_name), last_name(last_name), phone_number(phone_number) {}
        entry(unsigned int random_number);

    };

std::ostream& operator<<(std::ostream& out, const entry& entry);


class address_book
    {
    public:
        std::vector<entry> entries;
        friend std::ostream& operator<<(std::ostream& out, const address_book& abook);

        void add_entry(const entry& e);

		address_book last_names_sarting_with(char _c);
		int sort_by_first_name();
		int sort_by_lastfirst_name();

		address_book shorten_first_last_name(int);
		int count_phone_numbers_ending_with(int);

		bool do_address_books_contains_same_names(const address_book& book);
    };

}



#endif /* ABOOK_H */
