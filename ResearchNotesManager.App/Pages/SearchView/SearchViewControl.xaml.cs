using ResearchNotesManager.App.General;
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
            InitializeComponent()   ;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((SearchViewModel)DataContext).FiterProducts(SearchBox.Text);
        }
    }
}
