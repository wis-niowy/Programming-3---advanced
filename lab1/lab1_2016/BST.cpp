#include "BST.h"

BST::BST()
{
	this->root = nullptr;
}

BST::~BST()
{
	removeTree(this->root);
}

BST::BST(const BST& a)		// KONSTRUKTOR KOPIUJACY
{
	if (!a.root) return;
	this->root = copyTree(a.root);
}

bool BST::Insert(int v)
{
	if (!this->root)
	{
		this->root = new Elem(v, true);	// brak korzenia - tworzymy korzen
		return true;
	}
	else return BST::insert(this->root, v);
}

bool BST::insert(PElem& r, int v)
{
	if (v == r->val)
	{
		if (!r->notDeleted)			// jest taki sam element nieaktywny - aktywujemy
		{
			r->notDeleted = true;
			return false;
		}
		else
		{
			if (r->left)							// NAIWNIE!!!!
			{
				return BST::insert(r->left, v);
			}
			else
			{
				r->left = new Elem(v, true);
				return true;
			}
		}
	}
	else if (v < r->val) // ?
	{
		if (r->left)
		{
			return BST::insert(r->left, v);
		}
		else
		{
			r->left = new Elem(v, true);
			return true;
		}
	}
	else
	{
		if (r->right)
		{
			return BST::insert(r->right, v);
		}
		else
		{
			r->right = new Elem(v, true);
			return true;
		}
	}
}

bool BST::Remove(int v)
{
	if (!this->root) return false;
	else return BST::remove(this->root, v);
}

bool BST::remove(BST::PElem& r, int v)
{
	if (r->val == v)
	{
		if (r->notDeleted)
		{
			r->notDeleted = false;
			return true;
		}
		else
		{
			if (r->left)
			return BST::remove(r->left, v);
			else return false;
		}
	}
	else if (v < r->val)
	{
		if (r->left)
		return BST::remove(r->left, v);
		else return false;
	}
	else
	{
		if (r->right)
		return BST::remove(r->right, v);
		else return false;
	}
}

BST::PElem BST::copyTree(PElem r)
{
	if (!r) return nullptr;
	BST::PElem new_el = new Elem(r->val, true);
	new_el->left = copyTree(r->left);
	new_el->right = copyTree(r->right);
	return new_el;
}

void BST::removeTree(PElem r)
{
	if (!r) return;
	removeTree(r->left);
	removeTree(r->right);
	delete[] r;
}

void BST::show(PElem r, ostream& out)
{
	if (!r) return;
	BST::show(r->left, out);

	if (r->notDeleted)
	out << r->val << " ";

	BST::show(r->right, out);
}

ostream& operator<< (ostream& out, const BST& r)
{
	if (r.root)
		BST::show(r.root, out);
	return out;
}

BST& BST::operator=(const BST& b)
{
	if (this != &b)
	{
		BST::removeTree(this->root);
		this->root = copyTree(b.root);
		return *this;
	}
}

