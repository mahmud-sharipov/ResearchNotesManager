using ResearchNotesManager.App.General;

namespace ResearchNotesManager.App.Pages.ProductLots
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class ProductLots : BasePage
    {
        public ProductLots()
        {
            Title = "Добавление продуктов";
            Id = "ProductLots";
            ViewModel = new ProductLotsViewModel();
            DataContext = ViewModel;
            InitializeComponent();
        }
    }
}
