using ResearchNotesManager.App.General;
using ResearchNotesManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchNotesManager.App.Pages.Product
{
    public class ProductsViewModel : BaseViewModel
    {
        public ProductsViewModel()
        {
            DataProvider = new DataProvider();
            _uoms = new ObservableCollection<Model.Entities.UnitOfMeasures>(DataProvider.GetEntities<Model.Entities.UnitOfMeasures>().ToList());
            products = new ObservableCollection<Model.Entities.Product>(DataProvider.GetEntities<Model.Entities.Product>().OrderBy(pr => pr.Name).ToList());
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

        ObservableCollection<Model.Entities.Product> products;
        public virtual ICollection<Model.Entities.Product> Products => products;

        public Command AddNewEntity => new Command(p =>
        {
            var newProduct = DataProvider.Add<Model.Entities.Product>();
            newProduct.UOM = UOMs.First();
            Products.Add(newProduct);
            Product = newProduct;
        });

        private ObservableCollection<Model.Entities.UnitOfMeasures> _uoms;
        public virtual ICollection<Model.Entities.UnitOfMeasures> UOMs => _uoms;

        public Command RefreshPage => new Command(p =>
        {
            Products.Clear();
            DataProvider.SaveChanges();
            DataProvider.GetEntities<Model.Entities.Product>().OrderBy(pr => pr.Name).ToList().ForEach(product => Products.Add(product));
        });

        public Command DeleteEntity => new Command(p =>
        {
            if (p is Model.Entities.Product product)
            {
                product.Delete();
                Products.Remove(product);
                UIManager.MessageManager.ShowMessage($"{product.Name} успешно удалён!");
            }
        });

        public override Command DiscardChanges => new Command(p => { });

        public override bool CanClose()
        {
            DataProvider.SaveChanges();
            return true;
        }
    }
}
