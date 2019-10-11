using ResearchNotesManager.App.General;

namespace ResearchNotesManager.App.Pages.Home
{
    public partial class HomePage : BasePage
    {
        public HomePage()
        {
            Id = "HomePage";
            Title = "Главная";
            ViewModel = new HomeViewModel();
            DataContext = ViewModel;
            InitializeComponent();
        }
    }
}
