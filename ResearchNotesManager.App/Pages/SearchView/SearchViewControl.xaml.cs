using ResearchNotesManager.App.General;
using System.Windows.Controls;
using System.Windows.Input;

namespace ResearchNotesManager.App.Pages.SearchView
{
    public partial class SearchViewControl : BasePage
    {
        public SearchViewControl()
        {
            Title = "Продукты";
            Id = "Products";
            ViewModel = new SearchViewModel();
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((SearchViewModel)DataContext).FiterProducts(SearchBox.Text);
        }

        private void ItemsControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          ((SearchViewModel)DataContext).OpenEntityPage(ProductsList.SelectedItem);
        }
    }
}
