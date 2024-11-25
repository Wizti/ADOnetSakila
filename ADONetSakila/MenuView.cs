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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("###   Welcome to search Movie by actor   ###");            
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Search movie by enter first and lasttname.");
            Console.WriteLine("2. Quit");
            Console.WriteLine();
            Console.Write("-> ");

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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Films by Actor ---\n");
            Console.ForegroundColor= ConsoleColor.White;

            foreach (var searchResultItem in searchResult)
            {
                Console.WriteLine(searchResultItem);
                Console.ForegroundColor= ConsoleColor.Magenta;
                Console.WriteLine(new string('-', 40));
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n Enter for menu -> ");
            Console.ReadLine();    
            Show();
        }
    }
}
