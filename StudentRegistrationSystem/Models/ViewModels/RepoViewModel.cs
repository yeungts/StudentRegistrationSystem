namespace StudentRegistrationSystem.Models.ViewModels
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
