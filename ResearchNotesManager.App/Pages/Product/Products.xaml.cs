using MaterialDesignThemes.Wpf;
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

namespace ResearchNotesManager.App.Pages.Product
{
    public partial class Products : BasePage
    {
        public Products()
        {
            Title = "Продукты";
            Id = "Products";
            ViewModel = new ProductsViewModel();
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void DeleteEntity(object sender, DialogClosingEventArgs e)
        {
            if (!e.IsCancelled) ;
                (ViewModel as ProductsViewModel).DeleteEntity.Execute(e.Parameter);
        }

        private void SaveNewProduct(object sender, DialogClosingEventArgs e)
        {
            if (!e.IsCancelled) ;
            (ViewModel as ProductsViewModel).DeleteEntity.Execute(e.Parameter);
        }
    }
}
