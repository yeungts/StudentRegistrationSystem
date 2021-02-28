namespace Assignment1.Models.ViewModels
{
    public class RegFormViewModel : RepoViewModel
    {
        public RegResponse Response { get; set; }

        public RegFormViewModel()
        {
            Response = new RegResponse();
        }
    }
}
