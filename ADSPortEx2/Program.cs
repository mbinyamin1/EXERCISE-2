using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{
    internal class Program
    {

        static AVLTree<Film> tree = new AVLTree<Film>();
        static void Main(string[] args)
        {


            //Create a Menu driven interface here so a user can interact with your implementations

            //I.e. while(true){
            // print to user - "Select an option"
            // "1. Add item to tree"
            // "2. Display all items... ect
            //}

            while (true)
            {

                Console.WriteLine("\n1. Add A New Film");
                Console.WriteLine("2. Show InOrder Traversal");
                Console.WriteLine("3. Show PreOrder Traversal");
                Console.WriteLine("4. Show PostOrder Traversal");
                Console.WriteLine("5. Display Tree Height");
                Console.WriteLine("6. Total Films");
                Console.WriteLine("7. Update Film Details");
                Console.WriteLine("8. Remove Film");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                if (choice == "1") AddFilm();
                else if (choice == "2") ShowInOrder();
                else if (choice == "3") ShowPreOrder();
                else if (choice == "4") ShowPostOrder();
                else if (choice == "5") DisplayHeight();
                else if (choice == "6") TotalFilms();
                else if (choice == "7") UpdateFilm();
                else if (choice == "8") RemoveFilm();
                else if (choice == "0") { Console.WriteLine("\nPress Enter Again To Exit");  break; }

                else Console.WriteLine("\nInvalid Choice. Please Try Again.");
            }

            Console.ReadLine();

        }

        static void AddFilm()
        {

            Console.Write("\nEnter Film Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Film Director: ");
            string director = Console.ReadLine();
            Console.Write("Enter Quantity: ");
            string intquantity = Console.ReadLine();

            if (int.TryParse(intquantity, out int quantity))
            {
                Film newFilm = new Film(title, director, quantity);

                int previousCount = tree.Count();
                tree.InsertItem(newFilm);

                if (tree.Count() > previousCount)
                {
                    Console.WriteLine("\nFilm Has been Added Successfully.");
                }
            }
            else
            {
                Console.WriteLine("\nQuantity Should Be In Numbers.");
            }

        }

        static void ShowInOrder()
        {
            string buffer = "";
            tree.InOrder(ref buffer);
            Console.WriteLine("\nInOrder: " + buffer);
        }

        static void ShowPreOrder()
        {
            string buffer = "";
            tree.PreOrder(ref buffer);
            Console.WriteLine("\nPreOrder: " + buffer);
        }

        static void ShowPostOrder()
        {
            string buffer = "";
            tree.PostOrder(ref buffer);
            Console.WriteLine("\nPostOrder: " + buffer);
        }

        static void DisplayHeight()
        {
            Console.WriteLine("\nTree Height: " + tree.Height());
        }

        static void TotalFilms()
        {
            int count = tree.Count();
            Console.WriteLine($"\nTotal Film/s In The Tree: {count}");
        }

        static void UpdateFilm()
        {
            if (tree.Count() == 0)
            {
                Console.WriteLine("\nTree Is Empty, Nothing To Update.");
                return;
            }

            Console.Write("\nTitle Of The Film To Update: ");
            string previousTitle = Console.ReadLine();

            Console.Write("New Title: ");
            string newTitle = Console.ReadLine();

            Console.Write("New Director: ");
            string newDirector = Console.ReadLine();

            Console.Write("New Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int newQuantity))
            {
                if (previousTitle != newTitle)
                {
                    // Check if a film with the new title already exists
                    string checkBuffer = "";
                    tree.InOrder(ref checkBuffer);
                    if (checkBuffer.Contains(newTitle))
                    {
                        Console.WriteLine("\nFim With This Title Already Exist, Hence Cannot update.");
                        return;
                    }
                }

                Film previousFilm = new Film(previousTitle, "", 0);
                Film updatedFilm = new Film(newTitle, newDirector, newQuantity);

                tree.Update(previousFilm, updatedFilm);
            }
            else
            {
                Console.WriteLine("\nQuantity Should Be In Numbers");
            }
        }

        static void RemoveFilm()
        {
            if (tree.Count() == 0)
            {
                Console.WriteLine("\nTree Is Empty, Nothing To Remove.");
                return;
            }

            Console.Write("\nEnter Title Of The Film To Remove: ");
            string title = Console.ReadLine();

            string buffer = "";
            tree.InOrder(ref buffer);

            if (!buffer.Contains(title))
            {
                Console.WriteLine($"\nFilm '{title}' Not Found In The Tree.");
                return;
            }

            Film film = new Film(title, "", 0);
            tree.RemoveItem(film);
            Console.WriteLine($"\nFilm '{title}' Has Been Removed Successfully.");
        }

    }
}
