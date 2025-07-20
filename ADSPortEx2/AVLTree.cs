using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //AVL Tree implementation for Assessed Exercise 2

    //Hints : 
    //Use lecture materials from Week 6A
    // and lab sheet 'Lab 6: AVL Trees' to aid with implementation...

    //You may need to adjust your other tree classes to allow your AVL tree
    // access to certain attributes and functions

    //See Lecture 5B for pointers for how to implement node removal within your tree

    //And don't forget to properly check and test your rotations, it's the whole point
    // of AVL Trees!

    // - Adam.M 

    class AVLTree<T> : BSTree<T> where T : IComparable
    {

        //Functions for EX.2C
        public new void InsertItem(T item)
        {
            root = InsertAndBalance(item, root);
        }

        private Node<T> InsertAndBalance(T item, Node<T> node)
        {
            if (node == null) return new Node<T>(item);

            int compare = item.CompareTo(node.Data);

            if (compare < 0)
                node.Left = InsertAndBalance(item, node.Left);
            else if (compare > 0)
                node.Right = InsertAndBalance(item, node.Right);
            else
            {
                Console.WriteLine("\nFilm With This Title Already In Tree.");
            }
            return Balance(node);
        }

        // Balancing logic
        private Node<T> Balance(Node<T> node)
        {
            int balance = Height(node.Left) - Height(node.Right);

            if (balance > 1)
            {
                if (Height(node.Left.Left) >= Height(node.Left.Right))
                    node = RotateRight(node); // LL
                else
                    node = RotateLeftRight(node); // LR
            }
            else if (balance < -1)
            {
                if (Height(node.Right.Right) >= Height(node.Right.Left))
                    node = RotateLeft(node); // RR
                else
                    node = RotateRightLeft(node); // RL
            }

            return node;
        }

        private Node<T> RotateRight(Node<T> y)
        {
            Node<T> x = y.Left;
            y.Left = x.Right;
            x.Right = y;
            return x;
        }

        private Node<T> RotateLeft(Node<T> x)
        {
            Node<T> y = x.Right;
            x.Right = y.Left;
            y.Left = x;
            return y;
        }

        private Node<T> RotateLeftRight(Node<T> node)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        private Node<T> RotateRightLeft(Node<T> node)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }
        private int Height(Node<T> node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        public new void RemoveItem(T item)
        {
            root = RemoveAndBalance(item, root);
        }

        private Node<T> RemoveAndBalance(T item, Node<T> node)
        {
            if (node == null) return null;

            int compare = item.CompareTo(node.Data);

            if (compare < 0)
            {
                node.Left = RemoveAndBalance(item, node.Left);
            }
            else if (compare > 0)
            {
                node.Right = RemoveAndBalance(item, node.Right);
            }
            else
            {
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;
                else
                {
                    Node<T> minNode = FindSmallest(node.Right);
                    node.Data = minNode.Data;
                    node.Right = RemoveAndBalance(minNode.Data, node.Right);
                }
            }

            return Balance(node);
        }

        private Node<T> FindSmallest(Node<T> node)
        {
            while (node.Left != null)
                node = node.Left;
            return node;
        }

        //Free space, use as required






    }// End of class
}
