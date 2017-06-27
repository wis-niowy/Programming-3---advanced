#include "abook.h"

#include <iterator>
#include <algorithm>
#include <numeric>
#include <functional>

using lab3::address_book;
using lab3::entry;

static  std::ostream& operator<<(std::ostream& out, const std::vector<unsigned char>& v)
    {
    auto it = std::ostream_iterator<int>(out, " ");
    std::copy(v.begin(), v.end(), it);
    return out;
    }

std::ostream& lab3::operator<<(std::ostream& out, const lab3::entry& entry)
    {
    using ::operator<<;
    return out << entry.first_name << " " << entry.last_name << ": " << entry.phone_number;
    }

std::ostream& lab3::operator<<(std::ostream& out, const lab3::address_book& abook)
    {
    auto it = std::ostream_iterator<lab3::entry>(out, "\n");
    std::copy(abook.entries.begin(), abook.entries.end(), it);
    return out;
    }


#define ALEN(array) (sizeof(array)/sizeof(array[0]))

static std::string fn[] = {"Pies", "Myszka", "Kaczor", "Tunczyk", "Makrela"};
static std::string ln[] = {"Pluto", "Miki", "Donald"};

static std::vector<unsigned char> random_phone(int num)
    {
    std::vector<unsigned char> pn;
    while(num>1)
        {
        pn.push_back(num%150);
        num/=150;
        }
    return pn;
    }

lab3::entry::entry(unsigned int random_number) : first_name(fn[random_number%ALEN(fn)]),
    last_name(ln[random_number%ALEN(ln)]),
    phone_number(random_phone(random_number))
    {
    }

void lab3::address_book::add_entry(const entry& e)
    {
    entries.push_back(e);
    }

#undef ALEN

//---

address_book address_book::last_names_sarting_with(char _c)
{
	address_book to_return;
	std::copy_if(entries.begin(), entries.end(), std::back_inserter(to_return.entries),
		[_c](const entry& _en)->bool {
		if (_en.last_name[0] == _c)
			return true;
		else return false;
	});
	return to_return;
}

int address_book::sort_by_first_name()
{
	int counter = 0;
	std::sort(entries.begin(), entries.end(), [&counter](const entry& _en1, const entry& _en2)->bool {
		if (_en1.first_name < _en2.first_name)
		{
			counter++;
			return true;
		}
		else
		{
			counter++;
			return false;
		}
	});
	return counter;
}

int address_book::sort_by_lastfirst_name()
{
	int counter = 0;
	std::sort(entries.begin(), entries.end(), [&counter](const entry& _en1, const entry& _en2)->bool {
		//counter++;
		if (_en1.last_name < _en2.last_name)
		{
			counter++;
			return true;
		}
		else if (_en1.last_name == _en2.last_name)
		{
			counter++;
			if (_en1.first_name < _en2.first_name)
			{
				counter++;
				return true;
			}
		}
		else
		{
			counter++;
			return false;
		}
	});
	return counter;
}

address_book address_book::shorten_first_last_name(int i)
{
	address_book to_return;
	std::transform(entries.begin(), entries.end(), std::back_inserter(to_return.entries),
		[i](const entry& _en)->entry {
		entry el(_en.first_name.substr(0,i), _en.last_name.substr(0,i), _en.phone_number);
		return el;
	});
	return to_return;
}

int address_book::count_phone_numbers_ending_with(int i)
{
	int counter = std::count_if(entries.begin(), entries.end(), [i](const entry& _en)->bool {
		if (*(_en.phone_number.rbegin()) == i)
			return true;
	});
	return counter;
}

bool address_book::do_address_books_contains_same_names(const address_book& book)
{
	if (this->entries.size() != book.entries.size())
		return false;

	return std::is_permutation(this->entries.begin(), this->entries.end(), book.entries.begin(),
		book.entries.end(), [](const entry& e1, const entry& e2)->bool {
		if (e1.first_name == e2.first_name && e1.last_name == e2.last_name)
			return true;
		else return false;
	});
}