using ResearchNotesManager.App.General;
using ResearchNotesManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.App.Pages.ProductLots
{
    public class ProductLotsViewModel : BaseViewModel
    {
        public ProductLotsViewModel()
        {
            DataProvider = new DataProvider();
            products = new ObservableCollection<Model.Entities.Product>(DataProvider.GetEntities<Model.Entities.Product>().OrderBy(pr => pr.Name).ToList());
            productLots = new ObservableCollection<Model.Entities.ProductLot>(DataProvider.GetEntities<Model.Entities.ProductLot>().OrderByDescending(pr => pr.Date).ToList());
            Product = products.First();
        }

        Model.Entities.Product _product;
        public virtual Model.Entities.Product Product
        {
            get => _product;
            set
            {
                _product = value;
                RaisePropertyChanged();
            }
        }

        decimal _quantity;
        public decimal Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                RaisePropertyChanged();
            }
        }

        ObservableCollection<Model.Entities.Product> products;
        public virtual ICollection<Model.Entities.Product> Products => products;

        ObservableCollection<Model.Entities.ProductLot> productLots;
        public virtual ICollection<Model.Entities.ProductLot> ProductLots => productLots;

        public Command AddNewEntity => new Command(p =>
        {
            if (Product == null)
                ShowMessage("Пожалуйста, выберите продукт");

            else if (Quantity == 0)
                ShowMessage("Пожалуйста, укажите количество");
            else
            {
                var newProduct = DataProvider.Add<Model.Entities.ProductLot>();
                newProduct.Product = Product;
                newProduct.Quantity = Quantity;
                newProduct.Date = DateTime.Now;
                ProductLots.Add(newProduct);
                ShowMessage($"Добавлен: {Product.Name} \t\nКоличество: {Quantity} {Product.UOM.Name}");
                Quantity = 0;
            }

            void ShowMessage(string message) => UIManager.MessageManager.ShowMessage(message);
        });

        public override Command DiscardChanges => new Command(p => { });

        public override bool CanClose()
        {
            DataProvider.SaveChanges();
            return true;
        }

    }
}
