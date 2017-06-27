
// W tym pliku nic nie zmieniamy !!!

#include <iostream>
#include <map>
#include <algorithm>
#include <string>

using namespace std;

class Graph
    {
    public:
    bool AddNode(int n);                                       // false gdy juz jest
    bool AddEdge(int n1, int n2, int w);                       // false gdy krawedz juz jest lub nie ma ktoregos z wierzcholkow lub n1==n2
    bool DelNode(int n);                                       // false gdy nie ma (usuwa wszystkie "przylegle" krawedzie)
    bool DelEdge(int n1, int n2);                              // false gdy krawedzi nie ma lub nie ma ktoregos z wierzcholkow lub n1==n2
    static Graph Reverse(const Graph& g);                      // tworzy Graph z odworoconymi kierunkami krawedzi
    friend ostream& operator<<(ostream &out, const Graph& g);
    friend istream& operator>>(istream &in, Graph& g);         // format danych wejsciowych taki jak wyjscie poprzedniej funkcji

    private:
    map<int,map<int,int>> nodes;
    };

