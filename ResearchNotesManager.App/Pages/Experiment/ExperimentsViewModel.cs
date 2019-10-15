using ResearchNotesManager.App.General;
using ResearchNotesManager.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ResearchNotesManager.App.Pages.Experiment
{
    public class ExperimentsViewModel : BaseViewModel
    {
        public ExperimentsViewModel()
        {
            DataProvider = new DataProvider();
            products = new ObservableCollection<Model.Entities.Product>(DataProvider.GetEntities<Model.Entities.Product>().OrderBy(pr => pr.Name).ToList());
        }

        ObservableCollection<Model.Entities.Product> products;
        public virtual ICollection<Model.Entities.Product> Products => products;

        public Command AddNewEntity => new Command(p =>
        {
            OpenEntityPage(DataProvider.Add<Model.Entities.Product>());
        });

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
            }
        });

        public override Command DiscardChanges => new Command(p => { });

        public void OpenEntityPage(object entity)
        {
            if (entity is Model.Entities.Product product)
                OpenEntityPage(product);
        }

        public void OpenEntityPage(Model.Entities.Product product)
        {
            var pageId = "Product:" + product.Guid;
            if (UIManager.PageManager.IsPageAlreadyOpened(pageId))
                UIManager.PageManager.SetCurrentPage(pageId);
            else
               /* UIManager.PageManager.AddPage(new ProductPage(new ProductViewModel(DataProvider, product)))*/;
        }

        public override bool CanClose()
        {
            DataProvider.SaveChanges();
            return true;
        }
    }
}
