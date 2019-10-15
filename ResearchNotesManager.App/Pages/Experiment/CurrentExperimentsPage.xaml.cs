using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResearchNotesManager.App.Pages.Experiment
{
    public partial class CurrentExperimentsPage : General.BasePage
    {
        public CurrentExperimentsPage()
        {
            Title = "Текущие эксперименты";
            Id = "CurrentExperiments";
            ViewModel = new CurrentExperimentsViewModel();
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void productsGrig_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((CurrentExperimentsViewModel)DataContext).OpenEntityPage(experimentsGrig.SelectedItem);
        }
    }
}
