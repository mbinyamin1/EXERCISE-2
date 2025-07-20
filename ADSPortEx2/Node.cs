using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Node (tree) implementation for Assessed Exercise 2

    //Hints : 
    //Use lecture materials from Week 4B
    // and lab sheet 'Lab 5: BinTree and BSTree' to aid with implementation...

    class Node<T> where T : IComparable
    {
        private T data;
        public Node<T> Left, Right;
        public Node(T item)
        {
            data = item;
            Left = null;
            Right = null;
        }

        public T Data
        {
            get { return data; } 
            set { data = value; }
        }

    } // End of class
}
