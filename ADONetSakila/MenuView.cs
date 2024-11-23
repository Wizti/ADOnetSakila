using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetSakila
{
    internal class MenuView
    {
        private readonly Controller _controller;

        public MenuView(Controller controller)
        {
            _controller = controller;
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("###   Welcome to search Movie by actor   ###");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Search movie by enter first or lastname.");
            Console.WriteLine("2. Quit");

            HandleInput(Console.ReadLine());                       
        }

        public void HandleInput(string input)
        {
            switch (input)
            {
                case "1":
                    SearchView();
                    break;
                case "2":
                    Console.WriteLine("Goodbye");
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Not a valid choice. Enter to return.");
                    Console.ReadLine();
                    Show();
                    break;
            }
        }

        public void SearchView()
        {
            Console.Clear();
            Console.Write("Enter actor firstname: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter actor lastname: ");
            var lastName = Console.ReadLine();       
            

            ShowSearchResult(_controller.HandleSearchMovieByActor(firstName, lastName));
        }

        private void ShowSearchResult(List<string> searchResult)
        {

            Console.WriteLine("--- Films by Actor ---");
            Console.WriteLine("----------------------");

            foreach (var searchResultItem in searchResult)
            {
                Console.WriteLine(searchResultItem);
                Console.WriteLine(new string('-', 40));
            }
            Console.ReadLine();
        }
    }
}
