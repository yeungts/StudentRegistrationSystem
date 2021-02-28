namespace Assignment1.Models.ViewModels
{
    public class RepoViewModel
    {
        public Repository Repo { get; }

        public RepoViewModel()
        {
            Repo = Repository.Instance;
        }
    }
}
