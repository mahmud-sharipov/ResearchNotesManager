using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using ResearchNotesManager.App.General;
using ResearchNotesManager.App.Pages;
using System;

namespace ResearchNotesManager.App
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            var viewModel = new WindowsViewModel();
            DataContext = viewModel;
            InitializeComponent();
            UIManager.MessageManager.SetSnackbar(Snackbar);
            Snackbar.MessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(6000));
            viewModel.OpenHomePage.Execute(null);
        }
    }
}
