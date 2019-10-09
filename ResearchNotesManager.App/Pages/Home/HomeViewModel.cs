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
            //InitNavigations();
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
            //var productNavigation = new HomePageNavigation() { Title = "Продукция" };
            //productNavigation.Items.Add(new HomePageNavigationItem()
            //{
            //    Label = "Продукты",
            //    PageId = "Products",
            //    Icon = "BarcodeScanner",//Barcode BarcodeScanner
            //    Action = new Command((p) => OpenNewPageIfNotExists<Product.ProductsPage>("Products"))
            //});
            //productNavigation.Items.Add(new HomePageNavigationItem()
            //{
            //    Label = "Виды продуктов",
            //    PageId = "ProductTypes",
            //    Icon = "Buffer",
            //    Action = new Command((p) => OpenNewPageIfNotExists<ProductType.ProductTypePage>("ProductTypes"))
            //});

            //productNavigation.Items.Add(new HomePageNavigationItem()
            //{
            //    Label = "Статистика продаж продуктов",
            //    PageId = "ProductStatisticsReport",
            //    Icon = "ChartBar",
            //    Action = new Command((p) => OpenNewPageIfNotExists<Report.ProductStatisticsReport.ProductStatisticsReportPage>("ProductStatisticsReport"))
            //});

            //var salesNavigation = new HomePageNavigation() { Title = "Продажи" };
            //salesNavigation.Items.Add(new HomePageNavigationItem()
            //{
            //    Label = "Торговые точки",
            //    PageId = "SalesPoints",
            //    Icon = "OfficeBuilding",
            //    Action = new Command((p) => OpenNewPageIfNotExists<SalesPoint.SalesPointsPage>("SalesPoints"))
            //});//OfficeBuilding CityVariant
            //salesNavigation.Items.Add(new HomePageNavigationItem()
            //{
            //    Label = "Расходные накладные",
            //    PageId = "SalesDocuments",
            //    Icon = "Notebook",
            //    Action = new Command((p) => OpenNewPageIfNotExists<Sales.SalesDocumentsPage>("SalesDocuments"))
            //});
            //salesNavigation.Items.Add(new HomePageNavigationItem()
            //{
            //    Label = "Отчет о продажах",
            //    PageId = "SalesReport",
            //    Icon = "BookMinus",
            //    Action = new Command((p) => OpenNewPageIfNotExists<Report.SelesReport.SalesReportPage>("SalesReport"))
            //});

            //Navigations.Add(productNavigation);
            //Navigations.Add(salesNavigation);
        }

        void OpenNewPageIfNotExists<TPage>(string pageId) where TPage : BasePage, new()
        {
            if (UIManager.PageManager.IsPageAlreadyOpened(pageId))
                UIManager.PageManager.SetCurrentPage(pageId);
            else
                UIManager.PageManager.AddPage(new TPage());
        }

        public override bool CanClose()
        {
            return true;
        }
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
