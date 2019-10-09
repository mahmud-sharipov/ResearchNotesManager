using ResearchNotesManager.App;
using ResearchNotesManager.Model;
using System.Windows;

namespace ResearchNotesManager.App
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            new EntityContext();
        }
    }
}
