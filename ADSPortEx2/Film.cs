using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    //Film class implementation for Assessed Exercise 2

    class Film : IComparable
    {
        private string title;
        private string director;
        private int quantity;
        public Film()
        {
            throw new NotImplementedException();
        }

        public Film(string title, string director, int quantity)
        {
            this.title = title;
            this.director = director;
            this.quantity = quantity;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int CompareTo(object obj)
        {
            Film other = obj as Film;
            return Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return $"Title: {Title}, Director: {Director}, Quantity: {Quantity}";
        }

    }// End of class
}
