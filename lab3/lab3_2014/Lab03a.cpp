
#include <fstream>

#include "graph.h"

void main()
    {

    cout << endl ;
    cout << "***** Etap 1 *****" << endl ;  // 2 pkt
    cout << endl ;
    Graph g;
    cout << "Dodawanie wierzcholka 1:   " << g.AddNode(1) << endl;
    cout << "Dodawanie wierzcholka 3:   " << g.AddNode(3) << endl;
    cout << "Dodawanie wierzcholka 3:   " << g.AddNode(3) << endl;
    cout << "Dodawanie wierzcholka 15:  " << g.AddNode(15) << endl;
    cout << "Dodawanie wierzcholka 5:   " << g.AddNode(5) << endl;
    cout << "Dodawanie wierzcholka 2:   " << g.AddNode(2) << endl;
    cout << endl ;
    cout << "Dodawanie krawedzi 1->2:   " << g.AddEdge(1,2,5) << endl;
    cout << "Dodawanie krawedzi 5->3:   " << g.AddEdge(5,3,-2) << endl;
    cout << "Dodawanie krawedzi 4->2:   " << g.AddEdge(4,2,1) << endl;
    cout << "Dodawanie krawedzi 3->6:   " << g.AddEdge(3,6,2) << endl;
    cout << "Dodawanie krawedzi 5->5:   " << g.AddEdge(5,5,0) << endl;
    cout << "Dodawanie krawedzi 1->2:   " << g.AddEdge(1,2,7) << endl;
    cout << "Dodawanie krawedzi 2->1:   " << g.AddEdge(2,1,3) << endl;
    cout << "Dodawanie krawedzi 2->3:   " << g.AddEdge(2,3,4) << endl;
    cout << "Dodawanie krawedzi 2->5:   " << g.AddEdge(2,5,5) << endl;
    cout << "Dodawanie krawedzi 15->3:  " << g.AddEdge(15,3,0) << endl;
    cout << endl ;
    cout << "Graf g" << endl ;
    cout << g ;
    cout << endl ;
    cout << "Usuwanie krawedzi 2->5:   " << g.DelEdge(2,5) << endl;
    cout << "Usuwanie krawedzi 2->5:   " << g.DelEdge(2,5) << endl;
    cout << "Usuwanie krawedzi 4->2:   " << g.DelEdge(4,2) << endl;
    cout << "Usuwanie krawedzi 3->6:   " << g.DelEdge(3,6) << endl;
    cout << "Usuwanie krawedzi 5->5:   " << g.DelEdge(5,5) << endl;
    cout << endl ;
    cout << "Graf g po usunieciu krawedzi 2->5" << endl ;
    cout << g ;

    cout << endl ;
    cout << "***** Etap 2 *****" << endl ;  // 1 pkt
    cout << endl ;
    Graph g2=g;
    cout << "Usuwanie wierzcholka 10:  " << g.DelNode(10) << endl;
    cout << "Graf g po usunieciu wierzcholka 10" << endl ;
	cout << g << endl ;
    cout << "Usuwanie wierzcholka 15:  " << g.DelNode(15) << endl;
    cout << "Graf g po usunieciu wierzcholka 15" << endl ;
    cout << g << endl ;
    cout << "Usuwanie wierzcholka 3:  " << g.DelNode(3) << endl;
    cout << "Graf g po usunieciu wierzcholka 3" << endl ;
    cout << g << endl ;
    cout << "Usuwanie wierzcholka 2:  " << g.DelNode(2) << endl;
    cout << "Graf g po usunieciu wierzcholka 2" << endl ;
    cout << g ;

    cout << endl ;
    cout << "***** Etap 3 *****" << endl ;  // 1 pkt
    cout << endl ;
    g=g2;
    g2=Graph::Reverse(g);
    cout << "Graf odwrotny do g" << endl ;
    cout << g2 ;

    cout << endl ;
    cout << "***** Etap 4 *****" << endl ;  // 1 pkt
    cout << endl ;
    ifstream f;
    f.open("Graph.txt");
    if ( f.fail() )
        cout << "Blad otwarcia pliku Graph.txt" << endl ;
    else
        {
        g.AddNode(30);
        f>>g;
        f.close();
        cout << "Graf wczytany z pliku" << endl ;
        cout << g ;
        }

    cout << endl ;
    cout << "***** Koniec *****" << endl ;
    cout << endl ;
    }
