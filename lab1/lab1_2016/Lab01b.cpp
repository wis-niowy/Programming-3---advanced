
#include <iostream>
#include "BST.h"

using namespace std;

void main()
    {
    
    bool b;
    BST t0, t1, tw, tp;

    cout << "PUSTE DRZEWO" << endl;

    cout << t0;
    cout << " #" << endl;
	
    b=t0.Remove(10);
    cout << "kasowanie: " << (b?"true":"false") << endl;

    cout << endl << "DRZEWO 1-ELEMENTOWE" << endl;

    b=t1.Insert(10);
    cout << "wstawianie: " << (b?"true":"false") << endl;

    cout << t1;
    cout <<" #" << endl;

    b=t1.Remove(10);
    cout<<"kasowanie: " << (b?"true":"false") << endl;

    cout << t1;
    cout << " #" << endl;

    b=t1.Remove(10);
    cout << "kasowanie: " << (b?"true":"false") << endl;

    cout << endl << "DRZEWO WIELOELEMENTOWE" << endl;
	
    tw.Insert(10);
    tw.Insert(20);
    tw.Insert(15);
    tw.Insert(30);
    tw.Insert(5);
    tw.Insert(10);
    tw.Insert(25);
    tw.Insert(15);
    tw.Insert(35);
    tw.Insert(27);
    tw.Insert(32);
    tw.Insert(7);
    tw.Insert(10);
    tw.Insert(15);

    BST tk=tw;
    tp=tw;

    cout << tw;
    cout << " #" << endl;

    b=tw.Remove(30);
    cout << "kasowanie: " << (b?"true":"false") << endl;

    cout << tw;
    cout << " #" << endl;

    b=tw.Remove(30);
    cout << "kasowanie: " << (b?"true":"false") << endl;

    cout << tw;
    cout << " #" << endl;

    b=tw.Insert(30);
    cout << "wstawianie: " << (b?"true":"false") << endl;

    cout << tw;
    cout << " #" << endl;

    b=tw.Insert(30);
    cout << "wstawianie: " << (b?"true":"false") << endl;

    cout << tw;
    cout << " #" << endl;

    cout << endl << "KOPIOWANIE DRZEW" << endl;

    tk.Remove(10);
    tk.Remove(20);
    tk.Remove(30);
    tk.Remove(10);
    cout << tw;
    cout << " #" << endl;
    cout << tk;
    cout << " #" << endl;
    cout << tp;
    cout << " #" << endl;

    cout << endl;
    tp.Remove(10);
    tp.Remove(30);
    tp.Insert(20);
    cout << tw;
    cout << " #" << endl;
    cout << tk;
    cout << " #" << endl;
    cout << tp;
    cout << " #" << endl;
    

    cout << endl << "KONIEC" << endl << endl;
    }
