using ResearchNotesManager.App.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.App.Pages.Home
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            InitNavigations();
        }

        ObservableCollection<HomePageNavigation> _navigations = new ObservableCollection<HomePageNavigation>();
        public ObservableCollection<HomePageNavigation> Navigations
        {
            get => _navigations;
            private set
            {
                _navigations = value;
                RaisePropertyChanged();
            }
        }

        public override Command DiscardChanges => new Command(p => { });

        public void InitNavigations()
        {
            //product navigation
            var productNavigation = new HomePageNavigation() { Title = "Продукция" };
            productNavigation.Items.Add(new HomePageNavigationItem()
            {
                Label = "Продукты",
                PageId = "Products",
                Icon = "BarcodeScanner",//Barcode BarcodeScanner
                Action = new Command((p) => OpenNewPageIfNotExists<Product.Products>("Products"))
            });
            productNavigation.Items.Add(new HomePageNavigationItem()
            {
                Label = "Добавление продуктов",
                PageId = "ProductLots",
                Icon = "PlaylistAdd",
                Action = new Command((p) => OpenNewPageIfNotExists<ProductLots.ProductLots>("ProductLots"))
            });

            var experimentsNavigation = new HomePageNavigation() { Title = "Эксперименты" };
            experimentsNavigation.Items.Add(new HomePageNavigationItem()
            {
                Label = "Текущие эксперименты",
                PageId = "CurrentExperements",
                Icon = "ChemicalWeapon",
                Action = new Command((p) => OpenNewPageIfNotExists<Experiment.CurrentExperimentsPage>("CurrentExperiments"))
            });//OfficeBuilding CityVariant

            experimentsNavigation.Items.Add(new HomePageNavigationItem()
            {
                Label = "Все эксперименты",
                PageId = "Experiments",
                Icon = "FormatListChecks",
                Action = new Command((p) => OpenNewPageIfNotExists<Experiment.ExperimentsPage>("Experiments"))
            });


            Navigations.Add(productNavigation);
            Navigations.Add(experimentsNavigation);
        }

        void OpenNewPageIfNotExists<TPage>(string pageId, params object[] parameters) where TPage : BasePage, new()
        {
            if (UIManager.PageManager.IsPageAlreadyOpened(pageId))
                UIManager.PageManager.SetCurrentPage(pageId);
            else
                UIManager.PageManager.AddPage(new TPage());
        }

        public override bool CanClose() => false;
    }

    public class HomePageNavigation
    {
        public string Title { get; set; }

        List<HomePageNavigationItem> items = new List<HomePageNavigationItem>();
        public List<HomePageNavigationItem> Items => items;
    }

    public class HomePageNavigationItem
    {
        public string PageId { get; set; }

        private Command action;
        public Command Action
        {
            get { return action; }
            set { action = value; }
        }

        public string Label { get; set; }

        public string Icon { get; set; } = "About";
    }
}
