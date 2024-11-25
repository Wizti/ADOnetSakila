namespace ADONetSakila
{
    internal class Controller
    {
        private readonly ActorRepository _actorRepository;
        private readonly MenuView _menuView;
        public Controller(ActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
            _menuView = new MenuView(this);
        }

        public void Run()
        {
            _menuView.Show();
        }

        public List<string> HandleSearchMovieByActor(string firstName, string lastName)
        {
            return _actorRepository.GetAllFilmsByActor(firstName, lastName);
        }
    }
}
