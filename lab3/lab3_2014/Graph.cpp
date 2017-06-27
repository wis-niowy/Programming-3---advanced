
#define _CRT_SECURE_NO_WARNINGS
#include "Graph.h"
// Tu dopisz implementacje

bool Graph::AddNode(int n)
{
	if (nodes.find(n) != nodes.end())		// wezel juz jest w grafie
		return false;
	else
	{
		pair<int, map<int, int>> to_push;
		to_push.first = n;
		nodes.insert(to_push);
		return true;
	}
}

bool Graph::AddEdge(int n1, int n2, int w)
{
	if (n1 == n2)								//n1 i n2 to to samo
		return false;
	else if (nodes.find(n1) == nodes.end())		//nie ma n1
		return false;
	else if (nodes.find(n2) == nodes.end())		//nie ma n2
		return false;
	else
	{
		map<int, map<int, int>>::iterator it = nodes.find(n1);
		if (it->second.find(n2) != it->second.end())			// krawedz juz istnieje
		{
			return false;
		}

		it->second.insert(make_pair(n2, w));					// dodajemy krawedz
		return true;
	}
}

bool Graph::DelNode(int n)
{
	if (nodes.find(n) == nodes.end())
		return false;
	else
	{
		// usuwamy wezel
		nodes.erase(nodes.find(n));
		// usuwamy krawedzie incydentne
		for_each(nodes.begin(), nodes.end(), [&n](pair<const int, map<int, int>>& node)->void {
			// CONST przed kluczem bo on jest NIEZMIENIALNY !!!!!!!!!!!!!!!!!!!!!!
			if (node.second.find(n) != node.second.end())
			{
				node.second.erase(n);
			}
		});
		return true;
	}
}

bool Graph::DelEdge(int n1, int n2)		// krawedz n1 --> n2
{
	if (n1 == n2)
		return false;
	else if (nodes.find(n1) == nodes.end())		//nie ma n1
		return false;
	else if (nodes.find(n2) == nodes.end())		//nie ma n2
		return false;
	else
	{
		map<int, map<int, int>>::iterator it = nodes.find(n1);
		if (it->second.find(n2) == it->second.end())
			return false;
		it->second.erase(it->second.find(n2));
		return true;
	}
}

Graph Graph::Reverse(const Graph& g)
{
	Graph kopia;
	for_each(g.nodes.begin(), g.nodes.end(), [&kopia](const pair<int,map<int,int>> node)->void {
		kopia.AddNode(node.first);
	}); // prezpisujemy wezly

	for_each(g.nodes.begin(), g.nodes.end(), [&kopia](const pair<int,map<int,int>>& node)->void {
		for_each(node.second.begin(), node.second.end(), [&kopia, dest = node.first](const pair<int,int>& edge)->void {
			kopia.AddEdge(edge.first, dest, edge.second);
		});
	});
	return kopia;
}

ostream& operator<<(ostream &out, const Graph& g)
{
	map<int, map<int, int>>::const_iterator it1 = g.nodes.begin();
	map<int, map<int, int>>::const_iterator it2 = g.nodes.end();
	for_each(it1, it2, [&out](const pair<int, map<int,int>>& node)->void {
		out << node.first << ":  ";

		for_each(node.second.begin(), node.second.end(), [&out](const pair<int, int>& edges)->void {
			out << "(" << edges.first << "," << edges.second << ") ";
		});
		cout << ";" << endl;
	});
	return out;
}

istream& operator>>(istream &in, Graph& g)
{
	string line;
	while (!in.eof())
	{
		getline(in, line);
		if (line == "") break; // ??????????????????????????!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		size_t j = line.find(':'), i;
		string graph_first(line.begin(), line.begin() + j);		//wartosc wezla
		if (g.nodes.find(stoi(graph_first)) != g.nodes.end())	// jesli istnieje wezel to go zastepujemy
			g.nodes.erase(g.nodes.find(stoi(graph_first)));
		g.AddNode(stoi(graph_first));
		i = j + 1;
		while (true)
		{
			j = line.find('(', i);
			if (j == string::npos)
				break;
			i = j + 1;
			j = line.find(',', i);
			string edge_first(line.begin() + i, line.begin() + j);
			if (g.nodes.find(stoi(edge_first)) == g.nodes.end())	// nie ma docelowego wezla w grafie
				g.AddNode(stoi(edge_first));
			i = j + 1;
			j = line.find(')', i);
			string edge_second(line.begin() + i, line.begin() + j);
			g.AddEdge(stoi(graph_first), stoi(edge_first), stoi(edge_second));
		}
	}
	return in;
}