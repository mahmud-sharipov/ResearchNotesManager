using ResearchNotesManager.App.General;
using ResearchNotesManager.App.Pages.Home;
using ResearchNotesManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.App.Pages
{
    public class WindowsViewModel : BaseViewModel
    {
        public WindowsViewModel()
        {
            DataProvider = new DataProvider();
            LoadHomePage();
        }

        void LoadHomePage()
        {
            if (UIManager.PageManager.HomePage == null)
            {
                //Seacrch View
                UIManager.PageManager.HomePage = new HomePage();
                UIManager.PageManager.HomePage.ViewModel.DataProvider = DataProvider;
            }
        }

        bool _settingsIsOpen;
        public bool SettingsIsOpen
        {
            get => _settingsIsOpen;
            set
            {
                _settingsIsOpen = value;
                RaisePropertyChanged();
            }
        }

        public override bool CanClose() { return true; }

        public Command OpenSettins => new Command(p => { SettingsIsOpen = !SettingsIsOpen; });

        public Command OpenHomePage => new Command(p =>
        {
            if (UIManager.PageManager.IsPageAlreadyOpened(UIManager.PageManager.HomePage.Id))
                UIManager.PageManager.SetCurrentPage(UIManager.PageManager.HomePage.Id);
            else
                UIManager.PageManager.AddPage(new HomePage());
        });

        public override Command DiscardChanges => new Command(p => { });
    }
}
