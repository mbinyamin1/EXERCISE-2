using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Binary Search Tree implementation for Assessed Exercise 2

    //Hints : 
    //Use lecture materials from Week 5
    // and lab sheet 'Lab 5: BinTree and BSTree' to aid with implementation...

    //For the Update function for 2B, consider the different cases that could occur
    // during your insert recursion and consider how you could navigate your tree to find
    // the correct entry to change...

    // - Adam.M 

    class BSTree<T> : BinTree<T> where T : IComparable
    {

        public BSTree()
        {
            root = null;
        }

        //Functions for EX.2A
        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                tree = new Node<T>(item);
            }
            else if (item.CompareTo(tree.Data) < 0)
            {
                insertItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Data) > 0)
            {
                insertItem((T)item, ref tree.Right);
            }
            else
            {
                Console.WriteLine("\nFilm With This Title Already In Tree.");
            }
        }

        public int Height()
        {
            return height(root);
        }

        private int height(Node<T> tree)
        {
            if (tree == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(height(tree.Left), height(tree.Right));
            }
        }

        //Functions for EX.2B

        public int Count()
        {
            return count(root);
        }

        private int count(Node<T> tree)
        {
            if (tree == null)
                return 0;
            else
                return 1 + count(tree.Left) + count(tree.Right);
        }

        public void Update(T item, T newItem)
        {
            updateItem(root, item, newItem);
        }

        private void updateItem(Node<T> tree, T item, T newItem)
        {
            if (tree == null)
            {
                Console.WriteLine("\nFilm With This Title Not Found.");
                return;
            }

            if (item.CompareTo(tree.Data) == 0)
            {
                tree.Data = newItem;
                Console.WriteLine("\nFilm Has Been Updated Successfully.");
            }
            else if (item.CompareTo(tree.Data) < 0)
            {
                updateItem(tree.Left, item, newItem);
            }
            else
            {
                updateItem(tree.Right, item, newItem);
            }
        }

        //Free space, use as necessary to address task requirements... 





    }// End of class
}
