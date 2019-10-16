namespace ResearchNotesManager.App.Pages.Experiment
{
    /// <summary>
    /// Interaction logic for ExperimentPage.xaml
    /// </summary>
    public partial class ExperimentPage : General.BasePage
    {
        public ExperimentPage(ExperimentViewModel viewModel)
        {
            Title = $"{viewModel.Experiment.Date.ToString("dd-MM-yyyy")}: {viewModel.Experiment.Product.Name}";
            Id = "Experiment:" + viewModel.Experiment.Guid;
            ViewModel = viewModel;
            DataContext = ViewModel;
            InitializeComponent();
        }
    }
}
