namespace ResearchNotesManager.App.Pages.Experiment
{
    /// <summary>
    /// Interaction logic for ExperimentsPage.xaml
    /// </summary>
    public partial class ExperimentsPage : General.BasePage
    {
        public ExperimentsPage()
        {
            Title = "Все эксперименты";
            Id = "Experiments";
            ViewModel = new ExperimentsViewModel();
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void productsGrig_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((ExperimentsViewModel)DataContext).OpenEntityPage(experimentsGrig.SelectedItem);
        }
    }
}
