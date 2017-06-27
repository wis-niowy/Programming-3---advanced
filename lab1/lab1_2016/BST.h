
#include <iostream>

using namespace std;

// Nie wolno zmieniac interfejsu publicznego,
// czyli nie wolno z zaden sposob zmieniac sposobu korzystania ze skladowych publicznych
// ani dodawac nowych skladowych publicznych
// 
// Mozna dowolnie zmienic wewnetrzny sposob implementacji,
// czyli mozna calkowicie pozmieniac skladowe prywatne
// (nie ma obowiazku korzystania z zaproponowanych schematow metod)
// Ale musi byc zachowana zasada, ze metoda (publiczna) Remove jedynie zaznacza element jako skasowany,
//
// Punktacja
// - konstruktory, destruktor, operator=   -  1p
// - operator <<                           -  1p
// - metoda Insert                         -  1p
// - metoda Remove                         -  1p

class BST
    {

    // Drzewo BST konstruujemy wedlug zasady
    // - lewe poddrzewo zawiera elementy mniejsze lub rowne od zawartego w danym wezle
    // - prawe poddrzewo zawiera elementy ostro wieksze od zawartego w danym wezle
    // - elementy moga sie powtarzac

    public:
    
    // konstruktor bezparametrowy - tworzy puste drzewo
    BST();

    // konstruktor kopiujacy - tworzy dokladna kopie argumentu
    BST(const BST& b);

    // destruktor - likwiduje drzewo - zapobiega wyciekom pamieci
    ~BST();

    // operator przypisania: lewy argument = dokladna kopia prawego argumentu (uwazac na wycieki pamieci)
    BST& operator=(const BST& b);

    // wypisuje wszystkie nieskasowane elementy drzewa na wskazany strumien od najmniejszego do najwiekszego
    // elementy skasowane pomija
    friend ostream& operator<<(ostream& os, const BST& b);

    // jesli w drzewie jest skasowany element o danej wartosci to go "odkasowuje" i zwraca false
    // jesli w drzewie nie ma skasowanewgo elementu o danej wartosci to go dodaje i zwraca true
    // (pamietamy ze w drzewie ogolnie moze byc wiele (skasowanych lub nie) elementow o tej samej wartosci
    bool Insert(int v);

    // jesli w drzewie jest nieskasowany element o danej wartosci to oznacza go
    //     (jesli jest kilka to jedynie pierwszy z nich) jako skasowany (i zwraca true)
    // jesli w drzewie nie ma nieskasowanewgo elementu o danej wartosci to zwraca false
    // metoda nigdy nie modyfikuje struktury drzewa (co najwyzej oznacza element jako skasowany)
    bool Remove(int v);

    private:

    class Elem
        {
        public:
        int val;
        bool notDeleted;
        Elem *left;
        Elem *right;
        Elem(int v, bool d) { val=v; notDeleted=d; left=right=NULL; }
        };

    typedef Elem *PElem;

    
    static bool insert(PElem& r, int v);

    static bool remove(PElem& r, int v);

    static void show(PElem r, ostream& os);

    static void removeTree(PElem r);

    static PElem copyTree(PElem r);
    

    PElem root;

    }; // class BST
